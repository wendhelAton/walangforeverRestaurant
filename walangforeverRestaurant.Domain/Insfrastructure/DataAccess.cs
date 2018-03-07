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
        public DataAccess() : base("myConnectionString")
        {
            Database.SetInitializer(new walangforeverRestaurant.Domain.Insfrastructure.DataInitializer()
                );
        }
        public DbSet<Model.User> Users { get; set; }
        public DbSet<Model.Category> Categories { get; set; }
        public DbSet<Model.Products> Product { get; set; }
        public DbSet<Model.Delivery> Delivery { get; set; }
        public DbSet<CustomModels.CustomDeliveryItems> DeliveryItems { get; set; }
        public DbSet<Model.Materials> Materials { get; set; }
        public DbSet<Model.Orders> Orders { get; set; }
        public DbSet<Model.OrderItems> OrderItems { get; set; }
        public DbSet<Model.Recipe> Recipe { get; set; }
        public DbSet<Model.Sales> Sales { get; set; }
    }
}
