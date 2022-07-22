using Fahax.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.Concrete
{
    public class Customer:EntityBase<int>,IEntity
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string GSM { get; set; }

    }
}
