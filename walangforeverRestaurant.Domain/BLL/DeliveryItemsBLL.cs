using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using walangforeverRestaurant.Domain.CustomModels;
using walangforeverRestaurant.Domain.Enums;
using walangforeverRestaurant.Domain.Insfrastructure;
using walangforeverRestaurant.Domain.Model;

namespace walangforeverRestaurant.Domain.BLL
{
    public static class DeliveryItemsBLL 
    {
        private static DataAccess db = new DataAccess();

        public static List<CustomDeliveryItems> GetAll()
        {
            return db.DeliveryItems.ToList();
        }
        public static CustomDeliveryItems GetDeliveryItemsByMaterialName(string MaterialName)
        {
            return db.DeliveryItems.FirstOrDefault(u => u.MaterialName.ToLower() == MaterialName.ToLower());
        }

        public static CustomDeliveryItems GetDuplicateMaterialName(string MaterialName, Guid? id)
        {
            return db.DeliveryItems.FirstOrDefault(u => u.MaterialName.ToLower() == MaterialName.ToLower()

            && u.Id != id);

        }
        public static CustomDeliveryItems Create(CustomDeliveryItems deliveryItems)
        {
            db.DeliveryItems.Add(deliveryItems);
            db.SaveChanges();
            return deliveryItems;
        }
        public static CustomDeliveryItems Update(CustomDeliveryItems deliveryItems)
        {
            CustomDeliveryItems DelItemsRecord = db.DeliveryItems.FirstOrDefault(u => u.Id == deliveryItems.Id);
            if (DelItemsRecord != null)
            {
                DelItemsRecord.MaterialName = DelItemsRecord.MaterialName;

                db.SaveChanges();
            }
            return DelItemsRecord;
        }
        public static Guid? Delete(CustomDeliveryItems deliveryItems)
        {
            db.DeliveryItems.Remove(deliveryItems);
            db.SaveChanges();
            return deliveryItems.Id;
        }
            public static Page<CustomDeliveryItems> Search(long pageSize = 3, long pageIndex = 1, SortOrder sortOrder = SortOrder.Ascending, string keyword = "", Guid? deliveryId = null)
        {
            Page<CustomDeliveryItems> result = new Page<CustomDeliveryItems>();

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IQueryable<CustomDeliveryItems> DeliveryItemsQuery = (IQueryable<CustomDeliveryItems>)db.DeliveryItems;

            if (deliveryId != null)
            {
                DeliveryItemsQuery = DeliveryItemsQuery.Where(c => c.DeliveryId == deliveryId.Value);
            }
            else
            {
                DeliveryItemsQuery = DeliveryItemsQuery.Where(c => c.DeliveryId == null);
            }

            if (string.IsNullOrEmpty(keyword) == false)
            {
                DeliveryItemsQuery = DeliveryItemsQuery.Where(c => c.MaterialName.Contains(keyword));
            }

            long queryCount = DeliveryItemsQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<CustomDeliveryItems> deliveryitems = new List<CustomDeliveryItems>();

            if (sortOrder == SortOrder.Ascending)
            {
                deliveryitems = DeliveryItemsQuery.OrderBy(c => c.MaterialName).ToList();
            }
            else
            {
                deliveryitems = DeliveryItemsQuery.OrderByDescending(u => u.MaterialName).ToList();
            }


            result.Items = deliveryitems
                .Skip(skip)
                .Take((int)pageSize)
                .Select(c => new CustomDeliveryItems()
                {
                    Id = c.Id,
                    Quantity = c.Quantity,
                    MaterialName = c.MaterialName,
                    Timestamp = c.Timestamp,
                    DeliveryId = c.DeliveryId
                })

                .ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            return result;
        }
        public static CustomDeliveryItems Find(Guid? id)
        {
            return db.DeliveryItems.FirstOrDefault(u => u.Id == id);
        }
    }
}
