using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GundamStore.Models
{
    [Table("Banners")]
    public class Banner
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [MaxLength(255, ErrorMessage = "Image URL cannot exceed 255 characters")]
        [Column(TypeName = "nvarchar(255)")]
        public string? Image { get; set; }

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
    }
}
