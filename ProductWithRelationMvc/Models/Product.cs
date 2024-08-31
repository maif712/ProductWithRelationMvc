namespace ProductWithRelationMvc.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Foreign key for Category
        public int CategoryId { get; set; }

        // Navigation property
        public Category? Category { get; set; }
    }
}
