using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace walangforeverRestaurant.Domain.Insfrastructure
{
      public class BaseModel
    {
        //code para hindi mo na ilagay ang Id sa Model.Users at code para malaman mo kung anong oras ginawa ang mga user. direct to database ito.
        public BaseModel()
        {
            this.Id = Guid.NewGuid();
            this.Timestamp = DateTime.Now;
        }
        public Guid? Id { get; set; }
        public DateTime Timestamp { get; set; }


    }
}
