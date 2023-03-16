using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using SmartReservation.Interface;
using SmartReservation.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SmartReservation.Service
{
    public class RecipeService : IRecipe
    {
        private readonly IConfiguration _config;
        public RecipeService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<List<Model.RecipeIngredients>> GetIngredientsByID(int RecipeID)
        {
            const string sql = @"SELECT DISTINCT I.IngredientID as IngredientID, I.Name as IngredientName, @RecipeID FROM RecipeIngredients RI 
                                INNER JOIN Ingredients I 
                                ON I.IngredientID = RI.IngredientID
                                WHERE RI.RecipeID = @RecipeID";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Query<Model.RecipeIngredients>(sql, new { RecipeID = RecipeID }).ToList();
        }

        public async Task<Model.Recipe> CheckIfRecipeExist(string Name)
        {
            const string sql = "proc_CheckIfRecipeExist";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Query<Model.Recipe>(sql, new { Name = Name }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public async Task<bool> CreateAsync(Model.Recipe Recipe)
        {
            try
            {
                await using var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
                return connection.Query<bool>("[dbRecipe].[dbo].[proc_Recipe_Insert]",
                new
                {
                    Recipe.Name,
                    Recipe.Instructions,
                    Recipe.ImageName,
                    Recipe.IngredientsSelectedText,
                    Recipe.DateAdded,
                    Recipe.UserID,
                    Recipe.Username,
                    Recipe.CreatedOn,
                    Recipe.CreatedByuserID

                },
                commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<Model.Recipe> FindByIdAsync(int RecipeID)
        {
            const string sql = "SELECT * FROM Recipe where RecipeID = @RecipeID";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Query<Model.Recipe>(sql, new { RecipeID }).FirstOrDefault();
        }

        public async Task<List<Model.Recipe>> Recipes()
        {
            const string sql = "SELECT * FROM Recipe";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Query<Model.Recipe>(sql).ToList();
        }

        public async Task<bool> UpdateAsync(Model.Recipe Recipe)
        {
            try
            {
                await using var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
                return connection.Query<bool>("[dbRecipe].[dbo].[proc_Update_Recipe]",
                new
                {
                    Recipe.RecipeID,
                    Recipe.Name,
                    Recipe.Instructions,
                    Recipe.ImageName,
                    Recipe.IngredientsSelectedText,
                    Recipe.IngredientsDeletedText,
                    Recipe.DateAdded,
                    Recipe.UserID,
                    Recipe.Username,
                    Recipe.CreatedOn,
                    Recipe.CreatedByuserID

                },
                commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<Model.Recipe>> UserRecipes(int userID)
        {
            const string sql = "SELECT * FROM Recipe WHERE UserID = @userID";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Query<Model.Recipe>(sql, new { userID = userID }).ToList();
        }

        public async Task<bool> DeleteAsync(Recipe Recipe)
        {
            try
            {
                await using var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
                return connection.Query<bool>("[dbRecipe].[dbo].[proc_Delete_Recipe]",
                new
                {
                    Recipe.RecipeID,
                    Recipe.Name,
                    Recipe.Instructions,
                    Recipe.ImageName,
                    Recipe.DateAdded,
                    Recipe.UserID,
                    Recipe.Username,
                    Recipe.CreatedOn,
                    Recipe.CreatedByuserID,
                    Recipe.DeletedOn,
                    Recipe.DeletedByUserID

                },
                commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<Recipe>> ActiveRecipes()
        {
            const string sql = "SELECT * FROM Recipe WHERE DeletedOn IS NULL";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Query<Model.Recipe>(sql).ToList();
        }
    }
}
