using AutoMapper;
using BookStoreApp.Models.DTOs.VM;
using BookStoreApp.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Models {
    public static class MapperConfig {
        public static IMapper GetMapper() {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<BookType, BookTypeVM>();
                cfg.CreateMap<BookTypeVM, BookType>();
                cfg.CreateMap<OrderDetailsVM, Order>();
                cfg.CreateMap<OrderDetailsVM, OrdersBook>();
                cfg.CreateMap<Book, BookVM>();
                cfg.CreateMap<BookVM, Book>();
                cfg.CreateMap<Order, OrderDetailsVM>();
                cfg.CreateMap<OrdersBook, OrderDetailsVM>();

            });

            return config.CreateMapper();
        }

    }
}
