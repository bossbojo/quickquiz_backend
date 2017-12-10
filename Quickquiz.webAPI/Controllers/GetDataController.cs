using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Quickquiz.webAPI.Repositories;
namespace Quickquiz.webAPI.Controllers
{
    public class GetDataController : ApiController
    {
        private R_GetData _GetData = new R_GetData();
        [HttpGet]
        [Route("api/get/data/all/university")]
        public IHttpActionResult GetDataUniversity()
        {
            return Json(_GetData.GetUniversity());
        }
        [HttpGet]
        [Route("api/get/data/all/faculty")]
        public IHttpActionResult GetDataFaculty()
        {
            return Json(_GetData.GetFaculty());
        }
        [HttpGet]
        [Route("api/get/data/all/major")]
        public IHttpActionResult GetDataMajor()
        {
            return Json(_GetData.GetMajor());
        }
    }
}
