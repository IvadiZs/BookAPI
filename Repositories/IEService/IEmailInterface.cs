using static BookAPI.Models.DTOs.DTOs;

namespace BookAPI.Repositories.IEService {
    public interface IEmailInterface {

        void SendEmail(EmailDTO request);
    }
}
