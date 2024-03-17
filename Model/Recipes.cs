using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RecipeSharingApp.Model
{
    public class Recipes
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId  Id { get; set; }
        public string RecipeName { get; set; }
        public string RecipeDescription { get; set;}
        public string RecipeType { get; set;}
        public int RecipePrice { get; set;}

    }
}
