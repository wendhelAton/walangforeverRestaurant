using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using walangforeverRestaurant.Domain.Enums;
using walangforeverRestaurant.Domain.Insfrastructure;

namespace walangforeverRestaurant.Domain.Model
{
    public class User: BaseModel
    {
     
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public string Fullname
        {

            get {
                //Wendhel Aton
                return this.FirstName + " " + this.LastName;
                    }
        }
        public string Abbname
        {
            get
            {
                //A. Aton
                return this.FirstName.Substring(0, 1).ToUpper() + " . " + LastName;
            }
        }

    }
}
