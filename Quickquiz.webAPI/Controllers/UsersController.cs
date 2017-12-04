using Quickquiz.webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Quickquiz.webAPI.Models;

namespace Quickquiz.webAPI.Controllers
{
    public class UsersController : ApiController
    {
        private R_Users _User = new R_Users();
        private R_Authentication _Anthen = new R_Authentication();
        [HttpGet]
        [Route("api/get/user")]
        public IHttpActionResult GetUser()
        {
            //get user
            return Json(_User.R_GetUser());
        }
        [HttpGet]
        [Route("api/get/user/remove")]
        public IHttpActionResult GetUserRemove()
        {
            //get user
            return Json(_User.R_GetUserBin());
        }
        [HttpGet]
        [Route("api/get/user")]
        public IHttpActionResult GetUser(int id)
        {
            //get user by id
            return Json(_User.R_GetUser(id));
        }
        [HttpDelete]
        [Route("api/remove/user")]
        public IHttpActionResult RemoveUser(int id) {
            var res = _User.R_DeleteUser(id);
            if (res != null) {
                return Json("Success for remove");
            }
            return Json("Failed for remove");
        }
        [HttpGet]
        [Route("api/block/user")]
        public IHttpActionResult BlockUser(int id)
        {
            var res = _User.R_BlockUser(id);
            if (res != null)
            {
                return Json("Success for block");
            }
            return Json("Failed for block");
        }
        [HttpGet]
        [Route("api/unblock/user")]
        public IHttpActionResult UnblockUser(int id)
        {
            var res = _User.R_UnblockUser(id);
            if (res != null)
            {
                return Json("Success for unblock");
            }
            return Json("Failed for unblock");
        }
        [HttpGet]
        [Route("api/recovery/user")]
        public IHttpActionResult RecoveryUser(int id)
        {
            var res = _User.R_RecoveryUser(id);
            if (res != null)
            {
                return Json("Success for recovery");
            }
            return Json("Failed for recovery");
        }
        [HttpGet]
        [Route("api/recovery/user/all")]
        public IHttpActionResult RecoveryAllUser()
        {
            var res = _User.R_RecoveryAllUser();
            return Json(res);
        }
        [HttpGet]
        [Route("api/reset/user")]
        public IHttpActionResult ResetUser(int id)
        {
            var res = _User.R_ResetUser(id);
            if (res != null)
            {
                return Json("Success for reset");
            }
            return Json("Failed for reset");
        }
        [HttpPost]
        [Route("api/add/user")]
        public IHttpActionResult AddUser(m_AddUser request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!_Anthen.Check_HaveUser(request.username))//check user have in database
                    {
                        var adduser = _User.R_AddUsers(request); //add user to databbase
                        if (adduser != null)//if user add success
                        {
                            return Json(new { newUser = adduser });
                        }
                        else//if user add fail
                        {
                            return Json("Fail add user.");
                        }
                    }
                    else
                    {
                        return Json("Have this user in database.");
                    }

                }
                catch (Exception ex)
                {
                    return Json(ex.Message);
                }

            }
            else
            {
                return Json("This field is required.");
            }
        }
    }
}
