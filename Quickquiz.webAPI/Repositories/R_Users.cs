using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quickquiz.webAPI.Entity;
using System.Text;
using Quickquiz.webAPI.Models;
using System.Data.SqlClient;

namespace Quickquiz.webAPI.Repositories
{
    public class R_Users
    {
        private quickquizDB db = new quickquizDB();
        //get all
        public IEnumerable<v_user> R_GetUser()
        {
            return db.v_user.Where(c=> c.Status != "remove").ToList();
        }
        //get bin
        public IEnumerable<v_user> R_GetUserBin()
        {
            return db.v_user.Where(c => c.Status == "remove").ToList();
        }
        //get by id
        public Users R_GetUser(int id)
        {
            return db.Users.Where(e => e.user_id == id).FirstOrDefault();
        }
        //add user
        public Users R_AddUsers(m_AddUser NewUser)
        {
            var res = db.Database.SqlQuery<Users>("EXEC [quickquiz].[s_Adduser] @username,@password,@user_type",
            new SqlParameter("@username", NewUser.username),
            new SqlParameter("@password", Convert.ToBase64String(Encoding.UTF8.GetBytes(NewUser.password))),
            new SqlParameter("@user_type", NewUser.user_type)
            ).FirstOrDefault();
            return res;
        }
        //update user
        public Users R_UpdateUsers(int id, m_AddUser UpdateUser)
        {
            var update = db.Users.FirstOrDefault(e => e.user_id == id);
            update.username = UpdateUser.username;
            update.password = UpdateUser.password;
            update.user_type_id = UpdateUser.user_type;
            int res = db.SaveChanges();
            return res > 0 ? update : null;
        }
        //remove user
        public Users R_DeleteUser(int id)
        {
            var delete = db.Users.FirstOrDefault(x => x.user_id == id);
            var res = db.Database.ExecuteSqlCommand("update [quickquiz].Users set [status] = 'rm' where [user_id] = @user_id",
            new SqlParameter("@user_id",id));
            return res > 0 ? delete : null;
        }
        //Recovery user
        public Users R_RecoveryUser(int id)
        {
            var Recovery = db.Users.FirstOrDefault(x => x.user_id == id);
            var res = db.Database.ExecuteSqlCommand("update [quickquiz].Users set [status] = 'ac' where [user_id] = @user_id",
            new SqlParameter("@user_id", id));
            return res > 0 ? Recovery : null;
        }
        //Recovery all user
        public string R_RecoveryAllUser()
        {
            var Recovery = db.Users.Where(x => x.status.Equals("rm")).ToList();
            try
            {
                foreach (Users Recoverys in Recovery)
                {
                    var res = db.Database.ExecuteSqlCommand("update [quickquiz].Users set [status] = 'ac' where [user_id] = @user_id",
                    new SqlParameter("@user_id", Recoverys.user_id));
                }
                return "Success recovery";
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }
        //block user
        public Users R_BlockUser(int id)
        {
            var block = db.Users.FirstOrDefault(x => x.user_id == id);
            var res = db.Database.ExecuteSqlCommand("update [quickquiz].Users set [status] = 'bo' where [user_id] = @user_id",
            new SqlParameter("@user_id", id));
            return res > 0 ? block : null;
        }
        //Unblock user
        public Users R_UnblockUser(int id)
        {
            var block = db.Users.FirstOrDefault(x => x.user_id == id);
            var res = db.Database.ExecuteSqlCommand("update [quickquiz].Users set [status] = 'ac' where [user_id] = @user_id",
            new SqlParameter("@user_id", id));
            return res > 0 ? block : null;
        }
        //reset user
        public Users R_ResetUser(int id)
        {
            var reset = db.Users.FirstOrDefault(x => x.user_id == id);
            var pass = Convert.ToBase64String(Encoding.UTF8.GetBytes(reset.username));
            var res = db.Database.ExecuteSqlCommand("update [quickquiz].Users set [password]=@pass where [user_id] = @user_id",
            new SqlParameter("@user_id", id),
            new SqlParameter("@pass", pass));
            return res > 0 ? reset : null;
        }
        //verify
        public Users R_VerifyUser(m_VerifyUser input) {
            var res = db.Database.SqlQuery<Users>("EXEC [quickquiz].[s_Verify_user] @username,@firstname,@lastname,@faculty,@branch,@university",
                new SqlParameter("@username", input.username),
                new SqlParameter("@firstname", input.firstname),
                new SqlParameter("@lastname", input.lastname),
                new SqlParameter("@faculty", input.faculty),
                new SqlParameter("@branch", input.branch),
                new SqlParameter("@university", input.university)
             ).FirstOrDefault();
            return res;
        }
    }
}