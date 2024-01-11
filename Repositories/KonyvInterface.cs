using BookAPI.Models;
using static BookAPI.Models.DTOs.DTOs;

namespace BookAPI.Repositories {
    public interface KonyvInterface {

        Task<IEnumerable<Konyv>> Get();
        Task<Konyv> GetById(Guid id);

        Task<Konyv> Post(KonyvCreatedDTO createDTO);

        Task<Konyv> Put(Guid id, KonyvUpdateDTO updateDTO);

        Task<Konyv> DeleteById(Guid id);

        Task<IEnumerable<Konyv>> GetSzerzoKonyv(Guid id);
    }
}
