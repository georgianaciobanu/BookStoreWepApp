using System;
using System.Collections.Generic;

#nullable disable

namespace BookStoreApp.Models.Entites
{
    public partial class BooksSpecialTag
    {
        public int SpecialTagId { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
        public virtual SpecialTag SpecialTag { get; set; }
    }
}
