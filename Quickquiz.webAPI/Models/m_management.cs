using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quickquiz.webAPI.Models
{
    public class m_management
    {
    }
    public class m_addUniversity {
        public string FullWord { get; set; }
        public string Abbreviation { get; set; }
    }
    public class m_addFaculty
    {
        public string FullWord { get; set; }
        public string Abbreviation { get; set; }
    }
    public class m_addMajor
    {
        public string FullWord { get; set; }
        public string Abbreviation { get; set; }
        public string Faculty { get; set; }
    }
}