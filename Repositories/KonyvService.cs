using BookAPI.Models;
using BookAPI.Models.DTOs;

namespace BookAPI.Repositories {
    public class KonyvService : KonyvInterface {

        private readonly BookdbContext dbContext;

        public KonyvService(BookdbContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task<Konyv> DeleteById(Guid id) {

            var konyv = dbContext.Konyvs.Where(x => x.Id == id).FirstOrDefault();

            dbContext.Konyvs.Remove(konyv);
            await dbContext.SaveChangesAsync();

            return konyv;
        }

        public async Task<IEnumerable<Konyv>> Get() {

            return dbContext.Konyvs.ToList();
        }

        public async Task<Konyv> GetById(Guid id) {

            var konyv = dbContext.Konyvs.Where(x => x.Id == id).FirstOrDefault();

            return konyv;
        }

        public async Task<Konyv> Post(DTOs.KonyvCreatedDTO createDTO) {

            var konyv = new Konyv {
                Id = Guid.NewGuid(),
                Cim = createDTO.Cim,
                Oldalszam = createDTO.Oldalszam,
                Kiadev = createDTO.Kiadev,
                SzerzoId = createDTO.SzerzoId
            };

            await dbContext.Konyvs.AddAsync(konyv);
            await dbContext.SaveChangesAsync();

            return konyv;
        }

        public async Task<Konyv> Put(Guid id, DTOs.KonyvUpdateDTO updateDTO) {

            var konyv = dbContext.Konyvs.Where(x => x.Id == id).FirstOrDefault();

            konyv.Cim = updateDTO.Cim;
            konyv.Oldalszam = updateDTO.Oldalszam;
            konyv.Kiadev = updateDTO.Kiadev;
            konyv.SzerzoId = updateDTO.SzerzoId;

            await dbContext.SaveChangesAsync();
            return konyv;
        }

        public async Task<IEnumerable<Konyv>> GetSzerzoKonyv(Guid id) {

            var konyvList = dbContext.Konyvs.Where(x => x.SzerzoId == id).ToList();

            return konyvList;
        }
    }
}
