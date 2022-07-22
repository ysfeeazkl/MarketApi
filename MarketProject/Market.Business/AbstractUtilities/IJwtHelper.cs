
using Fahax.Shared.Utilities.Security.Jwt;

namespace Fahax.Business.AbstractUtilities
{
    public interface IJwtHelper
    {
        AccessToken CreateToken();
    }
}

