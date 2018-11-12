using Lesson_8_kotenko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lesson_8_kotenko.Controllers
{
    public class UserController : ApiController
    {
        
        private DataPeople data = new DataPeople();


        [Route("getlist")]
        public List<Employee> Get()
        {
            return data.GetList();
        }

        [Route("getlist/{id}")]
        public Employee Get(int id)
        {
            return data.GetPeopleId(id);
        }

        [Route("addpeople")]
        public HttpResponseMessage Post([FromBody]Employee value)
        {
            if (data.AddPeople(value))
                return Request.CreateResponse(HttpStatusCode.Created);
            else return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
