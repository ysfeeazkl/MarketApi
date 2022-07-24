
using MarketProject.Shared.Utilities.Results.Abstract;

namespace MarketProject.Business.AbstractUtilities
{
    public interface IMailService
    {
        Task<IDataResult> SendEmail();
        Task<IDataResult> SendLandingEmail();
    }
}

