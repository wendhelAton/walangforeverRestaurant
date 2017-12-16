using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace walangforeverRestaurant.Domain.Model
{
    public class Recipe
    {
        public Guid? ProductId { get; set; }
        public Guid? MaterialId { get; set; }
        public string UOM { get; set; }
        public int Quantity { get; set; }
    }
}
