using System;
using System.Collections.Generic;
using System.Text;

namespace SmartReservation.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Ingredients")]
    public class Ingredients
    {
        [Dapper.Contrib.Extensions.Key]
        public int IngredientID { get; set; }
        public string Name { get; set; }
        public int RecipeID { get; set; }
    }
}
