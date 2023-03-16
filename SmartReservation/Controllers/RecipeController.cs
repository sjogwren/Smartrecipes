using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartReservation.Interface;
using SmartReservation.Model;
using SmartReservation.Models;
using SmartReservation.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SmartReservation.Controllers
{
    [Authorize]
    public class RecipeController : Controller
    {
        private readonly IRecipe _recipe;
        private readonly IIngredient _ingredient;
        private readonly IRecipeMetric _recipeMetric;
        private readonly IExternalUser _externalUser;
        private IWebHostEnvironment _hostingEnv;
        public RecipeController(IRecipe recipe, IIngredient ingredient, IExternalUser externalUser, IWebHostEnvironment env, IRecipeMetric recipeMetric)
        {
            _recipe = recipe;
            _externalUser = externalUser;
            _ingredient = ingredient;
            this._hostingEnv = env;
            _recipeMetric = recipeMetric;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Currentrecipes(string clicked)
        {
            if (User.IsInRole("Admin"))
            {
                var recipe = await _recipe.Recipes();
                if (clicked == null)
                {
                    var DisplayCount = await _recipeMetric.GetDisplayCount();
                    var newCount = recipe.Take(DisplayCount.DisplayOrder).ToList();
                    return View(newCount);
                }
                return View(recipe);
            }
            else
            {
                var recipe = await _recipe.ActiveRecipes();
                if (clicked == null)
                {
                    var DisplayCount = await _recipeMetric.GetDisplayCount();
                    var newCount = recipe.Take(DisplayCount.DisplayOrder).ToList();
                    return View(newCount);
                }
                return View(recipe);
            }

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Newrecipe()
        {
            var recipeModel = new Recipe();
            recipeModel.IngredientsDDL = new SelectList(await _ingredient.Ingredients(), "IngredientID", "Name");
            return View(recipeModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Newrecipe(Recipe model, IFormFile File)
        {
            var exists = await _recipe.CheckIfRecipeExist(model.Name);
            if(exists.RecipeID == 1)
            {
                model.IngredientsDDL = new SelectList(await _ingredient.Ingredients(), "IngredientID", "Name");
                model.UniqueRecipe = "Recipe Already Exists";
                return View(model);
            }

            if (File.Length > 0 && File.Length <= 4000000)
            {
                var FileDic = "Files";
                string FilePath = Path.Combine(_hostingEnv.WebRootPath, FileDic);
                if (!Directory.Exists(FilePath))
                    Directory.CreateDirectory(FilePath);
                var fileName = File.FileName;
                var filePath = Path.Combine(FilePath, fileName);
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    File.CopyTo(fs);
                }

                model.Username = User.Identity.Name;
                var currentUser = await _externalUser.FindByNameAsync(model.Username);
                model.UserID = currentUser.ExternalUserID;
                model.CreatedOn = DateTime.Now;
                model.ImageName = File.FileName;
                model.DateAdded = DateTime.Now;
                model.CreatedByuserID = currentUser.ExternalUserID;

            }
            var result = await _recipe.CreateAsync(model);
            const string redirectUrl = "/Recipe/Currentrecipes";

            return result ? RedirectToAction("Message", "Home", new { type = StringHelper.Types.SaveSuccess, url = redirectUrl })
                          : RedirectToAction("Message", "Home", new { type = StringHelper.Types.SaveFailed, url = redirectUrl });

        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Details(int recipeID)
        {
            DetailViewModel dm = new DetailViewModel();
            dm.Recipe = await _recipe.FindByIdAsync(recipeID);
            dm.RecipeIngredientsList = await _recipe.GetIngredientsByID(recipeID);
            return View(dm);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int recipeID, string btnClick)
        {
            DetailViewModel dm = new DetailViewModel();
            dm.Recipe = await _recipe.FindByIdAsync(recipeID);
            if (btnClick == "Activate")
            {
                dm.Recipe.DeletedOn = null;
                dm.Recipe.DeletedByUserID = null;
                _ = await _recipe.DeleteAsync(dm.Recipe);
                return RedirectToAction("Details", "Recipe", new { recipeID = recipeID });

            }
            else
            {
                dm.Recipe.DeletedOn = DateTime.Now;
                dm.Recipe.DeletedByUserID = User.GetUserId();
                dm.recipeID = recipeID;

                var result = await _recipe.DeleteAsync(dm.Recipe);

                return RedirectToAction("Details", "Recipe", new { recipeID = recipeID });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int recipeID)
        {
            DetailViewModel dm = new DetailViewModel();
            dm.Recipe = await _recipe.FindByIdAsync(recipeID);
            dm.RecipeIngredientsList = await _recipe.GetIngredientsByID(recipeID);
            dm.IngredientsList = await _ingredient.Ingredients();
            dm.recipeID = recipeID;
            dm.IngredientsDDL = new SelectList(await _ingredient.Ingredients(), "IngredientID", "Name");
            return View(dm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(DetailViewModel model, IFormFile File)
        {
            DetailViewModel dm = new DetailViewModel();
            dm.Recipe = await _recipe.FindByIdAsync(model.recipeID);
            dm.Recipe.IngredientsSelectedText = model.Recipe.IngredientsSelectedText;
            dm.Recipe.IngredientsDeletedText = model.Recipe.IngredientsDeletedText;
            if(File == null)
            {
                dm.Recipe.ImageName = dm.Recipe.ImageName;
                var result = await _recipe.UpdateAsync(dm.Recipe);
            }
            else
            {
                dm.Recipe.ImageName = File.FileName;
                if (File.Length > 0 && File.Length <= 4000000)
                {
                    var FileDic = "Files";
                    string FilePath = Path.Combine(_hostingEnv.WebRootPath, FileDic);
                    if (!Directory.Exists(FilePath))
                        Directory.CreateDirectory(FilePath);
                    var fileName = File.FileName;
                    var filePath = Path.Combine(FilePath, fileName);
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        File.CopyTo(fs);
                    }
                }
                var result = await _recipe.UpdateAsync(dm.Recipe);
            }
            return RedirectToAction("Details", "Recipe", new { recipeID = dm.Recipe.RecipeID });
        }
    }
}
