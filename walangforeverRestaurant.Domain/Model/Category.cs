﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace walangforeverRestaurant.Domain.Model
{
    public class Category
    {
        public string Name { get; set; }
        public Guid? ParentId { get; set; }

    }
}
