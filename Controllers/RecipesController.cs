using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSharingApp.Model;
using RecipeSharingApp.Repository;

namespace RecipeSharingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesRepository _recipesRepository;

        public RecipesController(IRecipesRepository recipesRepository)
        {
            _recipesRepository = recipesRepository;
        }

    [HttpPost("createRecipe")]
        public async Task<IActionResult> createNewRecipe(Recipes recipes)
        {
            var result = await _recipesRepository.CreateRecipe(recipes);
            return new JsonResult(result.ToString());
        }

        [HttpGet("getByRecipeName/{RecipeName}")]
        public async Task<IActionResult> FetchRecipeByRecipeName(string RecipeName)
        {
            Recipes result = await _recipesRepository.GetRecipeByRecipeName(RecipeName);
            return new JsonResult(result);
        }
        [HttpPut("updateRecipe/{RecipeName}")]
        public async Task<IActionResult> UpdateRecipeByFoodName(string RecipeName, Recipes recipes)
        {
            bool result = await _recipesRepository.UpdateRecipeByFoodName(RecipeName, recipes);
            return new JsonResult(result.ToString());
        }

        [HttpDelete("deleteRecipe/{RecipeName}")]
        public async Task<IActionResult> DeleteRecipeByFoodName(string RecipeName)
        {
            bool result = await _recipesRepository.DeleteRecipeByFoodName(RecipeName);
            return new JsonResult(result.ToString());
        }

        [HttpGet("getAllRecipes")]
        public async Task<IActionResult> FetchAllRecipes()
        {
            var result = await _recipesRepository.GetAllRecipes();
            return new JsonResult(result);
        }

    }
    
}
