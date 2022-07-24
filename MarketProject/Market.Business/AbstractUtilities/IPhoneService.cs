using MarketProject.Shared.Utilities.Results.Abstract;

namespace MarketProject.Business.AbstractUtilities
{
    public interface IPhoneService
    {
        Task<IDataResult> SendPhoneVerificationCodeAsync(string phoneNumber, string verificationCode);
    }
}

