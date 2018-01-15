﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using walangforeverRestaurant.Domain.Insfrastructure;

namespace walangforeverRestaurant.Domain.Model
{
    public class Products : BaseModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
