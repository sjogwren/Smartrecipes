using System;
using System.Collections.Generic;
using System.Text;

namespace SmartReservation.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("RecipeMetric")]
    public class RecipeMetric
    {
        [Dapper.Contrib.Extensions.Key]
        public int RecipeMetricID { get; set; }
        public int DisplayOrder { get; set; }
    }
}
