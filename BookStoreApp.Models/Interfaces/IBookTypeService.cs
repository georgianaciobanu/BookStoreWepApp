using BookStoreApp.Models.DTOs;
using BookStoreApp.Models.DTOs.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Models.Interfaces {
    public interface IBookTypeService {

        IEnumerable<BookTypeVM> GetAllBookType();
        BookTypeVM GetBookType(int id);

        void AddBookType(BookTypeVM dto);
        void UpateBookType(int id, BookTypeVM dto);
        void DeleteBookType(int id);

       





    }
}
