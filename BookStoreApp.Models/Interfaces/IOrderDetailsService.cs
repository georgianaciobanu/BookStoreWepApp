using BookStoreApp.Models.DTOs;
using BookStoreApp.Models.DTOs.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Models.Interfaces {
    public interface IOrderDetailsService {

        IEnumerable<OrderDetailsVM> GetAllOrderDetails();
        OrderDetailsVM GetOrderDetails(int id);

        void AddOrderDetails(OrderDetailsVM dto);
        void DeleteOrderDetails(int id);
        List<BookVM> GetBookList();
        BookVM GetBookFromOrder(int id);

    }
        
}
