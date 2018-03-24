using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using walangforeverRestaurant.Domain.Insfrastructure;

namespace walangforeverRestaurant.Domain.CustomModels
{
    public class CustomDelivery : BaseModel
    {
        public DateTime Date { get; set; }

        public List<CustomDeliveryItem> Items { get; set; }
    }

    public class CustomDeliveryItem : BaseModel
    {
        public Guid? MaterialId { get; set; }

        public string MaterialName { get; set; }

        public decimal Quantity { get; set; }

        public Guid? DeliveryId { get; set; }

        
    }
}
