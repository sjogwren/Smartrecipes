using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartReservation.Interface
{
    public interface IIngredient
    {
        Task<Model.Ingredients> CreateAsync(Model.Ingredients Ingredients);
        Task<bool> UpdateAsync(Model.Ingredients Ingredients);
        Task<List<Model.Ingredients>> Ingredients();
        Task<Model.Ingredients> FindByIdAsync(int IngredientID);
        Task<Model.Ingredients> CheckIfIngredientExist(string Name);
        Task<List<Model.RecipeIngredients>> GetRecipeIngredientsAllByID(int RecipeID);
    }
}
