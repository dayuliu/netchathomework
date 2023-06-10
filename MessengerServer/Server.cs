using SocketCommon;
using System.Drawing;
using System;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.VisualBasic;
using System.Globalization;

namespace MessengerServer
{
    internal class Server
    {
        private Socket server_socket;                   // 服务器Socket实例
        private List<Socket> Clients;                   // 已连接客户端列表


        private object clientListLock = new object();   // 客户端列表操作锁
        private const int RECEIVE_BUFF_SIZE = 1024 * 1024;     // 接收缓冲区大小

        //登录注册使用
        int user_cnt = 0; // 当前用户数，用于生成账号
        private Dictionary<string, string> passwords = new Dictionary<string, string>(); // account->password
        private Dictionary<string, string> nicknames = new Dictionary<string, string>(); // account->nickname


        private Dictionary<string, Socket> sockets = new Dictionary<string, Socket>(); // account->sockets

        //构造好友列表
        private Dictionary<string, List<string>> friends = new Dictionary<string, List<string>>(); // account->friends_account






        /// <summary>
        /// 事件——刷新已连接的客户端列表
        /// </summary>
        public event EventHandler<RefreshClientsEventArgs> RefreshClients = default!;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Server()
        {
            // 创建服务器Socket实例
            server_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 初始化客户端列表
            Clients = new List<Socket>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="port"></param>
        /// <exception cref="ArgumentNullException">参数为null</exception>
        /// <exception cref="FormatException">未传入有效的IP地址或端口号</exception>
        /// <exception cref="ArgumentOutOfRangeException">端口号超范围</exception>
        /// <exception cref="SocketException">尝试访问套接字时出错</exception>
        /// <exception cref="ObjectDisposedException">Socket已关闭</exception>
        /// <exception cref="SecurityException">调用堆栈中的较高调用方无权执行所请求的操作</exception>
        /// <returns></returns>
        public bool Start(string IP, int port)
        {
            // Socket绑定
            server_socket.Bind(new IPEndPoint(IPAddress.Parse(IP), port));

            // 监听端口
            server_socket.Listen();

            // 异步接收传入连接
            var result = server_socket.BeginAccept(AcceptCallback, null);

            // 启动线程检查是否有连接断开
            ThreadPool.QueueUserWorkItem(ThreadProcess_ClientDamon);

            return true;
        }

        /// <summary>
        /// 线程——循环检查客户端列表中是否有已断开的连接，并触发更新事件
        /// </summary>
        /// <param name="state"></param>
        private void ThreadProcess_ClientDamon(object? state)
        {
            bool hasChanged = false;    // 记录是否连接的客户端有变化

            while (true)
            {
                // 检查是否有已断开的连接
                lock (clientListLock)
                {
                    for (int i = 0; i < Clients.Count; i++)
                    {
                        if (!Tools.IsSocketConnected(Clients[i]))
                        {
                            try
                            {
                                // 关闭发送和接收
                                Clients[i].Shutdown(SocketShutdown.Both);
                            }
                            finally
                            {
                                // 关闭远程连接，并释放所有资源
                                Clients[i].Close();
                            }
                            lock (sockets)
                            {
                                string key = sockets.FirstOrDefault(x => x.Value == Clients[i]).Key;
                                sockets.Remove(key);
                            }
                            // 从列表中删除
                            Clients.Remove(Clients[i]);
                            hasChanged = true;
                        }
                    }
                }

                if (hasChanged)
                {
                    // 触发更新客户端列表事件
                    RefreshClientList();
                    /* foreach (var socket_send in Clients)
                     {
                         SendClientList(socket_send);
                     }*/

                    hasChanged = false;
                }
            }
        }

        /// <summary>
        /// 异步回调——接收到新的TCP连接
        /// </summary>
        /// <param name="ar"></param>
        private void AcceptCallback(IAsyncResult ar)
        {
            // 获取Accept异步结果
            var client_socket = server_socket.EndAccept(ar);

            // 启动异步数据接收
            ReceiveState state = new ReceiveState(client_socket, RECEIVE_BUFF_SIZE);
            client_socket.BeginReceive(state.Buffer, 0, RECEIVE_BUFF_SIZE, SocketFlags.None, ReceiveCallback, state);


            //模拟添加好友场景，模拟新登录一个人，所有在线的人都加他为好友  ---  可删除
            foreach (var socket in Clients)
            {
                if (socket != client_socket)
                {
                    try
                    {
                        if(sockets.FirstOrDefault(x => x.Value == client_socket).Key is not null)
                        { 
                        friends[sockets.FirstOrDefault(x => x.Value == socket).Key].Add(sockets.FirstOrDefault(x => x.Value == client_socket)!.Key);
                        }
                    }
                    finally
                    {
                    }
                }
            }



            //添加好友后，向客户端发送事件
            foreach (var socket_send in Clients)
            {
                SendClientFriendList(socket_send);
            }



            // 修改连接客户端列表
            lock (clientListLock)
                Clients.Add(client_socket);




            // 触发更新客户端列表事件
            RefreshClientList();




            //触发更新client端的列表状态更新
            /*            foreach (var socket_send in Clients)
                        {
                            SendClientList(socket_send);
                        }*/

            // 异步等待新客户端连接
            server_socket.BeginAccept(AcceptCallback, null);
        }

        /// <summary>
        /// 异步回调——套接字接收到数据
        /// </summary>
        /// <param name="ar"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void ReceiveCallback(IAsyncResult ar)
        {
            // 提取参数
            var state = ar.AsyncState as ReceiveState;

            // 接收异步数据
            int len;
            try
            {
                len = state!.Socket.EndReceive(ar);
            }
            catch (Exception ex) when (ex is ObjectDisposedException || ex is SocketException)
            {
                // 连接已关闭，则停止异步接收
                return;
            }

            // 处理收到的数据
            ProcessReceivedData(state.Socket, state.Buffer, len);

            // 继续启动异步接收
            state.Socket.BeginReceive(state.Buffer, 0, RECEIVE_BUFF_SIZE, SocketFlags.None, ReceiveCallback, state);
        }

        /// <summary>
        /// 函数——处理接收到的数据
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="len"></param>
        private void ProcessReceivedData(Socket socket, byte[] buffer, int len)
        {
            try
            {
                string context = Encoding.Default.GetString(buffer, 0, len);
                string[] args = context.Split("|");
                string str_to_client = null;
                switch (args[0])
                {
                    case "01":
                        {
                            str_to_client = on_reg(args);
                            break;
                        }
                    case "03":
                        {
                            str_to_client = on_login(args, socket);
                            break;
                        }

                    case "09":
                        {
                            str_to_client = on_add_connection(args, socket);
                            break;
                        }

                    default:
                        {
                            foreach (var socket_send in Clients)
                            {
                                if (socket_send != socket)
                                {
                                    // 添加发送者的地址和端口号
                                    byte[] address = Encoding.Default.GetBytes(string.Format("[{0}] ", socket.RemoteEndPoint!.ToString()!));
                                    byte[] sendBuffer = new byte[address.Length + buffer.Length];
                                    address.CopyTo(sendBuffer, 0);
                                    buffer.CopyTo(sendBuffer, address.Length);
                                    socket_send.Send(sendBuffer, address.Length + len, SocketFlags.None);
                                }
                            }
                            //str_to_client = "context error!";
                            break;
                        }
                }
                if (str_to_client != null) // 将str_to_client发送给客户端
                {
                    byte[] buffer_tmp = Encoding.Default.GetBytes(str_to_client);
                    socket.Send(buffer_tmp, 0, buffer_tmp.Length, SocketFlags.None);
                }

            }
            catch  //客户端已下线
            {
                string account = null;
                foreach (KeyValuePair<string, Socket> item in sockets)
                {
                    if (item.Value == socket)
                    {
                        account = item.Key;

                    }
                }
                if (account != null)
                {
                    MessageBox.Show("账号:" + account + "已下线");
                    sockets.Remove(account);
                }
            }




            // 发送数据到其他客户端

        }
        //登录所需函数
        private string on_reg(string[] args)
        {

            if (nicknames.ContainsKey(args[1]))
            {
                return "02|1";
            }

            nicknames.Add(args[1], args[1]);
            passwords.Add(args[1], args[2]);
            friends.Add(args[1], new List<string>());
            return "02|0";
        }

        private string on_login(string[] args, Socket socketWorker)
        {
            if (!nicknames.ContainsValue(args[1])) // 账号不存在
            {
                return "04|1";
            }

            if (passwords[nicknames.FirstOrDefault(x => x.Value == args[1]).Key] != args[2]) // 密码不正确
            {
                return "04|2";
            }

            if (sockets.ContainsKey(args[1])) // 用户已登录
            {
                return "04|3";
            }

            // 登录成功
            sockets[args[1]] = socketWorker;
            return "04|0";
        }


        private string on_add_connection(string[] args, Socket socketWorker)
        {
            if (!nicknames.ContainsValue(args[1])) // 账号不存在
            {
                return "10|00";
            }
            var currentUserPir = sockets.First(kv => kv.Value == socketWorker);
            var currentUserId = currentUserPir.Key;
            if (currentUserId == null)
                return "10|00";
            var currentFriends = friends[currentUserId];
            if (currentFriends.Contains(args[1]))
            {
                return "10|02";
            }
            currentFriends.Add(args[1]);
            friends[currentUserId] = currentFriends;

            // notify user
            SendClientFriendList(currentUserPir.Value);

            return "10|01";
        }


        //好友列表更新所需函数

        /// <summary>
        /// 函数——触发更新客户端列表事件
        /// </summary>
        private void RefreshClientList()
        {
            // 准备新客户端列表
            IEnumerable<string> clientList;
            lock (clientListLock)
                clientList = Clients.Select<Socket, string>(client => { return client.RemoteEndPoint!.ToString()!; });

            // 触发事件
            RefreshClients(this, new RefreshClientsEventArgs() { Clients = clientList.ToArray() });


        }

        /// <summary>
        /// 向客户端发送当前在线人数
        /// </summary>
        /// <param name="socket">客户的socket文件</param>
        /// <returns></returns>
        private bool SendClientList(Socket socket)
        {
            try
            {
                List<string> clientList = new List<string>();
                lock (clientListLock)
                {
                    if (Clients is not null)
                    {
                        foreach (var client in Clients)
                        {

                            if (client != socket)
                            {
                                clientList.Add(client.RemoteEndPoint!.ToString()!);
                            }
                        }
                    }

                }
                //构造传递在线用户的数据格式
                string sendClintlist = "15|";
                if (clientList is not null && clientList.Count() != 0)
                {
                    foreach (string clientname in clientList)
                    {
                        sendClintlist += clientname + "|";
                    }
                    sendClintlist = sendClintlist.Substring(0, sendClintlist.Length - 1);
                    byte[] buffer = Encoding.Default.GetBytes(sendClintlist);
                    // 进行发送
                    socket.Send(buffer, SocketFlags.None);
                }
                return true;
            }
            catch (Exception ex) when (ex is SocketException || ex is ObjectDisposedException)
            {
                // 连接已关闭或清理，返回false
                return false;
            }
        }
        /// <summary>
        /// 将个人的好友信息发送到客户端
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        private bool SendClientFriendList(Socket socket)
        {
            try
            {
                List<string> flist;
                lock (friends)
                {
                    flist = friends[nicknames.FirstOrDefault(z => z.Value == (sockets.FirstOrDefault(x => x.Value == socket).Key)).Key];
                }
                //构造传递用户好友的数据格式
                string sendClintFriendlist = "14|";
                if (flist is not null && flist.Count() != 0)
                {
                    foreach (string clientname in flist)
                    {
                        sendClintFriendlist += clientname + "|";
                    }
                    sendClintFriendlist = sendClintFriendlist.Substring(0, sendClintFriendlist.Length - 1);
                    byte[] buffer = Encoding.Default.GetBytes(sendClintFriendlist);
                    // 进行发送
                    socket.Send(buffer, SocketFlags.None);
                }
                return true;
            }
            catch (Exception ex) when (ex is SocketException || ex is ObjectDisposedException)
            {
                // 连接已关闭或清理，返回false
                return false;
            }
        }


    }
}
