using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quickquiz.webAPI.Entity;
using System.Text;

namespace Quickquiz.webAPI.Repositories
{
    public class R_Authentication
    {
        private quickquizDB db = new quickquizDB();
        public bool Check_HaveUser(string username) {
            var res = db.Users.Where(c => c.username.Equals(username)).Count();
            return res > 0? true:false;
        }
        public bool Check_Verify(string username)
        {
            var res = db.Users.Where(c => c.username.Equals(username)).FirstOrDefault();
            if (res.verify)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Users Check_Signin(string username, string password)
        {
            var encode = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
            var res = db.Users.Where(c => c.username.Equals(username)&&c.password.Equals(encode)).FirstOrDefault();
            return res;
        }

    }
}