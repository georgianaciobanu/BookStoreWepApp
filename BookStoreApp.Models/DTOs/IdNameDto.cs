using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Models.DTOs {
    public class IdNameDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }

        public IdNameDto() {
        }

        public IdNameDto(int id, string name) {
            Id = id;
            Name = name;
        }
    }
}
