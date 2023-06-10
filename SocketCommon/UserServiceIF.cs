using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketCommon
{
    internal interface UserServiceIF
    {
        // 设置昵称
        public string updateNickname(string username, string nickname);

        // 注册
        public string register(string username, string nickname, string password, Socket s);

        // 登录
        public string login(string username, string nickname, string password, Socket s);

        // TODO 添加好友
        // TODO查找好友

    }
}
