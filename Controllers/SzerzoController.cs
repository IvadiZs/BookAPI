using BookAPI.Models;
using BookAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BookAPI.Models.DTOs.DTOs;

namespace BookAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SzerzoController : ControllerBase {

        private readonly SzerzoInterface szerzoInterface;

        public SzerzoController(SzerzoInterface szerzoInterface) {
            this.szerzoInterface = szerzoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Szerzo>>> Get() {
            var szerzok = await szerzoInterface.Get();

            if (szerzok == null || !szerzok.Any())
                return NotFound();

            return Ok(szerzok);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Szerzo>> Get(Guid id) {
            var szerzo = await szerzoInterface.GetById(id);

            if (szerzo == null)
                return NotFound();

            return szerzo;
        }

        [HttpPost]
        public async Task<ActionResult<Szerzo>> Post(SzerzoCreatedDTO createDTO) {

            return StatusCode(201, await szerzoInterface.Post(createDTO));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Szerzo>> Put(Guid id, SzerzoUpdateDTO updateDTO) {
            var szerzo = await szerzoInterface.Put(id, updateDTO);

            if (szerzo == null)
                return NotFound();

            return szerzo;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Szerzo>> Delete(Guid id) {
            var szerzo = await szerzoInterface.DeleteById(id);

            if (szerzo == null)
                return NotFound();

            return szerzo;
        }
    }
}
