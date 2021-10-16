using System;
using System.Collections.Generic;

#nullable disable

namespace BookStoreApp.Models.Entites
{
    public partial class Feedback: IEntity<int> {
        public int Id { get; set; }
        public string CommentTitle { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public int BookId { get; set; }
        public Guid? UserId { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
