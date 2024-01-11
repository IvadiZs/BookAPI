using BookAPI.Models.DTOs;
using BookAPI.Models;
using static BookAPI.Models.DTOs.DTOs;

namespace BookAPI.Repositories {
    public interface NemzetisegInterface {

        Task<IEnumerable<Nemzetiseg>> Get();
        Task<Nemzetiseg> GetById(Guid id);

        Task<Nemzetiseg> Post(NemzetisegCreatedDTO createDTO);

        Task<Nemzetiseg> Put(Guid id, NemzetisegUpdateDTO updateDTO);

        Task<Nemzetiseg> DeleteById(Guid id);
    }
}
