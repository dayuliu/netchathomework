using System.Net.Sockets;

namespace SocketCommon
{
    /// <summary>
    /// 异步数据接收参数类
    /// </summary>
    public class ReceiveState
    {
        /// <summary>
        /// 异步连接远程套接字
        /// </summary>
        public Socket Socket { get; }

        /// <summary>
        /// 异步连接接收缓存
        /// </summary>
        public byte[] Buffer { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="bufferSize"></param>
        public ReceiveState(Socket socket, int bufferSize)
        {
            this.Socket = socket;
            this.Buffer = new byte[bufferSize];
        }
    }
}