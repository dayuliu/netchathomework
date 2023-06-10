using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace SocketCommon
{
    internal class User
    {
        public User(string username, string nickname, string password, Socket s) {

            this.username = username;  
            this.nickname = nickname;
            this.password = password;
            this.socket = s;
            
        }

        public string username;
        public string nickname;


        public Socket socket;

        public string password;


        public bool verifyPassword(string inputPassword)
        {

            return this.password == inputPassword;

        }

    }
}
