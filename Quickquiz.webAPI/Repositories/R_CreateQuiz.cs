using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quickquiz.webAPI.Entity;
using Quickquiz.webAPI.Models;

namespace Quickquiz.webAPI.Repositories
{
    public class R_CreateQuiz
    {
        private quickquizDB db = new quickquizDB();

        public bool CreateCode(string quick_name,int user_id) {
            Guid Code = new Guid();
            var res = db.Code_quiz.Add(new Code_quiz {
                quick_name = quick_name,
                user_id = user_id,
                count_quiz = 0,
                code = Code.ToString().Substring(0, 5).ToUpper()
            });
            int result = db.SaveChanges();
            return result > 0 ? true : false;

        }
    }
}