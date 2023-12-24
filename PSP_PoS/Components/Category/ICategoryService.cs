using PSP_PoS.Components.Tax;

namespace PSP_PoS.Components.Category
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(Guid categoryId);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Guid categoryId);
    }
}
