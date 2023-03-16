using Dapper;
using Microsoft.Extensions.Configuration;
using SmartReservation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartReservation.Service
{
    public class RecipeMetricService : IRecipeMetric
    {
        private readonly IConfiguration _config;
        public RecipeMetricService(IConfiguration configuration)
        {
            _config = configuration;
        }
        public async Task<Model.RecipeMetric> GetDisplayCount()
        {
            const string sql = "SELECT * FROM RecipeMetric";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Query<Model.RecipeMetric>(sql).FirstOrDefault();
        }
    }
}
