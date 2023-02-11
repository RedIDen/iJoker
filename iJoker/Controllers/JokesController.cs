using iJoker.DataAccess;
using iJoker.Service;
using Microsoft.AspNetCore.Mvc;

namespace iJoker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JokesController : ControllerBase
    {
        private readonly IJokesService _service;

        public JokesController(IJokesService service)
        {
            this._service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Joke>> GetAll()
        {
            return StatusCode(StatusCodes.Status200OK, this._service.GetAllJokes());
        }

        public class Joke
        {
            public string? Author { get; set; }

            public string? Text { get; set; }

            public DateTime CreationTime { get; set; }
        }
    }
}