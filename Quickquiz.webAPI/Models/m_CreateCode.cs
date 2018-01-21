using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quickquiz.webAPI.Models
{
    public class m_CreateCode
    {
        public string quick_name { get; set; }
        public int user_id { get; set; }
    }
    public class m_UpdateCode
    {
        public string quick_name { get; set; }
        public int code_id { get; set; }
    }
}