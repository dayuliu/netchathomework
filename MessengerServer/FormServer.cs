using SocketCommon;

namespace MessengerServer
{
    public partial class FormServer : Form
    {
        private Server server;                          // 服务器实例
        private const int SERVER_PORT = 20255;          // 服务器端口号

        /// <summary>
        /// 构造函数
        /// </summary>
        public FormServer()
        {
            InitializeComponent();

            // 创建服务器实例
            server = new Server();

            // 注册刷新客户端列表事件
            server.RefreshClients += Server_RefreshClients;
        }

        /// <summary>
        /// 事件——刷新客户端列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Server_RefreshClients(object? sender, RefreshClientsEventArgs e)
        {
            if (lbClients.InvokeRequired)
            {
                lbClients.Invoke(() =>
                {
                    // 清空当前列表
                    lbClients.Items.Clear();

                    // 显示新列表
                    lbClients.Items.AddRange(e.Clients);
                });
            }

        }

        /// <summary>
        /// 事件——点击启动服务器按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            // 设置控件状态
            btnStart.Enabled = false;
            tboxServerIP.ReadOnly = true;

            // 设置状态栏信息
            tsslStatus.Text = "服务器已启动";

            // 启动服务器
            server.Start(tboxServerIP.Text.ToString(), SERVER_PORT);
        }
    }
}