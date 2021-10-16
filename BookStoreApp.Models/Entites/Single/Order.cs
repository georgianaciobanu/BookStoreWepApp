using System;
using System.Collections.Generic;

#nullable disable

namespace BookStoreApp.Models.Entites
{
    public partial class Order: IEntity<int> 
    {
        public Order()
        {
            OrdersBooks = new HashSet<OrdersBook>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrdersBook> OrdersBooks { get; set; }
    }
}
