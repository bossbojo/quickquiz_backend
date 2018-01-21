using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Quickquiz.webAPI.Repositories;
using Quickquiz.webAPI.Models;
using Quickquiz.webAPI.Authen;

namespace Quickquiz.webAPI.Controllers
{
    public class SigninController : ApiController
    {
        //use repository
        private R_Authentication _Anthen = new R_Authentication();
        private R_Users _User = new R_Users();

        //api route
        [JWTAuthorize]
        [Route("api/Authentication")]
        public IHttpActionResult GetAuthen()
        {
            var user = Authentication.User;
            return Json(new
            {
                Token = Authentication.Token,
                Detail = new
                {
                    user_id = user.user_id,
                    username = user.username,
                    firstname = user.firstname,
                    lastname = user.lastname,
                    status = user.user_type_id
                }
            });
        }
        [HttpPost]
        [Route("api/signin")]
        public IHttpActionResult Signin([FromBody] m_Signin value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_Anthen.Check_HaveUser(value.username))
                    {
                        if (_Anthen.Check_Verify(value.username))
                        {
                            var user = _Anthen.Check_Signin(value.username, value.password);
                            if (user != null)
                            {
                                if (user.status.Equals("ac"))
                                {
                                    var authen = Authentication.SetAuthenticated(user);
                                    var res = Json(new
                                    {
                                        Token = authen,
                                        Detail = new
                                        {
                                            user_id = user.user_id,
                                            username = user.username,
                                            firstname = user.firstname,
                                            lastname = user.lastname,
                                            status = user.user_type_id
                                        }
                                    });
                                    return res;
                                }
                                else
                                {
                                    if (user.status.Equals("bo")) return Json("Fail signin: this user blocked");
                                    if (user.status.Equals("rm")) return Json("Fail signin: this user removed");
                                    return Json("Fail signin: this user have status " + user.status);
                                }
                            }
                            else
                            {
                                return Json("Fail signin: password incorrent");
                            }
                        }
                        else
                        {
                            return Json("Not Verify");
                        }

                    }
                    else
                    {
                        return Json("Fail signin: username incorrent");
                    }
                }
                else
                {
                    return Json("Fail signin: model incorrent");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }
        [HttpPost]
        [Route("api/verify")]
        public IHttpActionResult Verify([FromBody] m_VerifyUser value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _User.CheckAddUserByTeacher(value.username);
                    if (user == null)
                    {
                        var verify = _User.R_VerifyUser(value);
                        if (verify != null)
                        {
                            return Json(verify);
                        }
                        else
                        {
                            return Json("Fail verify");
                        }
                    }
                    else
                    {
                        var verify = _User.R_VerifyUserByTeacher(value);
                        if (verify != null)
                        {
                            return Json(verify);
                        }
                        else
                        {
                            return Json("Fail verify");
                        }
                    }
                }
                else
                {
                    return Json("Fail verify: model incorrent");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
