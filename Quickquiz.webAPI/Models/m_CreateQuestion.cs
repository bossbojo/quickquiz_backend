using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quickquiz.webAPI.Models
{
    public class m_CreateQuestion
    {
        public int code_id { get; set; }
        public string img { get; set; }
        public string question { get; set; }
        public int user_id { get; set; }
    }
}