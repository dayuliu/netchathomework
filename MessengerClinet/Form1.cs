using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text;
using MessengerClinet;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button_connect_Click(object sender, EventArgs e) // 连接服务器
        {
            if (label_connected.Text != "服务器已连接")
            {
                socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint _port = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 20255);
                socketClient.SendTimeout = 1000;
                socketClient.BeginConnect(_port, new AsyncCallback(ConnectCallback), socketClient);
            }
        }
        private void ConnectCallback(IAsyncResult ia) // 连接成功的回调
        {
            try
            {
                Invoke(() =>
                {
                    ((Socket)ia.AsyncState).EndConnect(ia);
                    socketClient = ia.AsyncState as Socket;


                    label_connected.Text = "服务器已连接";
                    socketClient.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socketClient);// 异步接受消息
                });
            }
            catch (Exception ex)  //异常捕获
            {
                MessageBox.Show(ex.ToString());
            }
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
                    MessageBox.Show(context);
                Invoke(() =>
                {
                    if (context == "04|03")
                    {
                        this.Hide();
                        Form formClient = new FormClient(socketClient);
                        formClient.Show();
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

        private void button_reg_Click(object sender, EventArgs e)
        {
            send_to_Server("01|" + textBox_nickname_reg.Text + "|" + textBox_password_reg.Text);
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            send_to_Server("03|" + textBox_account.Text + "|" + textBox_password_login.Text);
        }

        private void send_to_Server(string str)
        {
            byte[] buffer_tmp = Encoding.Default.GetBytes(str);
            socketClient.Send(buffer_tmp, 0, buffer_tmp.Length, SocketFlags.None);
        }
    }
}