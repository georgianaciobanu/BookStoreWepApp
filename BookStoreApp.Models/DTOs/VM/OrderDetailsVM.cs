using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Models.DTOs.VM {
    public class OrderDetailsVM {

        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(256)]
        public string CustomerPhoneNumber { get; set; }
        [Required]
        [MaxLength(256)]
        public string CustomerEmail { get; set; }
        [Required]
        [MaxLength(500)]
        public string CustomerAddress { get; set; }
        public DateTime OrderDate { get; set; }
       
        public List<BookVM> BookList { get; set; }


    }
}
