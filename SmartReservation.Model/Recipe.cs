using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartReservation.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Recipe")]
    public class Recipe
    {
        [Dapper.Contrib.Extensions.Key]
        public int RecipeID { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public string Username { get; set; }
        public int UserID { get; set; }
        public string ImageName { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public int CreatedByuserID { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? DeletedByUserID { get; set; }
        public DateTime? DeletedOn { get; set; }
        public IEnumerable<SelectListItem> IngredientsDDL { get; set; }
        public string IngredientsSelectedText { get; set; }
        public string IngredientsDeletedText { get; set; }
        public string UniqueRecipe { get; set; }
    }
}

