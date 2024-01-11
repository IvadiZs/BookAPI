using BookAPI.Models;
using BookAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BookAPI.Models.DTOs.DTOs;

namespace BookAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class KonyvController : ControllerBase {

        private readonly KonyvInterface konyvInterface;

        public KonyvController(KonyvInterface konyvInterface) {
            this.konyvInterface = konyvInterface;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Konyv>>> Get() {
            var konyvek = await konyvInterface.Get();

            if (konyvek == null || !konyvek.Any())
                return NotFound();

            return Ok(konyvek);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Konyv>> Get(Guid id) {

            var konyv = await konyvInterface.GetById(id);

            if (konyv == null)
                return NotFound();

            return await konyvInterface.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Konyv>> Post(KonyvCreatedDTO createDTO) {

            return StatusCode(201, await konyvInterface.Post(createDTO));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Konyv>> Put(Guid id, KonyvUpdateDTO updateDTO) {
            var konyv = await konyvInterface.GetById(id);

            if (konyv == null)
                return NotFound();

            return await konyvInterface.Put(id, updateDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Konyv>> Delete(Guid id) {
            var konyv = await konyvInterface.GetById(id);

            if (konyv == null)
                return NotFound();

            return await konyvInterface.DeleteById(id);
        }

        [HttpGet("/bySzerzo/{id}")]
        public async Task<ActionResult<IEnumerable<Konyv>>> GetUserPosts(Guid id) {
            var konyvek = await konyvInterface.GetSzerzoKonyv(id);

            if (konyvek == null || !konyvek.Any()) 
                return NotFound(); 

            return Ok(konyvek);
        }
    }
}
