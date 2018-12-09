using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Controllers
{

    /* Mapeia as requisições de http://localhost:{porta}/api/persons/v1/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [Book]Controller
    e expõe como endpoint REST
    */
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BooksController : Controller
    {
        //Declaração do serviço usado
        private IBookBusiness _booksBusiness;

        /* Injeção de uma instancia de IPersonBusiness ao criar
        uma instancia de PersonController */
        public BooksController(IBookBusiness booksBusiness)
        {
            _booksBusiness = booksBusiness;
        }

        //Mapeia as requisições GET para http://localhost:{porta}/api/persons/v1/
        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_booksBusiness.FindAll());
        }

        //Mapeia as requisições GET para http://localhost:{porta}/api/persons/v1/{id}
        //recebendo um ID como no Path da requisição
        //Get com parâmetros para o FindById --> Busca Por ID
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = _booksBusiness.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        //Mapeia as requisições POST para http://localhost:{porta}/api/persons/v1/
        //O [FromBody] consome o Objeto JSON enviado no corpo da requisição
        [HttpPost]
        public IActionResult Post([FromBody]Book book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(_booksBusiness.Create(book));
        }

        //Mapeia as requisições PUT para http://localhost:{porta}/api/persons/v1/
        //O [FromBody] consome o Objeto JSON enviado no corpo da requisição
        [HttpPut]
        public IActionResult Put([FromBody]Book book)
        {
            if (book == null) return BadRequest();
            var updatedBook = _booksBusiness.Update(book);
            if (updatedBook == null) return BadRequest();
            return new ObjectResult(updatedBook);
            
        }


        //Mapeia as requisições DELETE para http://localhost:{porta}/api/persons/v1/{id}
        //recebendo um ID como no Path da requisição
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _booksBusiness.Delete(id);
            return NoContent();

        }
    }
}