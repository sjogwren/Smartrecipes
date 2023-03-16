using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartReservation.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("RecipeIngredients")]
    public class RecipeIngredients
    {
        [Dapper.Contrib.Extensions.Key]
        public int RecipeIngredientID { get; set; }
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public int RecipeID { get; set; }
    }
}
