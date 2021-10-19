using System;
using System.Collections.Generic;
using System.Text;

namespace MTJatinMahajan
{
    class UserLogin
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public UserLogin(int id,string name,string pass)
        {
            this.id = id;
            this.password = pass;
            this.username = name;
        }
    }
}
