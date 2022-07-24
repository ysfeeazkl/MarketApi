using AutoMapper;
using Market.Entities.Concrete;
using Market.Entities.Dtos.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Business.AutoMapper
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerRegisterDto, Customer>();
            CreateMap<CustomerLoginDto, Customer>();
        }
    }
}
