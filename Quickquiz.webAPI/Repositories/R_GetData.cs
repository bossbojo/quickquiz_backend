using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quickquiz.webAPI.Entity;
namespace Quickquiz.webAPI.Repositories
{
    public class R_GetData
    {
        private quickquizDB db = new quickquizDB();

        public IEnumerable<D_University> GetUniversity() {
            return db.D_University;
        }
        public IEnumerable<D_Faculty> GetFaculty()
        {
            return db.D_Faculty;
        }
        public IEnumerable<D_Major> GetMajor()
        {
            return db.D_Major;
        }
    }
}