using BookAPI.Models;
using static BookAPI.Models.DTOs.DTOs;

namespace BookAPI.Repositories {
    public interface SzerzoInterface {

        Task<IEnumerable<Szerzo>> Get();
        Task<Szerzo> GetById(Guid id);

        Task<Szerzo> Post(SzerzoCreatedDTO createDTO);

        Task<Szerzo> Put(Guid id, SzerzoUpdateDTO updateDTO);

        Task<Szerzo> DeleteById(Guid id);
    }
}
