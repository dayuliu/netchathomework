using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SocketCommon
{

    // 通信协议
    internal interface ImIF
    {

        // 给用户发消息
        public void sendMessageToUser(User usera, User userb, string msg);

        public void sendRegisterMsg(User u);
        public void sendLoginMsg(User u);

        public void sendUpdateNickNameMsg(User u);




    }
}
