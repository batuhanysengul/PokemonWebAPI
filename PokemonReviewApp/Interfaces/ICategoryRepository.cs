using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonByCategory(int categoryId); //nested entity
        bool CategoryExists(int id);

        //post & create
        bool CreateCategory(Category category);
        bool Save();

    }
}
