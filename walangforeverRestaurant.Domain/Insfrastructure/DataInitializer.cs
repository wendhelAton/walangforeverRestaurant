using System;
using walangforeverRestaurant.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace walangforeverRestaurant.Domain.Insfrastructure
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataAccess>
    {
        //DataInitializer dito ka mag-aadd ng users or members ayan yun code
        protected override void Seed(DataAccess db)
        {
#region Users
            db.Users.Add(new Model.User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Wendhel",
                LastName = "Aton",
                Password = "WendhelAton",
                UserName = "Wendhel22",
                Role = Enums.Role.admin

            }
            );
            db.SaveChanges();
            db.Users.Add(new Model.User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Johnmark",
                LastName = "Frondozo",
                Password = "JohnmarkFrondozo",
                UserName = "Johnmark23",
                Role = Enums.Role.admin

            }
            );
            db.SaveChanges();
            db.Users.Add(new Model.User()
            {
                Id = Guid.NewGuid(),
                FirstName = "JohnF",
                LastName = "Frondozo",
                Password = "JohnFFrondozo",
                UserName = "JohnF24",
                Role = Enums.Role.Cashier

            }
            );
            db.SaveChanges();
            db.Users.Add(new Model.User()
            {
                Id = Guid.NewGuid(),
                FirstName = "JayJay",
                LastName = "Manucum",
                Password = "JayJayManucum",
                UserName = "JayJay25",
                Role = Enums.Role.Cashier

            }
            );
            db.SaveChanges();
            db.Users.Add(new Model.User()
            {
                Id = Guid.NewGuid(),
                FirstName = "GianCarlo",
                LastName = "Mendoza",
                Password = "GianCarloMendoza",
                UserName = "GianCarlo26",
                Role = Enums.Role.InventoryController

            }
            );
            db.SaveChanges();
            db.Users.Add(new Model.User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Lewell",
                LastName = "Dacayo",
                Password = "LewellDacayo",
                UserName = "Lewell27",
                Role = Enums.Role.InventoryController

            }
            );
            db.SaveChanges();
            db.Users.Add(new Model.User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Mark",
                LastName = "Carreon",
                Password = "MarkJulo",
                UserName = "Mark28",
                Role = Enums.Role.Chef

            }
            );
            db.SaveChanges();
            db.Users.Add(new Model.User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Eric",
                LastName = "Alviar",
                Password = "EricAlviar",
                UserName = "Eric29",
                Role = Enums.Role.Chef

            }
            );
            db.SaveChanges();
            db.Users.Add(new Model.User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Kyle",
                LastName = "Reyes",
                Password = "KyleReyes",
                UserName = "Kyle30",
                Role = Enums.Role.Waiter

            }
            );
            db.SaveChanges();
            db.Users.Add(new Model.User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Percival",
                LastName = "Celestino",
                Password = "PercivalCelestino",
                UserName = "Percival31",
                Role = Enums.Role.Waiter

            }
            );
            db.SaveChanges();
            db.Users.Add(new Model.User()
            {
                Id = Guid.NewGuid(),
                FirstName = "JohnPeter",
                LastName = "DeVera",
                Password = "JohnPeterDeVera",
                UserName = "JohnPeter32",
                Role = Enums.Role.Waiter

            }
            );
            db.SaveChanges();
            db.Users.Add(new Model.User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Bino",
                LastName = "Punla",
                Password = "BinoPunla",
                UserName = "Bino33",
                Role = Enums.Role.Waiter

            }
            );
            db.SaveChanges();
            db.Users.Add(new Model.User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Br",
                LastName = "Luangco",
                Password = "BrLuangco",
                UserName = "Br34",
                Role = Enums.Role.Waiter

            }
           );
            db.SaveChanges();
            db.Users.Add(new Model.User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Justine",
                LastName = "Mariano",
                Password = "JustineMariano",
                UserName = "Justine35",
                Role = Enums.Role.Waiter

            }
           );
            db.SaveChanges();

            #endregion
#region Category

            db.Categories.Add(new Model.Category()
            {
                Id = Guid.Parse("9962f7b2e4c24f7e946bfc331c2fa0f0"),
                Name = "Beverages"

            }
            ); db.SaveChanges();

            db.Categories.Add(
                new Model.Category()
                {
                    Id = Guid.Parse("9962f7b2e4c24f7e946bfc331c2fa0f2"),
                    Name = "Non-alcoholic",
                    ParentId = Guid.Parse("9962f7b2e4c24f7e946bfc331c2fa0f0"),
                }
            );
            db.SaveChanges();

            #endregion
#region Products
            db.Product.Add(
                new Model.Products()
                {
                    Id = Guid.NewGuid(),
                    Name = "Beer",
                    CategoryId = Guid.Parse("9962f7b2e4c24f7e946bfc331c2fa0f1"),
                    Price = decimal.Parse("50")
                }
            );
            db.SaveChanges();

            db.Product.Add(
                new Model.Products()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rhum",
                    CategoryId = Guid.Parse("9962f7b2e4c24f7e946bfc331c2fa0f1"),
                    Price = decimal.Parse("750")
                }
            );
            db.SaveChanges();

            db.Product.Add(
                new Model.Products()
                {
                    Id = Guid.NewGuid(),
                    Name = "Whiskey",
                    CategoryId = Guid.Parse("9962f7b2e4c24f7e946bfc331c2fa0f1"),
                    Price = decimal.Parse("550")
                }
            );
            db.SaveChanges();

            db.Product.Add(
                new Model.Products()
                {
                    Id = Guid.NewGuid(),
                    Name = "Juice",
                    CategoryId = Guid.Parse("9962f7b2e4c24f7e946bfc331c2fa0f2"),
                    Price = decimal.Parse("50")
                }
            );
            db.SaveChanges();

            db.Product.Add(
                new Model.Products()
                {
                    Id = Guid.NewGuid(),
                    Name = "Soda",
                    CategoryId = Guid.Parse("9962f7b2e4c24f7e946bfc331c2fa0f2"),
                    Price = decimal.Parse("40")
                }
            );
            db.SaveChanges();

            db.Product.Add(
                new Model.Products()
                {
                    Id = Guid.NewGuid(),
                    Name = "Shake",
                    CategoryId = Guid.Parse("9962f7b2e4c24f7e946bfc331c2fa0f2"),
                    Price = decimal.Parse("80")
                }
            );
            db.SaveChanges();
            #endregion





        }
    }
}
