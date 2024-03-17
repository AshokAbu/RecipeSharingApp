using MongoDB.Bson;
using RecipeSharingApp.Model;

namespace RecipeSharingApp.Repository
{
    public interface IRecipesRepository
    {
        Task <ObjectId> CreateRecipe (Recipes recipes);
        Task<Recipes> GetRecipeByRecipeName(string RecipeName);

        Task<bool> UpdateRecipeByFoodName(string RecipeName, Recipes recipes);
        Task<bool> DeleteRecipeByFoodName(string RecipeName);

        Task<List<Recipes>> GetAllRecipes();
    }
}
