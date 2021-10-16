using BookStoreApp.Models.DTOs;
using BookStoreApp.Models.DTOs.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Models.Interfaces {
    public interface IBookService {


        IEnumerable<BookVM> GetAllBooks();
        BookVM GetBook(int id);
        List<BookTypeVM> GetBooksTypes();

        void AddBook(BookVM dto);
        void UpateBook(int id, BookVM dto);
        void DeleteBook(int id);
        List<IdNameDto> GetBookTypes();
    }
}
