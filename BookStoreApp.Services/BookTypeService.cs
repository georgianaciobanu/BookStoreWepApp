using AutoMapper;
using BookStoreApp.DataAccess.Interface;
using BookStoreApp.Models.DTOs.VM;
using BookStoreApp.Models.Entites;
using BookStoreApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Services {

    public class BookTypeService : IBookTypeService {

        private readonly IRepository<BookType, int> bookTypeRep;
        private readonly IMapper mapper;
       
        public BookTypeService(IRepository<BookType,int> bookTypeRep, IMapper mapper) {
            this.bookTypeRep = bookTypeRep;
            this.mapper = mapper;
        }
        
        public void AddBookType(BookTypeVM dto) {
            var entity = mapper.Map<BookType>(dto);
            bookTypeRep.Add(entity);
        }

        public void DeleteBookType(int id) {
            var entity = bookTypeRep.GetInstance(id);
            if (entity == null)
                return;

            bookTypeRep.Delete(entity);
        }

        public IEnumerable<BookTypeVM> GetAllBookType() {
            var books = bookTypeRep.GetAll();
            return mapper.Map<List<BookTypeVM>>(books);
        }

        public BookTypeVM GetBookType(int id) {
            var entity = bookTypeRep.GetInstance(id);
            return mapper.Map<BookTypeVM>(entity);

        }

        public void UpateBookType(int id, BookTypeVM dto) {
            var entity = bookTypeRep.GetInstance(id);
            if (entity == null)
                return;
            mapper.Map(dto, entity);
            bookTypeRep.Update(entity);
        }
    }
}
