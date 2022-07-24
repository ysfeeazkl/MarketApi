using AutoMapper;
using Market.Entities.Concrete;
using MarketProject.Business.AbstractUtilities;
using MarketProject.Shared.Extensions;
using MarketProject.Shared.Utilities.Security.Encryption;
using MarketProject.Shared.Utilities.Security.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MarketProject.Business.Utilities
{
    public class JwtHelper : IJwtHelper
    {
        IConfiguration Configuration { get; }
        TokenOptions _tokenOptions;
        DateTime _accessTokenExpiration;
        DateTime _refreshTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(Customer customer)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, customer, signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            //RefreshToken
            _refreshTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration + 100);
            var jwtRefresh = CreateJwtRefreshToken(_tokenOptions, customer, signingCredentials);
            var refreshToken = jwtSecurityTokenHandler.WriteToken(jwtRefresh);
            return new AccessToken
            {
                Token = token,
                TokenExpiration = _accessTokenExpiration,

            };
        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, Customer customer, SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(customer),
                signingCredentials: signingCredentials
            );
            return jwt;
        }
        public JwtSecurityToken CreateJwtRefreshToken(TokenOptions tokenOptions, Customer customer, SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _refreshTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(customer),
                signingCredentials: signingCredentials
            );
            return jwt;
        }
        private IEnumerable<Claim> SetClaims(Customer customer)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(customer.Id.ToString());
            claims.AddEmail(customer.EmailAddress);
            claims.AddName($"{customer.FirstName} {customer.LastName}");
            //claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims;
        }
    }
}

