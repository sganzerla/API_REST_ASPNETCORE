 
using API_REST_ASPNETCORE.Model;
using API_REST_ASPNETCORE.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace API_REST_ASPNETCORE.Controllers
{
    [ApiVersion("1")]   
    [Route("api/v{version:apiVersion}/[controller]")]   
    public class PersonsController : ControllerBase
    {
      
        private IPersonService _personService;

        public PersonsController(IPersonService personService )
        {
            _personService = personService;
        }

        // GET api/persons
        [HttpGet]
        public ActionResult  Get()
        {
            return Ok(_personService.FindAll());
        }

        // GET api/persons/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(long id)
        {
            var person = _personService.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/persons
        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Create(person));
        }

        // PUT api/persons/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]  Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Update(person));
        }

        // DELETE api/persons/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
