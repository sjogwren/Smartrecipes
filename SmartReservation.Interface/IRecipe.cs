using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartReservation.Interface
{
    public interface IRecipe
    {
        Task<bool> CreateAsync(Model.Recipe Recipe);
        Task<bool> UpdateAsync(Model.Recipe Recipe);
        Task<List<Model.Recipe>> UserRecipes(int userID);
        Task<List<Model.Recipe>> Recipes();
        Task<Model.Recipe> FindByIdAsync(int ReceipeID);
        Task<Model.Recipe> CheckIfRecipeExist(string Name);
        Task<List<Model.RecipeIngredients>> GetIngredientsByID(int RecipeID);
        Task<bool> DeleteAsync(Model.Recipe Recipe);
        Task<List<Model.Recipe>> ActiveRecipes();
    }
}
