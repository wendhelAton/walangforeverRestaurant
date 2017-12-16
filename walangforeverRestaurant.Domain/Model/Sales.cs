using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace walangforeverRestaurant.Domain.Model
{
    public class Sales
    {
        public Guid? OrderId { get; set; }
        public int CashTenderd { get; set; }
        public DateTime date { get; set; }

    }
}
 