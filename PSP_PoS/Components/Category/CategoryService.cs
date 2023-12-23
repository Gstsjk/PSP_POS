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

        public List<CategoryModel> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
        public CategoryModel GetCategoryById(Guid categoryId)
        {
            return _context.Categories.FirstOrDefault(t => t.Id == categoryId);
        }
        public void AddCategory(CategoryModel category)
        { 
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        public void UpdateCategory(CategoryModel category)
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
