using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GundamStore.Models
{
    public class Product
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "CategoryId is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "SizeId is required")]
        public int SizeId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        [Column(TypeName = "nvarchar(100)")]
        public string? Name { get; set; }

        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        [Column(TypeName = "nvarchar(500)")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Discount { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Active is required")]
        [Column(TypeName = "bit")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "CreateAt is required")]
        [Column(TypeName = "datetime")]
        public DateTime CreateAt { get; set; }

        [Required(ErrorMessage = "CreateBy is required")]
        public int CreateBy { get; set; }

        [Required(ErrorMessage = "UpdateAt is required")]
        [Column(TypeName = "datetime")]
        public DateTime UpdateAt { get; set; }

        [Required(ErrorMessage = "UpdateBy is required")]
        public int UpdateBy { get; set; }

        [Required(ErrorMessage = "DeleteFlag is required")]
        [Column(TypeName = "bit")]
        public bool DeleteFlag { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        [ForeignKey("SizeId")]
        public Size? Size { get; set; }
        public ICollection<ProductImage>? ProductImages { get; set; }
    }
}
