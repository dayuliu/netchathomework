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
        public  FriendItem(string nickname,string account) { 
        
            this.nickname = nickname;
            this.account = account;
            this.rtboxReceive = new RichTextBox();
            rtboxReceive.BackColor = Color.WhiteSmoke;
            rtboxReceive.BorderStyle = BorderStyle.None;
            rtboxReceive.ForeColor = Color.RoyalBlue;
            rtboxReceive.Location = new Point(17, 26);
            rtboxReceive.Margin = new Padding(4, 4, 4, 4);
            rtboxReceive.Name = "rtboxReceive";
            rtboxReceive.ReadOnly = true;
            rtboxReceive.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtboxReceive.Size = new Size(456, 296);
            rtboxReceive.TabIndex = 1;
            rtboxReceive.Text = "";

        }    
        public string nickname { get; set; }
        public string account { get; set; }

        public override string ToString()
        {
            return nickname;
        }
    }
}
