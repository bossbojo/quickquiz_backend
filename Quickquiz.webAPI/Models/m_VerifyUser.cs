using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quickquiz.webAPI.Models
{
    public class m_VerifyUser
    {
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string faculty { get; set; }
        public string branch { get; set; }
        public string university { get; set; }
        public string img { get; set; }
    }
}