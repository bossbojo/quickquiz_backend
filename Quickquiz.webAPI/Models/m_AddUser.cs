using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quickquiz.webAPI.Models
{
    public class m_AddUser
    {
        public string username { get; set; }
        public string password { get; set; }
        public int user_type { get; set; }
    }
}