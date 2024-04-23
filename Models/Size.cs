using System.ComponentModel.DataAnnotations;

namespace EcommerceWebsite.Models
{
    public class Size
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20, ErrorMessage = "Please enter Size name")]
        public string Name { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required, MaxLength(50, ErrorMessage = "PLease enter Size description")]
        public string Description { get; set; }

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
    }
}
