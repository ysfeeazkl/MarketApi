using MarketProject.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.Concrete
{
    public class OrderDetail:EntityBase<int>,IEntity
    {
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Product Product{ get; set; }
        public int ProductId { get; set; }
    }
}
