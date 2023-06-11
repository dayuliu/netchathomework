using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerClinet
{
    internal class FriendItem
    {
        public RichTextBox rtboxReceive;


        public string nickname { get; set; }
        public string account { get; set; }


        public int un_read_msg = 0;

        public  FriendItem(string nickname,string account) { 
        
            this.nickname = nickname;
            this.account = account;
            rtboxReceive = new RichTextBox();
            rtboxReceive.BackColor = Color.WhiteSmoke;
            rtboxReceive.BorderStyle = BorderStyle.None;
            rtboxReceive.ForeColor = Color.RoyalBlue;
            rtboxReceive.Location = new Point(17, 26);
            rtboxReceive.Margin = new Padding(4, 4, 4, 4);
            rtboxReceive.Name = account;
            rtboxReceive.ReadOnly = true;
            rtboxReceive.Visible = false;
            rtboxReceive.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtboxReceive.Size = new Size(456, 296);
            rtboxReceive.TabIndex = 1;
            rtboxReceive.Text = "";
            rtboxReceive.Visible = false;

        }    


        public override string ToString()
        {
            string res = "昵称:" + nickname;
            if (account != "")
            {
                res = "昵称:" + nickname;
                res = res + "|" + account;

            } else
            {
                res =  nickname;
            }

            if (this.un_read_msg > 0)
                res = res + "|未读消息:" + this.un_read_msg.ToString();

            return res;
        }
    }
}
