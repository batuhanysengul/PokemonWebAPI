using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        //
        private DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        //

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            //using nested entity 
            return _context.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }
        
        //post & create
        public bool CreateCategory(Category category)
        {
            //change tracker = (add, update, modify vs bunları trackliyor Add kullanıldığında)
            //EntityState.Added gördüğünde disconnected state olduğunu anla. Denk gelirsen öğren çok önemli değil
            _context.Add(category);
            return Save();
            
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
