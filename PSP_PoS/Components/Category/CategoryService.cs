using PSP_PoS.Data;

namespace PSP_PoS.Components.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
        public Category GetCategoryById(Guid categoryId)
        {
            return _context.Categories.FirstOrDefault(t => t.Id == categoryId);
        }
        public void AddCategory(Category category)
        { 
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(Guid categoryId)
        {
            var category = _context.Categories.FirstOrDefault(t => t.Id == categoryId);

            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
