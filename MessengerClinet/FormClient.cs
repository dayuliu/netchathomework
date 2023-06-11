using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using SocketCommon;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;

namespace MessengerClinet
{
    public partial class FormClient : Form
    {
        private const int SERVER_PORT = 20255;          // 服务器端口号
        private Client client;                          // 客户端实例
        private const int RECEIVE_BUFF_SIZE = 1024;     // 定义接收缓冲区大小
        byte[] buffer = new byte[5 * 1024 * 1024];  //创建接受消息缓存数组并约定缓存长度解决粘包问题
        Socket socketClient;
        string clientAccount;

        FriendItem current_friend;

        private Dictionary<string, RichTextBox> userRepo = new Dictionary<string, RichTextBox>(); // 用户聊天记录


        /// <summary>
        /// 构造函数 a
        /// </summary>
        public FormClient(string account, string nickname, Client c)
        {


            client = c;

            // 注册服务器连接状态刷新事件
            client.RefreshConnectStatus += Client_RefreshConnectStatus;

            // 注册数据接收事件
            client.DataReceive += Client_DataReceive;


            clientAccount = account;
            InitializeComponent();


            this.input_nickname.Text = nickname;

            FriendItem pub_zone = new FriendItem("公共聊天室", "");
            listFriend.Items.Add(pub_zone);
            groupBox1.Controls.Add(pub_zone.rtboxReceive);
            pub_zone.rtboxReceive.Visible = true;
            this.rtboxReceive.Visible = false;
            listFriend.SelectedIndex = 0;
            this.current_friend = pub_zone;


            client.AddConnectionReceive += Client_AddConnectionReceive;

            // 注册好友列表事件
            client.DataFriendReceive += Client_DataFriReceive;

            /* // 注册在线人员事件
             client.DataOnlineReceive += Client_DataOnlineReceive;*/

            // 发送私聊反馈事件
            client.DataPrivate += Client_DataPrivate;

            // 私聊消息接收事件
            client.DataPrivateReceive += Client_DataPrivateReceive;

            // 群聊事件
            client.DataBroadcastReceive += Client_DataBroadcastReceive;

            //注册添加好友事件
            client.DataApplyFriend += Client_DataApplyFriend;

            // 好友结果返回
            client.DataapplyFriendoutput += Client_DataapplyFriendoutput;

            // 修改昵称事件
            client.DataUpdNickNameReceive += Client_DataUpdNickNameReceive;



            client.Send("13|");

        }

        private void Client_DataUpdNickNameReceive(object? sender, ReceiveEventArgs e)
        {
            string context = e.Text;
            // 显示接收到的数据
            Invoke(() =>
            {
                if (context == "01")
                {
                    MessageBox.Show("修改成功");
                }
                else
                {
                    MessageBox.Show("修改失败");
                }

            });
        }



        /// <summary>
        /// 事件——数据接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_DataReceive(object? sender, SocketCommon.ReceiveEventArgs e)
        {

            string context = e.Text;
            Invoke(() =>
            {
                string[] tt = context.Split("|");
                string action = tt[0];
                switch (action)
                {
                    default:
                        MessageBox.Show(context);
                        break;
                }

            });
            // 处理消息


        }


        private void Client_DataBroadcastReceive(object? sender, SocketCommon.ReceiveEventArgs e)
        {
            string context = e.Text;
            // 显示接收到的数据
            Invoke(() =>
            {
                string[] args = context.Split("|");

                FriendItem tmp = this.findPubFriend();

                if (tmp != null)
                {

                    if (this.current_friend.account != tmp.account)
                    {
                        int index = this.listFriend.Items.IndexOf(tmp);
                        tmp.un_read_msg = tmp.un_read_msg + 1;

                        this.listFriend.Items[index] = tmp;

                    }
                    tmp.rtboxReceive.AppendText(args[1] + "\r\n");

                }


            });
        }


