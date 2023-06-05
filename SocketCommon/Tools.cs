using System.Net.Sockets;

namespace SocketCommon
{
    public static class Tools
    {
        /// <summary>
        /// 函数——检查Socket是否处于连接状态
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        public static bool IsSocketConnected(Socket socket)
        {
            bool connectState = false;
            bool blockingState = socket.Blocking;
            try
            {
                // 以非阻塞方式发送0字节数据
                byte[] buffer = new byte[0];
                socket.Blocking = false;
                socket.Send(buffer, 0, SocketFlags.None);
                connectState = true;
            }
            catch (SocketException e)
            {
                // 产生WSAEWOULDBLOCK错误，套接字仍处于连接状态 
                if (e.NativeErrorCode.Equals(10035))
                    connectState = true;
            }
            finally
            {
                socket.Blocking = blockingState;
            }
            return connectState;
        }
    }
}
