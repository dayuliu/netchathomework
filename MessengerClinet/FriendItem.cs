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

    }    
        public string nickname { get; set; }
        public string account { get; set; }

        public override string ToString()
        {
            return nickname;
        }
    }
}
