using Microsoft.AspNetCore.Mvc.Rendering;
using SmartReservation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartReservation.Models
{
    public class RecipeViewModel
    {
        public Recipe Recipe { get; set; }
        public List<Recipe> RecipeList { get; set; }
        public IEnumerable<SelectListItem> IngredientsDDL { get; set; }
        public string Ingredients { get; set; }
        public string IngredientsSelectedText { get; set; }
        public string IngredientsDeletedText { get; set; }
    }
}
