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
    public static class MaterialsBLL
    {
        private static DataAccess db = new DataAccess();

        public static List<Materials> GetAll()
        {
            return db.Materials.ToList();
        }

        public static Page<Materials> Search(long pageSize = 3, long pageIndex = 1, SortOrder sortOrder = SortOrder.Ascending, string keyword = "")
        {
            Page<Materials> result = new Page<Materials>();

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IQueryable<Materials> MatQuery = (IQueryable<Materials>)db.Materials;

            if (string.IsNullOrEmpty(keyword) == false)
            {
                MatQuery = MatQuery.Where(c => c.Name.Contains(keyword));
            }

            long queryCount = MatQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<Materials> Materials = new List<Materials>();

            if (sortOrder == SortOrder.Ascending)
            {
                Materials = MatQuery.OrderBy(c => c.Name).ToList();
            }
            else
            {
                Materials = MatQuery.OrderByDescending(u => u.Name).ToList();
            }


            result.Items = Materials.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;

            return result;
        }
    }
}
