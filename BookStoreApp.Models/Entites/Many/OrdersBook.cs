using System;
using System.Collections.Generic;

#nullable disable

namespace BookStoreApp.Models.Entites
{
    public partial class OrdersBook:IEntity<int>
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int OrderId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
    }
}
