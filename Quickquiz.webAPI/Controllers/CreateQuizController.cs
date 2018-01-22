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
        [HttpPost]
        [Route("api/create/question")]
        public IHttpActionResult CreateQuestion([FromBody] m_CreateQuestion value) {
            try
            {
                var res = _CreateQuiz.CreateQuestion(value.code_id,value.img,value.question,value.user_id);
                if (res != null)
                {
                    return Json("Success for Created.");
                }
                return BadRequest("Failed for Create.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("api/update/question")]
        public IHttpActionResult UpdateQuestion([FromBody] m_CreateQuestion value,int q_id)
        {
            try
            {
                var res = _CreateQuiz.UpdateQuestion(q_id,value.code_id, value.img, value.question, value.user_id);
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
        [Route("api/update/question")]
        public IHttpActionResult RemoveQuestion(int q_id)
        {
            try
            {
                var res = _CreateQuiz.RemoveQuestion(q_id);
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
        //------------------Answers----------------------------------
        [HttpPost]
        [Route("api/create/answers")]
        public IHttpActionResult CreateAnswers([FromBody] m_CreateAnswers value)
        {
            try
            {
                var res = _CreateQuiz.CreateAnswers(value.q_id,);
                if (res != null)
                {
                    return Json("Success for Created.");
                }
                return BadRequest("Failed for Create.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("api/update/answers")]
        public IHttpActionResult UpdateAnswers([FromBody] m_CreateAnswers value, int a_id)
        {
            try
            {
                var res = _CreateQuiz.UpdateAnswers(a_id,value.q_id,value.answer,value.correct);
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
        [Route("api/update/answers")]
        public IHttpActionResult RemoveAnswers(int a_id)
        {
            try
            {
                var res = _CreateQuiz.RemoveAnswers(a_id);
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
    }
}