        private FriendItem findPubFriend()
        {
            foreach (var item in this.listFriend.Items)
            {
                FriendItem fi = (FriendItem)item;
                if (fi.account == "")
                {
                    return fi;
                }
            }
            throw new Exception("系统错误");
        }
        private FriendItem findFriend(string account)
        {
            foreach (var item in this.listFriend.Items)
            {
                FriendItem fi = (FriendItem)item;
                if (fi.account == account)
                {
                    return fi;
                }
            }
            return null;
        }
        /**
         * 私聊接收消息
         */
        private void Client_DataPrivateReceive(object? sender, SocketCommon.ReceiveEventArgs e)
        {
            string context = e.Text;
            // 显示接收到的数据
            Invoke(() =>
            {
                string[] args = context.Split("|");

                FriendItem tmp = this.findFriend(args[1]); // 找到发送者账号
                if (tmp != null)
                {

                    if (this.current_friend.account != tmp.account)
                    {
                        int index = this.listFriend.Items.IndexOf(tmp);
                        tmp.un_read_msg = tmp.un_read_msg + 1;

                        this.listFriend.Items[index] = tmp;

                    }
                    tmp.rtboxReceive.AppendText(args[1] + args[2] + "\r\n");

                }
            });
        }

        /**
         * 私聊
         */
        private void Client_DataPrivate(object? sender, SocketCommon.ReceiveEventArgs e)
        {
            string code = e.Text;
            // 显示接收到的数据
            Invoke(() =>
            {
                switch (code)
                {
                    case "1":
                        MessageBox.Show("好友不存在");
                        break;
                    case "2":
                        MessageBox.Show("好友已下线");
                        break;
                    case "3":
                        MessageBox.Show("发送失败");
                        break;
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
               
                    tsslStatus.Text = "服务器已连接";
                    tspbProgress.Visible = false;
                    btnSend.Enabled = true;
               
            }
            else
            {
                // 更新状态栏显示及按钮状态
                
                    tsslStatus.Text = "正在连接服务器...";
                    tspbProgress.Visible = true;
                    btnSend.Enabled = false;
                
            }
        }

        private void Client_AddConnectionReceive(object? sender, SocketCommon.ReceiveEventArgs e)
        {
            Invoke(() =>
            {
                var result = e.Text;
                switch (result)
                {
                    case "00":
                        MessageBox.Show("用户不存在，请重试");
                        break;
                    case "01":
                        MessageBox.Show("添加成功");
                        break;
                    case "02":
                        MessageBox.Show("已经添加过");
                        break;
                    case "03":
                        MessageBox.Show("对方未在线");
                        break;
                    case "04":
                        MessageBox.Show("已经发送好友请求");
                        break;
                    case "05":
                        MessageBox.Show("不能添加自己");
                        break;
                    default:
                        MessageBox.Show("未知错误");
                        break;
                }
            });
        }

        /**
         * 接受好友请求
         * **/

        private void Client_DataApplyFriend(object? sender, SocketCommon.ReceiveEventArgs e)
        {
            string context = e.Text;
            // 显示接收到的数据
            Invoke(() =>
            {
                //MessageBox.Show("用户名或者密码不能为空", "登录提示", MessageBoxButtons.OKCancel);
                var result = MessageBox.Show(e.Text + "__用户申请加为好友，是否同意", "好友请求", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)//如果对话框的返回值是YES（按"Y"按钮）
                {
                    string message = "16|1|"+ e.Text;
                    client.Send(message);
                }
                if (result == DialogResult.Cancel)//如果对话框的返回值是NO（按"N"按钮）
                {
                    string message = "16|0"+ e.Text;
                    client.Send(message);
                }

            });
        }
        private void Client_DataapplyFriendoutput(object? sender, SocketCommon.ReceiveEventArgs e)
        {
            string context = e.Text;
            // 显示接收到的数据
            Invoke(() =>
            {
                //MessageBox.Show("用户名或者密码不能为空", "登录提示", MessageBoxButtons.OKCancel);
                string[] flags = context.Split("|");
                if (flags[1] == "1")
                {
                    MessageBox.Show("添加" + flags[2] + "用户好友成功", "好友请求");
                }
                else if (flags[1] == "0") {
                    MessageBox.Show( flags[2] + "拒绝了您的好友请求", "好友请求");
                }



            });
        }
        


        /// <summary>
        /// 事件——好友数据接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_DataFriReceive(object? sender, SocketCommon.ReceiveEventArgs e)
        {
            // 显示接收到的数据
            Invoke(() =>
            {
                List<string> temp = new List<string>();
                foreach (var item in listFriend.Items)
                {

                    FriendItem fi = (FriendItem)item;
                    temp.Add(fi.account);

                }
                string[] name_nick = e.Text.Split("|");
                if (!temp.Contains(name_nick[0]))
                {
                    FriendItem pub = new FriendItem(name_nick[0], name_nick[1]);
                    listFriend.Items.Add(pub);
                    groupBox1.Controls.Add(pub.rtboxReceive);
                }
            });
        }
        /// <summary>
        /// 事件---状态更新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
/*        private void Client_DataOnlineReceive(object? sender, SocketCommon.ReceiveEventArgs e)
        {
            // 显示接收到的数据
            Invoke(() =>
            {
                string[] userlist = e.Text.Split("|");
                var tserver = listFriend.Items;
                foreach (var item in tserver) {
                    string[] sitem = item.ToString().Split("|");
                   
                    if (Array.IndexOf(userlist,sitem[0]) >0) {
                        int index = listFriend.Items.IndexOf(item);
                        listFriend.Items[index] = sitem[0] + "|在线";
                    }
                    else if (Array.IndexOf(userlist, sitem[0]) < 0)
                    {
                        int index = listFriend.Items.IndexOf(item);
                        listFriend.Items[index] = sitem[0];
                    }
                }
            });
        }*/





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

            // 获取当前的对象
            string message = tboxSend.Text;

            // 将自己发的字符串显示在接收区

            this.current_friend.rtboxReceive.AppendText(tboxSend.Text + "\r\n");

            // 设定本人发送内容回显格式
            int index = this.current_friend.rtboxReceive.Text.LastIndexOf(tboxSend.Text);
            this.current_friend.rtboxReceive.Select(index, tboxSend.Text.Length);
            this.current_friend.rtboxReceive.SelectionColor = Color.YellowGreen;
            this.current_friend.rtboxReceive.SelectionAlignment = HorizontalAlignment.Right;
            this.current_friend.rtboxReceive.Select(this.current_friend.rtboxReceive.Text.Length, 0);
            this.current_friend.rtboxReceive.ScrollToCaret();

            Object friend = listFriend.SelectedItem;
            if (this.current_friend.account != "")
            {
                message = "05|" + clientAccount + "|" + this.current_friend.account + "|" + message;
            }
            else
            {
                message = "07|" + message;
            }

            // 发送字符串到服务器
            client.Send(message);

            // 清空发送区
            tboxSend.Clear();
        }

        /// <summary>
        /// 事件——点击清空接收区按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.current_friend.rtboxReceive.Clear();
        }


        private void btnAddFriend_Click(object sender, EventArgs e)
        {
            string find_name = tboxFriName.Text;
            this.client.Send("09|" + find_name);

        }

        private void listFriend_SelectedValueChanged(object sender, EventArgs e)
        {

            FriendItem fi = (FriendItem)listFriend.SelectedItem;

            if (fi == null || this.current_friend == null)
            {
                return;
            }


            if (fi.account == this.current_friend.account)
            {
                return;
            }

            this.current_friend.rtboxReceive.Visible = false;

            this.current_friend = fi;
            this.current_friend.rtboxReceive.Visible = true;

            int index = this.listFriend.Items.IndexOf(current_friend);
            this.current_friend.un_read_msg = 0;


            this.listFriend.Items[index] = this.current_friend;
        }

        private void updnickname_Click(object sender, EventArgs e)
        {
            string nick_name = input_nickname.Text;
            this.client.Send("11|" + nick_name);
        }
    }
}
