using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Quickquiz.webAPI.Models;
using Quickquiz.webAPI.Repositories;
using Quickquiz.webAPI.Authen;

namespace Quickquiz.webAPI.Controllers
{
    
    public class CreateQuizController : ApiController
    {
        private R_CreateQuiz _CreateQuiz = new R_CreateQuiz();


        [Route("api/create/quiz/code")]
        public IHttpActionResult CreateQuiz([FromBody] m_CreateCode value)
        {
            try {
                var User = Authentication.User;
                var res = _CreateQuiz.CreateCode(value.quick_name,User.user_id);
                if (res) {
                    return Json("Success for created.");
                }
                return BadRequest("Failed for create.");
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }   
        }
    }
}
