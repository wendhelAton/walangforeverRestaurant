using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace walangforeverRestaurant.Domain.Insfrastructure
{
     public class DataAccess : DbContext
    {
        public DataAccess() : base ("myConnectionString")
        {
            Database.SetInitializer(new walangforeverRestaurant.Domain.Insfrastructure.DataInitializer()
                );
        }
        public DbSet<Model.User> Users { get; set; }
       
    }
}
