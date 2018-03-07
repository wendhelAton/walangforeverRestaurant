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
        //this code check if the user1 already have  a user1
        public static Materials GetMaterialByName(string Name)
        {
            return db.Materials.FirstOrDefault(u => u.Name.ToLower() == Name.ToLower());
        }
        //code for duplicate your user account
        public static Materials GetDuplicateName(string Name, Guid? id)
        {
            return db.Materials.FirstOrDefault(u => u.Name.ToLower() == Name.ToLower()

            && u.Id != id);

        }

        public static Materials Create(Materials materials)
        {
            db.Materials.Add(materials);
            db.SaveChanges();
            return materials;
        }
        //code for update in datagrid
        public static Materials Update(Materials materials)
        {
            Materials MatRecord = db.Materials.FirstOrDefault(u => u.Id == materials.Id);
            if (MatRecord != null)
            {
                MatRecord.Name = materials.Name;
                db.SaveChanges();
            }
            return MatRecord;
        }
        public static Guid? Delete(Materials materials)
        {
            db.Materials.Remove(materials);
            db.SaveChanges();
            return materials.Id;
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
        public static Materials Find(Guid? id)
        {
            return db.Materials.FirstOrDefault(u => u.Id == id);
        }
    }
}
