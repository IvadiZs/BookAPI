namespace BookAPI.Models.DTOs {
    public class DTOs {

        public record SzerzoDTO(Guid Id, string Nev, string Nem, Guid NemzId);
        public record SzerzoCreatedDTO(string Nev, string Nem, Guid NemzId);
        public record SzerzoUpdateDTO(string Nev, string Nem, Guid NemzId);
        public record KonyvDTO(Guid Id, string Cim, int Oldalszam, int Kiadev, Guid SzerzoId);
        public record KonyvCreatedDTO(string Cim, int Oldalszam, int Kiadev, Guid SzerzoId);
        public record KonyvUpdateDTO(string Cim, int Oldalszam, int Kiadev, Guid SzerzoId);
        public record NemzetisegDTO(Guid Id, string SzerzoNemz);
        public record NemzetisegCreatedDTO(string SzerzoNemz);
        public record NemzetisegUpdateDTO(string SzerzoNemz);
    }
}
