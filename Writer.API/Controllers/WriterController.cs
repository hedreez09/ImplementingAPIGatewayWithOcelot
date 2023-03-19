using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Writer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WriterController : ControllerBase
    {
        private readonly IWriterRepository _writerRepository;

        public WriterController(IWriterRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_writerRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var writer = _writerRepository.Get(id);

            if (writer is null)
                return NotFound();

            return Ok(writer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Models.Writer writer)
        {
            var result = _writerRepository.Insert(writer);

            return Created($"/get/{result.Id}", result);
        }
    }
}