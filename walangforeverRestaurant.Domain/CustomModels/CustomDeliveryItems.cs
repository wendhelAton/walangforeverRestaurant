using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using walangforeverRestaurant.Domain.Insfrastructure;

namespace walangforeverRestaurant.Domain.CustomModels
{
    public class CustomDeliveryItems : BaseModel
    {
        public Guid? MaterialId { get; set; }

        public string MaterialName { get; set; }

        public int Quantity { get; set; }

        public Guid? DeliveryId { get; set; }

    }
}
