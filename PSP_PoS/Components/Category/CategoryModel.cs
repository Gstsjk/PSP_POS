namespace PSP_PoS.Components.Category
{
    public class CategoryModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; } // in cents
        public Guid Parent {  get; set; }
    }
}
