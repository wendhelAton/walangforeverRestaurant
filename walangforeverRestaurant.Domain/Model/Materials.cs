using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using walangforeverRestaurant.Domain.Insfrastructure;

namespace walangforeverRestaurant.Domain.Model
{
    public class Materials : BaseModel
    {
        public string Name { get; set; }
        public string UOM { get; set; } // Unit of Measure
        public decimal Quantity { get; set; }
    }
}
