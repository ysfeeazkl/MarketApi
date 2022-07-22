using Fahax.Business.AbstractUtilities;
using Fahax.Entities.Concrete;
using Fahax.Shared.Extensions;
using Fahax.Shared.Utilities.Security.Encryption;
using Fahax.Shared.Utilities.Security.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Fahax.Business.Utilities
{
    public class JwtHelper : IJwtHelper
    {
        IConfiguration Configuration { get; }
        TokenOptions _tokenOptions;
        DateTime _accessTokenExpiration;
        DateTime _refreshTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            //Configuration = configuration;
            //_tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken()
        {
            return null;
        }

        public JwtSecurityToken CreateJwtSecurityToken()
        {
            return null;
        }
       
    }
}

