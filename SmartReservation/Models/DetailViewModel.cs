using Microsoft.AspNetCore.Mvc.Rendering;
using SmartReservation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartReservation.Models
{
    public class DetailViewModel
    {
        public List<RecipeIngredients> RecipeIngredientsList { get; set; }
        public List<Ingredients> IngredientsList { get; set; }
        public IEnumerable<SelectListItem> IngredientsDDL { get; set; }
        public Recipe Recipe { get; set; }
        public int recipeID { get; set; }
    }
}
