using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using walangforeverRestaurant.Domain.Enums;
using walangforeverRestaurant.Domain.Insfrastructure;
using walangforeverRestaurant.Domain.Model;

namespace walangforeverRestaurant.Domain.BLL
{
    public static class OrderBLL
    {
        //OrderBLL Folder ito yung nagbibigay ng code sa database. at pinapaalam nya yung mga nilagay mong code sa project mo..
        private static Insfrastructure.DataAccess db = new Insfrastructure.DataAccess();

        public static List<Orders> GetAll()
        {
            return db.Orders.ToList();
        }
        
       
        public static Orders Create(Orders orders)
        {
            db.Orders.Add(orders);
            db.SaveChanges();
            return orders;
        }
        //code for update in datagrid
        public static Orders Update(Orders orders)
        {
            Orders OrdersRecord = db.Orders.FirstOrDefault(u => u.Id == orders.Id);
            if (OrdersRecord != null)
            {
               
                OrdersRecord.Status = orders.Status;
                db.SaveChanges();
            }
            return OrdersRecord;
        }
        public static Guid? Delete(Orders orders)
        {
            db.Orders.Remove(orders);
            db.SaveChanges();
            return orders.Id;
        }


        public static Page<Orders> Search(long pageSize = 3, long pageIndex = 1, SortOrder sortOrder = SortOrder.Ascending, OrderStatus? orderstatus = null, string keyword = "")
        {
            Page<Orders> result = new Page<Orders>();

            if (pageSize < 1)
            {
                pageSize = 1;
            }


            //yung db.users ginawa nating userQuiry sa code na to,(List of users) (Filtering)
            IQueryable<Orders> ordersQuery = (IQueryable<Orders>)db.Orders;

            //nagtatanong siya kung may OrderStatus ka bang binigay sa kanyang Status.. code sa search(Filtering)
            if (orderstatus != null)
            {
                ordersQuery = ordersQuery.Where(u => u.Status == orderstatus.Value);
            }

            //code para sa page(Paging)
            long queryCount = ordersQuery.Count();
            long PageCount = (long)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                PageCount = PageCount + 1;
            }


            int skip = (int)(pageSize * (pageIndex - 1));
            List<Orders> orders = new List<Orders>();

       



            //result.Items = users.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = PageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            return result;

        }
        public static User Find(Guid? id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
