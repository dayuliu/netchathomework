namespace SocketCommon
{
    /// <summary>
    /// 收到数据事件参数
    /// </summary>
    public class ReceiveEventArgs
    {
        /// <summary>
        /// 收到的字符串
        /// </summary>
        public string Text { get; set; } = string.Empty;
    }
}
