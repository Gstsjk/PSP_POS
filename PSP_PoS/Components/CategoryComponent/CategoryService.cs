using PSP_PoS.Data;

namespace PSP_PoS.Components.CategoryComponent
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public List<CategoryReadDto> GetAllCategories()
        {
            List<Category> categories = _context.Categories.ToList();
            List<CategoryReadDto> categoryReadDtos = new List<CategoryReadDto>();

            foreach (var category in categories)
            {
                CategoryReadDto categoryReadDto = new CategoryReadDto(category);
                categoryReadDtos.Add(categoryReadDto);
            }
            return categoryReadDtos;
        }

        public CategoryReadDto GetCategoryById(Guid categoryId)
        {
            var category = _context.Categories.FirstOrDefault(t => t.Id == categoryId)!;
            CategoryReadDto categoryRead = new CategoryReadDto(category);
            return categoryRead;
        }

        public Category AddCategory(CategoryCreateDto categoryCreateDto)
        {
            Category category = new Category(categoryCreateDto);
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public bool UpdateCategory(CategoryCreateDto categoryDto, Guid id)
        {
            Category? category = _context.Categories.Find(id);
            if (category == null)
            {
                return false;
            }
            category.Name = categoryDto.Name;

            _context.Categories.Update(category);
            _context.SaveChanges();
            return true;
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
