using System.ComponentModel.DataAnnotations;

namespace EcommerceWebsite.Models
{
    public class Product 
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50, ErrorMessage = "Please enter Category name")]
        public string Name { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required, MaxLength(500, ErrorMessage = "PLease enter Category Description")]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int SizeId { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Discount { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public int CreatedBy { get; set; }

        [Required]
        public int UpdatedBy { get; set; }

        [Required]
        public bool DeleteFlag { get; set; }
        
        public Category category { get; set; }

        public Size Size { get; set; }

        public List<ProductImage> Images { get; set; }
    }
}
