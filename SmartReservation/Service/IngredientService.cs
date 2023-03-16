using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using SmartReservation.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SmartReservation.Service
{
    public class IngredientService : IIngredient
    {
        private readonly IConfiguration _config;
        public IngredientService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<List<Model.RecipeIngredients>> GetRecipeIngredientsAllByID(int RecipeID)
        {
            const string sql = "SELECT * FROM RecipeIngredients where RecipeID = @RecipeID";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Query<Model.RecipeIngredients>(sql, new { RecipeID = RecipeID }).ToList();
        }

        public async Task<Model.Ingredients> CheckIfIngredientExist(string Name)
        {
            const string sql = "proc_CheckIfIngredientExist";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Query<Model.Ingredients>(sql, new { Name = Name }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public async Task<Model.Ingredients> CreateAsync(Model.Ingredients Ingredients)
        {
            try
            {
                var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
                var userId = connection.Insert(Ingredients);
                Ingredients.IngredientID = (int)userId;
                return Ingredients;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<Model.Ingredients> FindByIdAsync(int IngredientID)
        {
            const string sql = "SELECT * FROM Ingredients where IngredientID = @IngredientID";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Query<Model.Ingredients>(sql, new { IngredientID }).FirstOrDefault();
        }

        public async Task<List<Model.Ingredients>> Ingredients()
        {
            const string sql = "SELECT * FROM Ingredients";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Query<Model.Ingredients>(sql).ToList();
        }

        public async Task<bool> UpdateAsync(Model.Ingredients Ingredient)
        {
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return await connection.UpdateAsync(Ingredient);
        }
    }
}
