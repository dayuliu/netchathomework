using SocketCommon;

namespace MessengerClinet
{
    public partial class FormClient : Form
    {
        private const int SERVER_PORT = 20255;          // 服务器端口号
        private Client client;                          // 客户端实例

        /// <summary>
        /// 构造函数 a
        /// </summary>
        public FormClient()
        {
            InitializeComponent();

            // 初始化客户端
            client = new Client();

            // 注册服务器连接状态刷新事件
            client.RefreshConnectStatus += Client_RefreshConnectStatus;

            // 注册数据接收事件
            client.DataReceive += Client_DataReceive;
        }

        /// <summary>
        /// 事件——服务器连接状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_RefreshConnectStatus(object? sender, ConnectEventArgs e)
        {
            if (e.Connected)
            {
                // 更新状态栏显示及按钮状态
                Invoke(() =>
                {
                    tsslStatus.Text = "服务器已连接";
                    tspbProgress.Visible = false;
                    btnSend.Enabled = true;
                });
            }
            else
            {
                // 更新状态栏显示及按钮状态
                Invoke(() =>
                {
                    tsslStatus.Text = "正在连接服务器...";
                    tspbProgress.Visible = true;
                    btnSend.Enabled = false;
                });
            }
        }

        /// <summary>
        /// 事件——数据接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_DataReceive(object? sender, SocketCommon.ReceiveEventArgs e)
        {
            // 显示接收到的数据
            Invoke(() =>
            {
                rtboxReceive.AppendText(e.Text + "\r\n");
            });
        }

        /// <summary>
        /// 事件——按下发送键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            Send();
        }

        /// <summary>
        /// 事件——键盘处理
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                // 实现回车发送
                Send();
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// 函数——发送文本
        /// </summary>
        private void Send()
        {
            // 将自己发的字符串显示在接收区
            rtboxReceive.AppendText(tboxSend.Text + "\r\n");

            // 设定本人发送内容回显格式
            int index = rtboxReceive.Text.LastIndexOf(tboxSend.Text);
            rtboxReceive.Select(index, tboxSend.Text.Length);
            rtboxReceive.SelectionColor = Color.YellowGreen;
            rtboxReceive.SelectionAlignment = HorizontalAlignment.Right;
            rtboxReceive.Select(rtboxReceive.Text.Length, 0);
            rtboxReceive.ScrollToCaret();

            // 发送字符串到服务器
            client.Send(tboxSend.Text);

            // 清空发送区
            tboxSend.Clear();
        }

        /// <summary>
        /// 事件——点击连接服务器按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            // 设置控件状态
            btnConnect.Enabled = false;
            tboxServerIP.ReadOnly = true;

            // 设置状态栏
            tsslStatus.Text = "正在连接服务器...";
            tspbProgress.Visible = true;

            // 连接服务器
            client.Connect(tboxServerIP.Text, SERVER_PORT);
        }

        /// <summary>
        /// 事件——点击清空接收区按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            rtboxReceive.Clear();
        }
    }
}