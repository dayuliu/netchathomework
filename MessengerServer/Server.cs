using SocketCommon;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Text;

namespace MessengerServer
{
    internal class Server
    {
        private Socket server_socket;                   // 服务器Socket实例
        private List<Socket> Clients;                   // 已连接客户端列表

        private object clientListLock = new object();   // 客户端列表操作锁
        private const int RECEIVE_BUFF_SIZE = 1024;     // 接收缓冲区大小

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

            // 修改连接客户端列表
            lock (clientListLock)
                Clients.Add(client_socket);

            // 触发更新客户端列表事件
            RefreshClientList();

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
            // 发送数据到其他客户端
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
        }

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
    }
}
