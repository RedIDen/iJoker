using Microsoft.AspNetCore.Mvc;

namespace iJoker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JokesController : ControllerBase
    {
        private readonly ILogger<JokesController> _logger;
        private readonly Random _random = new();
        private readonly List<Joke> _jokes = new List<Joke>
            {
                new Joke { Author = "Корч", Text = "Молодая учительница:\r\n- Pебята, если кто-нибудь из вас скажет, какая из моих частей тела ему больше всего нравится, я смогу ему сказать, кем он станет, когда вырастет. Вот тебе, Ванечка, что во мне больше всего нравится?\r\n- Ваши волосы, Марь Иванна.\r\n- Значит, ты будешь парикмахером. А тебе, Петенька?\r\n- Ваши глаза, Марь Иванна.\r\n- Понятно, ты станешь окулистом. А тебе, Мишенька?\r\n- Мне нравятся ваши зубы, Марь Иванна.\r\n- Ясно, стоматологом будешь.\r\nИ так далее.\r\nВовочка стал курильщиком.", CreationTime = DateTime.Now.AddDays(-3) },
                new Joke { Author = "Базон", Text = "Крутой джазовый бар проводит конкурс на лучшего исполнителя, которого возьмут на работу. Собирается толпа музыкантов и среди них старый негр.\r\nВыходит и говорит:\r\n— Эта песня называется \"Я буду дрочить на тебя всю ночь!\"\r\nИграет восхитительный блюз, после которого половина музыкантов сразу собираются и уходят, другие просто плачут от восторга!\r\nСтарый негр говорит:\r\n— А следующая моя песня называется \"Соси у меня, сука, пока я не кончу!\"\r\nИ играет блюз еще круче от которого оставшиеся музыканты единогласно отказываются от участия в конкурсе.\r\nВладелец заведения говорит\r\n— Мы вас берем, только не могли бы вы не называть своих песен, а они немного… нуу... шокируют.\r\nНегр соглашается.\r\nИдет очередной концерт, негр забыл заправиться, и у него елда торчит из штанов. Он садится за рояль, играет. Хозяин заведения замечает эту оплошность, подходит к нему, говорит:\r\n— У тебя хуй видно, знаешь?\r\nНегр:\r\n— Что? Знаю ли я её?! Да я её написал!", CreationTime = DateTime.Now.AddDays(-23).AddMinutes(364) },
            };

        public JokesController(ILogger<JokesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Joke>> GetAll()
        {
            return StatusCode(StatusCodes.Status200OK, _jokes.Select(x => new
            {
                author = x.Author,
                text = x.Text,
                creationTime = x.CreationTime.ToShortTimeString(),
                likes = this._random.Next(50),
            }).OrderByDescending(x => x.likes));
        }

        public class Joke
        {
            public string? Author { get; set; }

            public string? Text { get; set; }

            public DateTime CreationTime { get; set; }
        }
    }
}