

using BookStoreApp.Models.Attributes;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Models.DTOs.VM {
   public class BookVM {

        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        [Required]
        [MaxLength(256)]
        public string Author { get; set; }
        [Required]
        [MaxLength(256)]
        public string Publisher { get; set; }
        public decimal PagesNo { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public int BookTypeId { get; set; }

        public string BookTypeName { get; set; }

        public List<IdNameDto> BookTypes { get; set; }

        [AllowedExtensions(".jpg", ".png", ".jpeg")]
        [MaxFileSize(3 * 1024 * 1024)]
        public IFormFile BookImage { get; set; }


    }
}
