using BookAPI.Models;
using BookAPI.Models.DTOs;

namespace BookAPI.Repositories {
    public class SzerzoService : SzerzoInterface {

        private readonly BookdbContext dbContext;

        public SzerzoService(BookdbContext dbContext) {
            this.dbContext = dbContext;
        }
        public async Task<Szerzo> DeleteById(Guid id) {

            var szerzo = dbContext.Szerzos.Where(x => x.Id == id).FirstOrDefault();

            dbContext.Szerzos.Remove(szerzo);
            await dbContext.SaveChangesAsync();

            return szerzo;
        }

        public async Task<IEnumerable<Szerzo>> Get() {

            return dbContext.Szerzos.ToList();
        }

        public async Task<Szerzo> GetById(Guid id) {

            var szerzo = dbContext.Szerzos.Where(x => x.Id == id).FirstOrDefault();

            return szerzo;
        }

        public async Task<Szerzo> Post(DTOs.SzerzoCreatedDTO createDTO) {

            var szerzo = new Szerzo {
                Id = Guid.NewGuid(),
                Nev = createDTO.Nev,
                Nem = createDTO.Nem,
                NemzId = createDTO.NemzId,
            };

            await dbContext.Szerzos.AddAsync(szerzo);
            await dbContext.SaveChangesAsync();

            return szerzo;
        }

        public async Task<Szerzo> Put(Guid id, DTOs.SzerzoUpdateDTO updateDTO) {

            var szerzo = dbContext.Szerzos.Where(x => x.Id == id).FirstOrDefault();

            szerzo.Nev = updateDTO.Nev;
            szerzo.Nem = updateDTO.Nem;
            szerzo.NemzId = updateDTO.NemzId;

            await dbContext.SaveChangesAsync();
            return szerzo;
        }
    }
}
