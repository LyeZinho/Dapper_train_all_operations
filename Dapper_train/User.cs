using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dapper_train
{
    public class User
    {
        public string Username { get; set; }
        public String Email { get; set; }

        public User()
        {
            Email = "";
            Username = "";
        }

        public User(string username, string email)
        {
            this.Username = username;
            this.Email = email;
        }
    }

}
