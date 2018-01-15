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
        //code para maconnect ang mga data mo sa database
        public DataAccess() : base ("myConnectionString")
        {
            Database.SetInitializer(new walangforeverRestaurant.Domain.Insfrastructure.DataInitializer()
                );
        }
        public DbSet<Model.User> Users { get; set; }
        public DbSet<Model.Category> Categories { get; set; }
        public DbSet<Model.Products> Product { get; set; }
       
    }
}
