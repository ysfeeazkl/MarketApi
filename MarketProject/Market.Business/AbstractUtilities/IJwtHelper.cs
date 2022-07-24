
using MarketProject.Shared.Utilities.Security.Jwt;
using Market.Entities.Concrete;

namespace MarketProject.Business.AbstractUtilities
{
    public interface IJwtHelper
    {
        AccessToken CreateToken(Customer customer);
    }
}

