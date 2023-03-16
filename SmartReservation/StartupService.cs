using Microsoft.Extensions.DependencyInjection;
using SmartReservation.Interface;
using SmartReservation.Service;

namespace SmartReservation
{
    public class StartupService
    {
        public static void AddService(IServiceCollection services)
        {
            services.AddScoped<IRole, RoleService>();
            services.AddScoped<IExternalUser, ExternalUserService>();
            services.AddScoped<IExternalUserRole, ExternalUserRoleService>();
            services.AddScoped<IRecipe, RecipeService>();
            services.AddScoped<IIngredient, IngredientService>();
            services.AddScoped<IRecipeMetric, RecipeMetricService>();
        }
    }
}
