using AutoMapper;
using Market.Entities.Concrete;
using MarketProject.Shared.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Business.AutoMapper
{
    public class AuthProfile:Profile
    {
        public AuthProfile()
        {
            CreateMap<CustomerToken, AccessToken>().ReverseMap();
        }
    }
}
