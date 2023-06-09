using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;

#region

#endregion

namespace ChatServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress _ip = IPAddress.Any;
            IPEndPoint _port = new IPEndPoint(_ip, 9999);
            try
            {
                socketServer.Bind(_port);
                socketServer.Listen(100);
                socketServer.BeginAccept(new AsyncCallback(AcceptCallback), socketServer);
            }
            catch 
            {
                MessageBox.Show("服务器已上线");
            }
            label_start.Text = "服务器已启动";
        }
        private void AcceptCallback(IAsyncResult ia)
        {
            socketServer = ia.AsyncState as Socket;
            Socket socketWorker = socketServer.EndAccept(ia);
            socketWorker.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socketWorker);  //异步接受消息
            socketServer.BeginAccept(new AsyncCallback(AcceptCallback), socketServer);
        }

        /* 接受消息异步回调处理 */
        private void ReceiveCallback(IAsyncResult ia)
        {
            Socket socketWorker = ia.AsyncState as Socket;
            try
            {
                int bytesRead = socketWorker.EndReceive(ia);  //接受消息成功并返回消息长度
                if (bytesRead > 0)  //接受到非空消息
                {
                    string context = Encoding.Default.GetString(buffer, 0, bytesRead);  //缓存解码为字符串
                    socketWorker.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socketWorker);  //再次异步接受消息
                    string[] args = context.Split('|');
                    string str_to_client = null;
                    textBox_online_client.AppendText("receive:" + context + "\r\n");
                    switch (args[0])
                    {
                        case "01":
                            {
                                str_to_client = on_reg(args);
                                break;
                            }
                        case "03":
                            {
                                str_to_client = on_login(args, socketWorker);
                                break;
                            }
                        default:
                            {
                                str_to_client = "context error!";
                                break;
                            }
                    }
                    textBox_online_client.AppendText("send:" + str_to_client + "\r\n");
                    if (str_to_client != null) // 将str_to_client发送给客户端
                    {
                        byte[] buffer_tmp = Encoding.Default.GetBytes(str_to_client);
                        socketWorker.Send(buffer_tmp, 0, buffer_tmp.Length, SocketFlags.None);
                    }
                }
            }
            catch  //客户端已下线
            {
                string account = null;
                foreach (KeyValuePair<string, Socket> item in sockets)
                {
                    if (item.Value == socketWorker)
                    {
                        account = item.Key;
                        
                    }
                }
                if (account != null)
                {
                    MessageBox.Show("账号:" + account + "已下线");
                    sockets.Remove(account);
                }
            }
        }

        private string on_reg(string[] args)
        {
            string account = string.Format("{0:0000}", user_cnt++);
            nicknames.Add(account, args[1]);
            passwords.Add(account, args[2]);
            friends.Add(account, new List<string>());
            return "02|" + account;
        }

        private string on_login(string[] args, Socket socketWorker)
        {
            if (!passwords.ContainsKey(args[1])) // 账号不存在
            {
                return "04|00";
            }

            if (passwords[args[1]] != args[2]) // 密码不正确
            {
                return "04|01";
            }

            if (sockets.ContainsKey(args[1])) // 用户已登录
            {
                return "04|02";
            }

            // 登录成功
            sockets[args[1]] = socketWorker;
            return "04|03";
        }

        byte[] buffer = new byte[1024 * 1024];  //创建接受消息缓存数组并约定缓存长度解决粘包问题
        int user_cnt = 0; // 当前用户数，用于生成账号
        private Dictionary<string, string> passwords = new Dictionary<string, string>(); // account->password
        private Dictionary<string, string> nicknames = new Dictionary<string, string>(); // account->nickname
        private Dictionary<string, Socket> sockets = new Dictionary<string, Socket>(); // account->sockets
        private Dictionary<string, List<string>> friends = new Dictionary<string, List<string>>(); // account->friends_account
        
        private Socket socketServer = null;
    }
}