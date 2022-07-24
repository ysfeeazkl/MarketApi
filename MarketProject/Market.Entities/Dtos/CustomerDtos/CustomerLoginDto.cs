using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.Dtos.CustomerDtos
{
    public class CustomerLoginDto
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
