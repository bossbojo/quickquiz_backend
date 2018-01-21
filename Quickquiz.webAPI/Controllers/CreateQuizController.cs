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

        //------------------quiz----------------------------------
        
        [Route("api/create/quiz/code")]
        public IHttpActionResult CreateQuiz([FromBody] m_CreateCode value)
        {
            try {
                var res = _CreateQuiz.CreateCode(value.quick_name,value.user_id);
                if (res!=null) {
                    return Json("Success for created.");
                }
                return BadRequest("Failed for create.");
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }   
        }
        [Route("api/update/quiz/code")]
        public IHttpActionResult UpdateQuiz([FromBody] m_UpdateCode value)
        {
            try
            {
                var res = _CreateQuiz.UpdateCode(value.quick_name, value.code_id);
                if (res != null)
                {
                    return Json("Success for updated.");
                }
                return BadRequest("Failed for update.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("api/remove/quiz/code")]
        public IHttpActionResult RemoveQuiz(int value)
        {
            try
            {
                var res = _CreateQuiz.RemoveCode(value);
                if (res != null)
                {
                    return Json("Success for removed.");
                }
                return BadRequest("Failed for remove.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //------------------Question----------------------------------

        //------------------Answers----------------------------------
    }
}
