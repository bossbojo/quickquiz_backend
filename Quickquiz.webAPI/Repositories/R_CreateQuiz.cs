using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quickquiz.webAPI.Entity;
using Quickquiz.webAPI.Models;
using System.Text;
using System.Data.SqlClient;

namespace Quickquiz.webAPI.Repositories
{
    public class R_CreateQuiz
    {
        private quickquizDB db = new quickquizDB();
        //----quiz
        public Code_quiz CreateCode(string quick_name,int user_id) {
            int length = 10;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder code_new = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                code_new.Append(valid[rnd.Next(valid.Length)]);
            }
            var code_ = code_new.ToString().Substring(0, 10).ToUpper();
            var res = db.Database.SqlQuery<Code_quiz>("EXEC [quickquiz].[s_Code_quiz_Create] @user_id,@quick_name,@code", 
                new SqlParameter("@user_id",user_id),
                new SqlParameter("@quick_name", quick_name),
                new SqlParameter("@code", code_)
            ).FirstOrDefault();
            return res;
        }
        public Code_quiz UpdateCode(string quick_name, int code_id)
        {
            var res = db.Database.SqlQuery<Code_quiz>("EXEC [quickquiz].[s_Code_quiz_Update] @code_id,@quick_name",
                new SqlParameter("@code_id", code_id),
                new SqlParameter("@quick_name", quick_name)
            ).FirstOrDefault();
            return res;
        }
        public Code_quiz RemoveCode(int code_id)
        {
            var res = db.Database.SqlQuery<Code_quiz>("EXEC [quickquiz].[s_Code_quiz_Remove] @code_id",
                new SqlParameter("@code_id", code_id)
            ).FirstOrDefault();
            return res;
        }
        //---Question
        public Question CreateQuestion(int code_id,string img,string question,int user_id)
        {
            var res = db.Database.SqlQuery<Question>("EXEC [quickquiz].[s_Question_Create] @code_id,@img,@question,@user_id",
                new SqlParameter("@code_id", code_id),
                new SqlParameter("@img", img),
                new SqlParameter("@question", question),
                new SqlParameter("@user_id", user_id)
            ).FirstOrDefault();
            return res;
        }
        public Question UpdateQuestion(int q_id, int code_id, string img, string question, int user_id)
        {
            var res = db.Database.SqlQuery<Question>("EXEC [quickquiz].[s_Question_Update] @q_id,@code_id,@img,@question,@user_id",
                new SqlParameter("@q_id", q_id),
                new SqlParameter("@code_id", code_id),
                new SqlParameter("@img", img),
                new SqlParameter("@question", question),
                new SqlParameter("@user_id", user_id)
            ).FirstOrDefault();
            return res;
        }
        public Question RemoveQuestion(int q_id)
        {
            var res = db.Database.SqlQuery<Question>("EXEC [quickquiz].[s_Question_Remove] @q_id",
                new SqlParameter("@q_id", q_id)
            ).FirstOrDefault();
            return res;
        }
        //---Answers
        public Answers CreateAnswers(int q_id, string answer, bool correct)
        {
            var res = db.Database.SqlQuery<Answers>("EXEC [quickquiz].[s_Answers_Create] @q_id,@answer,@correct",
                new SqlParameter("@q_id", q_id),
                new SqlParameter("@answer", answer),
                new SqlParameter("@correct", correct)
            ).FirstOrDefault();
            return res;
        }
        public Answers UpdateAnswers(int a_id,int q_id, string answer, bool correct)
        {
            var res = db.Database.SqlQuery<Answers>("EXEC [quickquiz].[s_Answers_Update] @a_id,@q_id,@code_id,@img,@question,@user_id",
                new SqlParameter("@a_id", q_id),
                new SqlParameter("@q_id", q_id),
                new SqlParameter("@answer", answer),
                new SqlParameter("@correct", correct)
            ).FirstOrDefault();
            return res;
        }
        public Answers RemoveAnswers(int a_id)
        {
            var res = db.Database.SqlQuery<Answers>("EXEC [quickquiz].[s_Answers_Remove] @a_id",
                new SqlParameter("@a_id", a_id)
            ).FirstOrDefault();
            return res;
        }
    }
}