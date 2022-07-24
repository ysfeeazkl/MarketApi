using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.Concrete
{
    public class CreateOrderRequest
    {
        public Customer Customer { get; set; }
        public int CustomerId{ get; set; }


    }
}
