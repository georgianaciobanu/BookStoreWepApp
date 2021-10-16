
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BookStoreApp.Models.DTOs.VM {

    public class BookTypeVM {

        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

       
    }
}
