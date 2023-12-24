using PSP_PoS.Components.TaxComponent;

namespace PSP_PoS.Components.CategoryComponent
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
