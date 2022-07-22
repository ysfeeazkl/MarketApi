using Fahax.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.Concrete
{
    public class Order:EntityBase<int>,IEntity
    {
        public Customer Customer { get; set; }
        public int CustomerId{ get; set; }
        public decimal TotalAmount { get; set; }
    }
}
