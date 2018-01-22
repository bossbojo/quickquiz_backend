using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quickquiz.webAPI.Models
{
    public class m_CreateAnswers
    {
        public int q_id { get; set; }
        public string answer { get; set; }
        public bool correct { get; set; }
    }
}