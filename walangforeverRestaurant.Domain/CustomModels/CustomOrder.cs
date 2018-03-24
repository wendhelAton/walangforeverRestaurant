using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using walangforeverRestaurant.Domain.Enums;
using walangforeverRestaurant.Domain.Insfrastructure;

namespace walangforeverRestaurant.Domain.CustomModels
{
    public class CustomOrder : BaseModel
    {
        public decimal OrderNo { get; set; }
        public decimal TableNo { get; set; }
        public OrderStatus Status { get; set; }
        public bool Paid { get; set; }
        public List< CustomOrderItem> Items { get; set; }
    }

    public class CustomOrderItem : BaseModel
    {
        public Guid? OrderId { get; set; }
        public Guid? ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
