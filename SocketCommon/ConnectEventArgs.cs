namespace SocketCommon
{
    /// <summary>
    /// 连接状态改变事件参数类
    /// </summary>
    public class ConnectEventArgs
    {
        /// <summary>
        /// 服务器连接状态
        /// </summary>
        public bool Connected { get; set; } = false;
    }
}
