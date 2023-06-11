using SocketCommon;
using System.Net.Sockets;
using System.Text;

namespace MessengerClinet
{
    public class Client
    {
        private Socket client_socket;                   // 客户端Socket
        private const int RECEIVE_BUFF_SIZE = 1024;     // 定义接收缓冲区大小
        private bool connected = false;                 // 保存与服务器的连接状态

        /// <summary>
        /// 事件——刷新服务器连接状态
        /// </summary>
        public event EventHandler<ConnectEventArgs> RefreshConnectStatus = default!;

        /// <summary>
        /// 事件——收到数据
        /// </summary>
        public event EventHandler<ReceiveEventArgs> DataReceive = default!;

        public event EventHandler<ReceiveEventArgs> AddConnectionReceive = default!;

        /// <summary>
        /// 事件——收到好友数据
        /// </summary>
        public event EventHandler<ReceiveEventArgs> DataFriendReceive = default!;

        // 发送私聊消息反馈事件
        public event EventHandler<ReceiveEventArgs> DataPrivate = default!;

        // 私聊接收消息事件
        public event EventHandler<ReceiveEventArgs> DataPrivateReceive = default!;


        //接受好友请求
        public event EventHandler<ReceiveEventArgs> DataApplyFriend = default!;

        // 群聊广播事件
        public event EventHandler<ReceiveEventArgs> DataBroadcastReceive = default!;


        public event EventHandler<ReceiveEventArgs> DataUpdNickNameReceive = default!;


        /*        /// <summary>
                /// 事件——收到当前在线人员数据
                /// </summary>
                public event EventHandler<ReceiveEventArgs> DataOnlineReceive = default!;
        */

        /// <summary>
        /// 构造函数
        /// </summary>
        public Client ()
        {
            // 初始化客户端Socket
            client_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        /// 方法——启动线程连接服务器
        /// </summary>
        /// <param name="IPAddress"></param>
        /// <param name="Port"></param>
        public void Connect (string IPAddress, int Port)
        {
            ThreadPool.QueueUserWorkItem( _ =>
            {
                connected = false;

                while (true)
                {
                    // 测试服务器是否处于连接状态
                    if (Tools.IsSocketConnected(client_socket))
                    {
                        if (!connected)
                        {
                            // 触发状态刷新事件
                            connected = true;
                            RefreshConnectStatus(this, new ConnectEventArgs() { Connected = true });

                            // 启动异步数据接收
                            ReceiveState state = new ReceiveState(client_socket, RECEIVE_BUFF_SIZE);
                            client_socket.BeginReceive(state.Buffer, 0, RECEIVE_BUFF_SIZE, SocketFlags.None, ReceiveCallback, state);
                        }
                    } 
                    else
                    {
                        if (connected)
                        {
                            // 触发状态刷新事件
                            connected = false;
                            RefreshConnectStatus(this, new ConnectEventArgs() { Connected = false });
                        }

                        // 连接服务器
                        try
                        {
                            client_socket.Connect(IPAddress, Port);
                        }
                        catch (SocketException)
                        {
                            continue;
                        }
                        catch (InvalidOperationException)
                        {
                            // 连接已被关闭，重新初始化客户端Socket
                            client_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        }
                    }
                }
            });
        }

        /// <summary>
        /// 方法——发送指定文本
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public bool Send (string Text)
        {
            try
            {
                client_socket.Send(Encoding.Default.GetBytes(Text));
                return true;
            }
            catch (Exception ex) when (ex is SocketException || ex is ObjectDisposedException)
            {
                // 连接已关闭或清理，返回false
                return false;
            }
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
        /// 处理接收到的数据
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="len"></param>
        private void ProcessReceivedData(Socket socket, byte[] buffer, int len)
        {
            string TextFormat = Encoding.Default.GetString(buffer, 0, len);
            string[] tt = TextFormat.Split("|");
            if (tt[0] == "10")
            {
                AddConnectionReceive(this, new ReceiveEventArgs() { Text = tt[1] });
            }
            else if (tt[0] == "14") {
                int i = 1;
                for (; i < tt.Length && i+1 <tt.Length; i=i+2)
                {
                    DataFriendReceive(this, new ReceiveEventArgs() { Text = tt[i]+"|"+tt[i+1] });
                }
            }
            // 发送私聊反馈 06|fromAccount+Info|message
            else if (tt[0] == "05")
            {
                DataPrivate(this, new ReceiveEventArgs() { Text = tt[1] });
            }
            // 私聊接收 06|fromAccount+Info|message
            else if (tt[0] == "06")
            {
                DataPrivateReceive(this, new ReceiveEventArgs() { Text = TextFormat });
            }
            // 群聊反馈消息事件
            else if (tt[0] == "07")
            {
            }
            // 群聊接受消息事件
            else if (tt[0] == "08")
            {
                DataBroadcastReceive(this, new ReceiveEventArgs() { Text = TextFormat });
            }
            else if (tt[0] == "15")
            {

                DataApplyFriend(this, new ReceiveEventArgs() { Text = tt[1] });
            } else if (tt[0] == "12")
            {
                DataUpdNickNameReceive(this, new ReceiveEventArgs() { Text = tt[1] });
            }

            else
            {
                // 触发数据接收事件
                DataReceive(this, new ReceiveEventArgs() { Text = Encoding.Default.GetString(buffer, 0, len) });
            }

        }
    }
}
