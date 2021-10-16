using System;
using System.Collections.Generic;

#nullable disable

namespace BookStoreApp.Models.Entites
{
    public partial class Book : IEntity<int> {

    
        public Book()
        {
            BooksSpecialTags = new HashSet<BooksSpecialTag>();
            Feedbacks = new HashSet<Feedback>();
            OrdersBooks = new HashSet<OrdersBook>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public decimal PagesNo { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string ImagePath { get; set; }
        public int BookTypeId { get; set; }

        public virtual BookType BookType { get; set; }
        public virtual ICollection<BooksSpecialTag> BooksSpecialTags { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<OrdersBook> OrdersBooks { get; set; }
    }
}
