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
    public class MaterialBLL
    {
        private static DataAccess db = new DataAccess();

        public static List<Materials> GetAll()
        {
            return db.Materials.ToList();
        }

        public static Materials SearchByName(string name)
        {
            return db.Materials.FirstOrDefault(m => m.Name == name);
        }
    }
}
