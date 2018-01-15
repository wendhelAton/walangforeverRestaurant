using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using walangforeverRestaurant.Domain.Insfrastructure;

namespace walangforeverRestaurant.Domain.Model
{
    public class Recipe : BaseModel
    {
        public Guid? ProductId { get; set; }
        public Guid? MaterialId { get; set; }
        public string UOM { get; set; }
        public int Quantity { get; set; }
    }
}
