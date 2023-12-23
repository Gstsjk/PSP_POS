using PSP_PoS.Components.Tax;

namespace PSP_PoS.Components.Category
{
    public interface ICategoryService
    {
        List<CategoryModel> GetAllCategories();
        CategoryModel GetCategoryById(Guid categoryId);
        void AddCategory(CategoryModel category);
        void UpdateCategory(CategoryModel category);
        void DeleteCategory(Guid categoryId);
    }
}
