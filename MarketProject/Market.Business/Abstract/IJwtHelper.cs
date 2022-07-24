using MarketProject.Shared.Utilities.Security.Jwt;
using Market.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Business.Abstract
{
    public interface IJwtHelper
    {
        AccessToken CreateToken(Customer customer);
    }
}
