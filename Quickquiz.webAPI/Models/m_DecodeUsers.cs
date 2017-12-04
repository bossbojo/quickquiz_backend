using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quickquiz.webAPI.Models
{
    public class m_DecodeUsers
    {
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int status { get; set; }
        public long exp { get; set; }
    }
}