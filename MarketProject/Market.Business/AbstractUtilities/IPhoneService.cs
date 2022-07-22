using Fahax.Shared.Utilities.Results.Abstract;

namespace Fahax.Business.AbstractUtilities
{
    public interface IPhoneService
    {
        Task<IDataResult> SendPhoneVerificationCodeAsync(string phoneNumber, string verificationCode);
    }
}

