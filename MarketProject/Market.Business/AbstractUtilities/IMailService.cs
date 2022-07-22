using Fahax.Entities.Dtos.EmailDtos;
using Fahax.Shared.Utilities.Results.Abstract;

namespace Fahax.Business.AbstractUtilities
{
    public interface IMailService
    {
        Task<IDataResult> SendEmail(EmailSendDto emailSendDto);
        Task<IDataResult> SendLandingEmail(LandingEmailDto landingEmailDto);
    }
}

