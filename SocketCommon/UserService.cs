using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace SocketCommon
{
    public class UserService : UserServiceIF
    {


        private Dictionary<string, User> userRepo = new Dictionary<string, User>(); // 用户仓库


        public string register(string username, string nickname,string password, Socket s) 
        {
            if (userRepo.ContainsKey(username))
            {
                return "用户已经存在";
            }
            userRepo.Add(username, new User(username, nickname, password, s));

            return "success";
        }

        public string login(string username, string nickname, string password, Socket s)
        {

            if (!userRepo.ContainsKey(username))
            {
                return "用户不存在";
            }

            User user = userRepo[username];
            if (user.verifyPassword(password))
            {
                return "登录成功";
            }else
            {
                return "失败";
            }
        }

        public string updateNickname(string username,string nickname)
        {
            // todo 实现
            return "失败";
        }
    }
}
