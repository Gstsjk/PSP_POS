namespace PSP_PoS.Components.CategoryComponent
{
    public interface ICategoryService
    {
        List<CategoryReadDto> GetAllCategories();
        CategoryReadDto GetCategoryById(Guid categoryId);
        Category AddCategory(CategoryCreateDto categoryCreateDto);
        bool UpdateCategory(CategoryCreateDto categoryCreateDto, Guid id);
        void DeleteCategory(Guid categoryId);
    }
}
