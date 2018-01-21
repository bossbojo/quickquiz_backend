using Quickquiz.webAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quickquiz.webAPI.Models;
using System.Data.SqlClient;

namespace Quickquiz.webAPI.Repositories
{
    public class R_AddData
    {
        private quickquizDB db = new quickquizDB();
        public bool addUniversity(m_addUniversity value) {
            var res = db.Database.ExecuteSqlCommand("EXEC [quickquiz].[s_addUniversity] @FullWord,@Abbreviation",
            new SqlParameter("@FullWord", value.FullWord),
            new SqlParameter("@Abbreviation", value.Abbreviation)
            );
            return res > 0 ? true : false;
        }
        public bool addFaculty(m_addFaculty value)
        {
            var res = db.Database.ExecuteSqlCommand("EXEC [quickquiz].[s_addFaculty] @FullWord,@Abbreviation",
            new SqlParameter("@FullWord", value.FullWord),
            new SqlParameter("@Abbreviation", value.Abbreviation)
            );
            return res > 0 ? true : false;
        }
        public bool addMajor(m_addMajor value)
        {
            var res = db.Database.ExecuteSqlCommand("EXEC [quickquiz].[s_addMajor] @FullWord,@Abbreviation,@Faculty",
            new SqlParameter("@FullWord", value.FullWord),
            new SqlParameter("@Abbreviation", value.Abbreviation),
            new SqlParameter("@Faculty", value.Faculty)
            );
            return res > 0 ? true : false;
        }
    }
}