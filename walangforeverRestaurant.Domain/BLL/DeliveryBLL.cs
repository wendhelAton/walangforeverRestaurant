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
    public static class DeliveryBLL
    {
        private static DataAccess db = new DataAccess();

        public static List<Delivery> GetAll()
        {
            return db.Delivery.ToList();
        }

        public static Page<Delivery> Search(long pageSize = 3, long pageIndex = 1, SortOrder sortOrder = SortOrder.Ascending, string keyword = "")
        {
            Page<Delivery> result = new Page<Delivery>();

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IQueryable<Delivery> devQuery = (IQueryable<Delivery>)db.Delivery;
            if (string.IsNullOrEmpty(keyword) == false)
            {
                devQuery = devQuery.Where(c => c.Date.Equals(keyword));
            }
            long queryCount = devQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<Delivery> Delivery = new List<Delivery>();

            if (sortOrder == SortOrder.Ascending)
            {
                Delivery = devQuery.OrderBy(c => c.Date).ToList();
            }
            else
            {
                Delivery = devQuery.OrderByDescending(u => u.Date).ToList();
            }


            result.Items = Delivery.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;

            return result;
        }
        public static Delivery Find(Guid? id)
        {
            return db.Delivery.FirstOrDefault(u => u.Id == id);
        }
    }
}
