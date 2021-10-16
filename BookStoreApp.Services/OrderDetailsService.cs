using AutoMapper;
using BookStoreApp.DataAccess.Interface;
using BookStoreApp.Models.DTOs;
using BookStoreApp.Models.DTOs.VM;
using BookStoreApp.Models.Entites;
using BookStoreApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Services {
    public class OrderDetailsService: IOrderDetailsService {

        private readonly IRepository<Book, int> booksRep;
        private readonly IRepository<Order, int> orderRep;
        private readonly IRepository<OrdersBook,int> orderDetailsRep;



        private readonly IMapper mapper;

        public OrderDetailsService(IRepository<Book, int> booksRep, IRepository<Order, int> orderRep, IMapper mapper, IRepository<OrdersBook, int> orderDetailsRep) {
            this.booksRep = booksRep;
            this.orderRep = orderRep;
            this.mapper = mapper;
            this.orderDetailsRep = orderDetailsRep;
        }

        public void AddOrderDetails(OrderDetailsVM dto) {

            var entity = mapper.Map<Order>(dto);
            entity.OrderDate = DateTime.Now;
            
         
            orderRep.Add(entity);

            foreach (var item in dto.BookList) {
                OrdersBook orderBook = new OrdersBook();
                orderBook.Id = 0;
                orderBook.BookId = item.Id;
                orderBook.OrderId = entity.Id;

                orderDetailsRep.Add(orderBook);


            }
        }

        public void DeleteOrderDetails(int id) {
            var entity = orderRep.GetInstance(id);

            orderRep.Delete(entity);
        }

        public IEnumerable<OrderDetailsVM> GetAllOrderDetails() {
            var list = orderRep.GetAll();
            return mapper.Map<List<OrderDetailsVM>>(list);
        }

        public List<BookVM> GetBookList() {
            List<BookVM> list= (List<BookVM>)booksRep.GetAll();
            return list;
        }
        public BookVM GetBookFromOrder(int id) {
            var book = booksRep.GetInstance(id);
            return mapper.Map<BookVM>(book);
        }

        public OrderDetailsVM GetOrderDetails(int id) {
            var entity = orderRep.GetInstance(id);
            return mapper.Map<OrderDetailsVM>(entity);
        }

        
    }
}
