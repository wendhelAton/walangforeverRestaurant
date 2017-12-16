using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace walangforeverRestaurant.Domain.Insfrastructure
{
      public class BaseModel
    {
        public BaseModel()
        {
            this.Id = Guid.NewGuid();
            this.Timestamp = DateTime.Now;
        }
        public Guid? Id { get; set; }
        public DateTime Timestamp { get; set; }


    }
}
