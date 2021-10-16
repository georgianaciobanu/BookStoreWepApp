using System;
using System.Collections.Generic;

#nullable disable

namespace BookStoreApp.Models.Entites
{
    public partial class SpecialTag: IEntity<int> {
        public SpecialTag()
        {
            BooksSpecialTags = new HashSet<BooksSpecialTag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BooksSpecialTag> BooksSpecialTags { get; set; }
    }
}
