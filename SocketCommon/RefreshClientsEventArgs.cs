namespace SocketCommon
{
    /// <summary>
    /// 刷新客户端事件参数
    /// </summary>
    public class RefreshClientsEventArgs
    {
        /// <summary>
        /// 客户端列表
        /// </summary>
        public string[] Clients { get; set; } = default!;
    }
}
