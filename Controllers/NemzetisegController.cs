using BookAPI.Models;
using BookAPI.Models.DTOs;
using BookAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BookAPI.Models.DTOs.DTOs;

namespace BookAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class NemzetisegController : ControllerBase {

        private readonly NemzetisegInterface nemzetisegInterface;

        public NemzetisegController(NemzetisegInterface nemzetisegInterface) {
            this.nemzetisegInterface = nemzetisegInterface;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nemzetiseg>>> Get() {
            var nemzetisegek = await nemzetisegInterface.Get();

            if (nemzetisegek == null || !nemzetisegek.Any())
                return NotFound();

            return Ok(nemzetisegek);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Nemzetiseg>> Get(Guid id) {
            var nemzetiseg = await nemzetisegInterface.GetById(id);

            if (nemzetiseg == null)
                return NotFound();

            return Ok(nemzetiseg);
        }

        [HttpPost]
        public async Task<ActionResult<Nemzetiseg>> Post(NemzetisegCreatedDTO createDTO) {

            return StatusCode(201, await nemzetisegInterface.Post(createDTO));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Nemzetiseg>> Put(Guid id, NemzetisegUpdateDTO updateDTO) {
            var nemzetiseg = await nemzetisegInterface.Put(id, updateDTO);

            if (nemzetiseg == null)
                return NotFound();

            return Ok(nemzetiseg);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Nemzetiseg>> Delete(Guid id) {
            var nemzetiseg = await nemzetisegInterface.DeleteById(id);

            if (nemzetiseg == null)
                return NotFound();

            return Ok(nemzetiseg);
        }
    }
}
