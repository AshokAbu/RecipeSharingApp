using MongoDB.Bson;
using MongoDB.Driver;
using RecipeSharingApp.Model;

namespace RecipeSharingApp.Repository
{
    public class RecipesRepository : IRecipesRepository
    {
        private readonly IMongoCollection<Recipes> _recipes;

        public RecipesRepository(IMongoClient mongoClient)
        {
            var db = mongoClient.GetDatabase("RecipesDb");
            var collection = db.GetCollection<Recipes>(nameof(Recipes));
            _recipes = collection;
        }
        public async Task<ObjectId> CreateRecipe(Recipes recipes)
        {
           await _recipes.InsertOneAsync(recipes);
            return recipes.Id;

        }
        public async Task<Recipes> GetRecipeByRecipeName(string RecipeName)
        {
            var filter = Builders<Recipes>.Filter.Eq(e => e.RecipeName, RecipeName);
            Recipes recipeinfo = await _recipes.Find(filter).FirstOrDefaultAsync();
            return recipeinfo;
        }

        public async Task<bool> UpdateRecipeByFoodName(string RecipeName, Recipes recipes)
        {
            var filter = Builders<Recipes>.Filter.Eq(e => e.RecipeName, RecipeName);
            var update = Builders<Recipes>.Update
                .Set(e => e.RecipeName, recipes.RecipeName)
                .Set(e => e.RecipeDescription, recipes.RecipeDescription)
                .Set(e => e.RecipeType, recipes.RecipeType)
                .Set(e => e.RecipePrice, recipes.RecipePrice);

            var result = await _recipes.UpdateOneAsync(filter, update);
            return result.ModifiedCount == 1;
        }
        public async Task<bool> DeleteRecipeByFoodName(string RecipeName)
        {
            var filter = Builders<Recipes>.Filter.Eq(e => e.RecipeName, RecipeName);
            var result = await _recipes.DeleteOneAsync(filter);
            return result.DeletedCount == 1;
        }

        public async Task<List<Recipes>> GetAllRecipes()
        {
            return await _recipes.Find(e => true).ToListAsync();
        }



    }
}
