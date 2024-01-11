using BookAPI.Models;
using BookAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace BookAPI.Repositories {
    public class NemzetisegService : NemzetisegInterface {

        private readonly BookdbContext dbContext;

        public NemzetisegService(BookdbContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task<Nemzetiseg> DeleteById(Guid id) {

            var nemzet = dbContext.Nemzetisegs.Where(x => x.Id == id).FirstOrDefault();

            dbContext.Nemzetisegs.Remove(nemzet);
            await dbContext.SaveChangesAsync();

            return nemzet;
        }

        public async Task<IEnumerable<Nemzetiseg>> Get() {

            return dbContext.Nemzetisegs.ToList();
        }

        public async Task<Nemzetiseg> GetById(Guid id) {

            var nemzet = dbContext.Nemzetisegs.Where(x => x.Id == id).FirstOrDefault();

            return nemzet;
        }

        public async Task<Nemzetiseg> Post(DTOs.NemzetisegCreatedDTO createDTO) {

            var nemzet = new Nemzetiseg {
                Id = Guid.NewGuid(),
                SzerzoNemz = createDTO.SzerzoNemz
            };

            await dbContext.Nemzetisegs.AddAsync(nemzet);
            await dbContext.SaveChangesAsync();

            return nemzet;
        }

        public async Task<Nemzetiseg> Put(Guid id, DTOs.NemzetisegUpdateDTO updateDTO) {
            
            var nemzet = dbContext.Nemzetisegs.Where(x => x.Id == id).FirstOrDefault();

            nemzet.SzerzoNemz = updateDTO.SzerzoNemz;

            await dbContext.SaveChangesAsync();
            return nemzet;
        }
    }
}
