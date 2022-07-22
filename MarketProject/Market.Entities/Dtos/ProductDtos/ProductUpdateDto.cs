using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.Dtos.ProductDtos
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
