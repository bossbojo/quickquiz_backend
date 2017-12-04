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
            if (ModelState.IsValid)
            {
                if (_Anthen.Check_HaveUser(value.username))
                {
                    if (_Anthen.Check_Verify(value.username))
                    {
                        var user = _Anthen.Check_Signin(value.username, value.password);
                        if (user != null)
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
        [HttpPost]
        [Route("api/verify")]
        public IHttpActionResult Verify([FromBody] m_VerifyUser value)
        {
            if (ModelState.IsValid)
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
                return Json("Fail verify: model incorrent");
            }
        }
    }
}
