﻿using System.ComponentModel.DataAnnotations;

namespace EcommerceWebsite.Models
{
    public class Banner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required]
        public string ImageUrl { get; set; }

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