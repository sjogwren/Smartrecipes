using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartReservation.Interface
{
    public interface IRecipeMetric
    {
        Task<Model.RecipeMetric> GetDisplayCount();
    }
}
