using AutoMapper;
using Market.Entities.Concrete;
using Market.Entities.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Business.AutoMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductAddDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
        }
    }
}
