using PSP_PoS.Components.Tax;

namespace PSP_PoS.Components.Category
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Category? GetCategoryById(Guid categoryId);
        Category AddCategory(CategoryDto category);
        bool UpdateCategory(CategoryDto category, Guid id);
        void DeleteCategory(Guid categoryId);
    }
}
