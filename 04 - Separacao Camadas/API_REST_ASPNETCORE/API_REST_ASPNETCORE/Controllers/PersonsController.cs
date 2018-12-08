
using API_REST_ASPNETCORE.Business;
using API_REST_ASPNETCORE.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_REST_ASPNETCORE.Controllers
{    
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonsController : Controller
    {

        private IPersonBusiness _personBusiness;

        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        // GET api/persons
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        // GET api/persons/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(long id)
        {
            var person = _personBusiness.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/persons
        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personBusiness.Create(person));
        }

        // PUT api/persons/5
        [HttpPut]
        public ActionResult Put(int id, [FromBody]  Person person)
        {
            if (person == null) return BadRequest();
            var updatePerson = _personBusiness.Update(person);
            if (updatePerson == null) return BadRequest();
            return new ObjectResult(updatePerson);
        }

        // DELETE api/persons/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}


//using API_REST_ASPNETCORE.Business;
//using API_REST_ASPNETCORE.Model;
//using Microsoft.AspNetCore.Mvc;

//namespace API_REST_ASPNETCORE.Controllers
//{
//    [ApiVersion("1")]
//    [Route("api/[controller]")]
//    public class PersonsController : Controller
//    {

//        private IPersonBusiness _personBusiness;

//        public PersonsController(IPersonBusiness personBusiness)
//        {
//            _personBusiness = personBusiness;
//        }

//        // GET api/persons
//        [HttpGet("v1")]
//        public ActionResult Get()
//        {
//            return Ok(_personBusiness.FindAll());
//        }

//        // GET api/persons/5
//        [HttpGet("v1/{id}")]
//        public ActionResult<string> Get(long id)
//        {
//            var person = _personBusiness.FindByID(id);
//            if (person == null) return NotFound();
//            return Ok(person);
//        }

//        // POST api/persons
//        [HttpPost("v1")]
//        public ActionResult Post([FromBody] Person person)
//        {
//            if (person == null) return BadRequest();
//            return new ObjectResult(_personBusiness.Create(person));
//        }

//        // PUT api/persons/5
//        [HttpPut("v1")]
//        public ActionResult Put(int id, [FromBody]  Person person)
//        {
//            if (person == null) return BadRequest();
//            return new ObjectResult(_personBusiness.Update(person));
//        }

//        // DELETE api/persons/5
//        [HttpDelete("v1/{id}")]
//        public ActionResult Delete(int id)
//        {
//            _personBusiness.Delete(id);
//            return NoContent();
//        }
//    }
//}




