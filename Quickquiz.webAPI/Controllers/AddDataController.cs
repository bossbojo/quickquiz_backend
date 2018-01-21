using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Quickquiz.webAPI.Models;
using Quickquiz.webAPI.Repositories;
namespace Quickquiz.webAPI.Controllers
{
    public class AddDataController : ApiController
    {
        private R_AddData _AddData = new R_AddData();
        [HttpPost]
        [Route("api/add/data/university")]
        public IHttpActionResult AddUniversity(m_addUniversity request) {
            try
            {
                return Json(_AddData.addUniversity(request));
            }
            catch (Exception ex) {
                return Json(ex.Message);
            }
        }
        [HttpPost]
        [Route("api/add/data/faculty")]
        public IHttpActionResult AddFaculty(m_addFaculty request)
        {
            try
            {
                return Json(_AddData.addFaculty(request));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpPost]
        [Route("api/add/data/major")]
        public IHttpActionResult AddMajor(m_addMajor request)
        {
            try
            {
                return Json(_AddData.addMajor(request));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
