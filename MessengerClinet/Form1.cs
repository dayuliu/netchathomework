using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text;
using MessengerClinet;
using System.Drawing;
using SocketCommon;
using System.Threading.Tasks;

namespace ChatClient
{
    public partial class Form1 : Form
    {



        private Client client;                          // 客户端实例


        public Form1()
        {
            InitializeComponent();
            button_reg.Enabled = false;
            button_login.Enabled = false;

            // 初始化客户端
            client = new Client();

            // 注册服务器连接状态刷新事件
            client.RefreshConnectStatus += Client_RefreshConnectStatus;

            // 注册数据接收事件
            client.DataReceive += Client_DataReceive;


        }




        /// <summary>
        /// 事件——数据接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_DataReceive(object? sender, SocketCommon.ReceiveEventArgs e)
        {
            // 显示接收到的数据

            string context = e.Text;
            Invoke(() =>
            {
                string[] args = context.Split("|");

                switch (args[0])
                {
                    case "02": // 注册
                        {
                            on_reg_resp(args);
                            break;
                        }

                    case "04": // 登录
                        {
                            on_login_resp(args);
                            break;
                        }

                    default:
                        break;
                }

            });
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
                    label_connected.Text = "服务器已连接";
                    button_connect.Visible = false;
                    button_reg.Enabled = true;
                    button_login.Enabled = true;
                });
            }
            else
            {
                // 更新状态栏显示及按钮状态
                Invoke(() =>
                {
                    label_connected.Text = "正在连接服务器...";
                });
            }
        }



        private void button_connect_Click(object sender, EventArgs e) // 连接服务器
        {

            client.Connect("127.0.0.1", 20255);
        }
      
        private void ReceiveCallback(IAsyncResult ia) // 接收到消息的回调
        {
            socketClient = ia.AsyncState as Socket;
            if (socketClient == null)
            {
                return;
            }
            try
            {

                int bytesRead = socketClient.EndReceive(ia);  //接受消息成功并返回消息长度 
                string context = Encoding.Default.GetString(buffer, 0, bytesRead);  //缓存解码为字符串
                socketClient.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socketClient);  //异步接受消息

                Invoke(() =>
                {
                    string[] args = context.Split("|");

                    switch (args[0])
                    {
                        case "02": // 注册
                            {
                                on_reg_resp(args);
                                break;
                            }

                        case "04": // 登录
                            {
                                 on_login_resp(args);
                                break;
                            }

                        default:
                                break;
                    }
                    
                });
                // 处理消息
            }
            catch (Exception ex)  //异常捕获
            {
                MessageBox.Show(ex.ToString());
            }
        }

        byte[] buffer = new byte[5 * 1024 * 1024];  //创建接受消息缓存数组并约定缓存长度解决粘包问题
        Socket socketClient = null;  //创建全局变量客户端套接字




        private void on_reg_resp(string[] args) {

            if (args[1] == "1")
            {
                MessageBox.Show("账号已经存在");
                return;
            }

            MessageBox.Show("注册成功");

        }

        private void on_login_resp(string[] args)
        {

            if (args[1] == "1")
            {
                MessageBox.Show("账号已经存在");
                return;
            }

            if (args[1] == "2")
            {
                MessageBox.Show("密码不正确");
                return;
            }


            if (args[1] == "3")
            {
                MessageBox.Show("用户已登录");
                return;
            }


            MessageBox.Show("登录成功");

            this.Hide();
            // 注册服务器连接状态刷新事件
            client.RefreshConnectStatus -= Client_RefreshConnectStatus;

            // 注册数据接收事件
            client.DataReceive -= Client_DataReceive;
            Form formClient = new FormClient(textBox_nickname_reg.Text, this.client);
            formClient.Show();

        }



        private void button_reg_Click(object sender, EventArgs e)
        {
            send_to_Server("01|" + textBox_nickname_reg.Text + "|" + textBox_password_reg.Text);
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            send_to_Server("03|" + textBox_nickname_reg.Text + "|" + textBox_password_reg.Text);
        }

        private void send_to_Server(string str)
        {
            client.Send(str);
        }

       
    }
}