﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using walangforeverRestaurant.Domain.Enums;
using walangforeverRestaurant.Domain.Insfrastructure;
using walangforeverRestaurant.Domain.Model;

namespace walangforeverRestaurant.Domain.BLL
{
    public static class UsersBLL
    {
        private static Insfrastructure.DataAccess db = new Insfrastructure.DataAccess();

        public static List<User>  GetAll()
        {
            return db.Users.ToList();
        }

        public static Page<User> Search(long pageSize = 3, long pageIndex = 1,UserSortOrder orderBy = UserSortOrder.UserName,SortOrder sortOrder = SortOrder.Ascending)
        {
            Page<User> result = new Page<User>();
            long queryCount = db.Users.Count();
            long PageCount = (long)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if(mod > 0)
            {
                PageCount = PageCount + 1;
            }


            int skip = (int)(pageSize * (pageIndex - 1));
            List<User> users = new List<User>();

            if (sortOrder == SortOrder.Ascending && orderBy == UserSortOrder.UserName)
            {
                users = db.Users.OrderBy(u => u.UserName).ToList();
            }
            else if (sortOrder == SortOrder.Descending && orderBy == UserSortOrder.UserName)
            {
                users = db.Users.OrderByDescending(u => u.UserName).ToList();
            }
            else if (sortOrder == SortOrder.Ascending && orderBy == UserSortOrder.FirstName)
            {
                users = db.Users.OrderBy(u => u.FirstName).ToList();
            }
            else if (sortOrder == SortOrder.Descending && orderBy == UserSortOrder.FirstName)
            {
                users = db.Users.OrderByDescending(u => u.FirstName).ToList();
            }
            else if (sortOrder == SortOrder.Ascending && orderBy == UserSortOrder.LastName)
            {
                users = db.Users.OrderBy(u => u.LastName).ToList();
            }
            else if (sortOrder == SortOrder.Descending && orderBy == UserSortOrder.LastName)
            {
                users = db.Users.OrderByDescending(u => u.LastName).ToList();
            }



            result.Items = users.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = PageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            return result;
        }
    }
}
