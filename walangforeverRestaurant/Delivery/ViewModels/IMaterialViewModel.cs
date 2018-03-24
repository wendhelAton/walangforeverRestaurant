using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using walangforeverRestaurant.Domain.Insfrastructure;

namespace walangforeverRestaurant.Delivery.ViewModels
{
    public interface IMaterialViewModel 
    {
        IEnumerable<walangforeverRestaurant.Domain.Model.Materials> Materials { get; }
        walangforeverRestaurant.Domain.Model.Materials SelectedMaterial { get; set; }
    }
}
