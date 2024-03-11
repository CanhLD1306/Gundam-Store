using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GundamStore.Models
{
    [Table("Categories")]

    public class Category
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        [Column(TypeName = "nvarchar(100)")]
        public string? Name { get; set; }

        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        [Column(TypeName = "nvarchar(500)")]
        public string? Description { get; set; }

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
