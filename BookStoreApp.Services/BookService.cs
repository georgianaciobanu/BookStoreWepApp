using AutoMapper;
using BookStoreApp.DataAccess.Interface;
using BookStoreApp.Models.DTOs;
using BookStoreApp.Models.DTOs.VM;
using BookStoreApp.Models.Entites;
using BookStoreApp.Models.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Services {

    public class BookService : IBookService {

        private const string
           imgFolderName = "img";

        private readonly IRepository<Book, int> bookRep;
        private readonly IRepository<BookType, int> bookTypeRep;
        private readonly IMapper mapper;
        private readonly IHostingEnvironment hostingEnvironment;


        public BookService(IRepository<Book, int> bookRep, IRepository<BookType, int> bookTypeRep, IMapper mapper, IHostingEnvironment hostingEnvironment) {
            this.bookRep = bookRep;
            this.bookTypeRep = bookTypeRep;
            this.mapper = mapper;
            this.hostingEnvironment = hostingEnvironment;
        }

        public void AddBook(BookVM dto) {
            SaveImage(dto);
            
            var entity = mapper.Map<Book>(dto);
            bookRep.Add(entity);
        }

        public void DeleteBook(int id) {
            
            
            var entity = bookRep.GetInstance(id);

            if (!string.IsNullOrWhiteSpace(entity.ImagePath)) {
                var filePath = Path.Combine(hostingEnvironment.WebRootPath, entity.ImagePath);

                if (File.Exists(filePath))
                    File.Delete(filePath);
            }

            bookRep.Delete(entity);
        }

        public IEnumerable<BookVM> GetAllBooks() {
            var list = bookRep.GetAll();
            return mapper.Map<List<BookVM>>(list);
        }

        public BookVM GetBook(int id) {
            var entity = bookRep.GetInstance(id);
            return mapper.Map<BookVM>(entity);
        }

        public void UpateBook(int id, BookVM dto) {
            var entity = bookRep.GetInstance(id);

            var oldFileRelativePath = entity.ImagePath;
            if (dto.BookImage == null)
                dto.ImagePath = oldFileRelativePath;
            else {
                if (!string.IsNullOrWhiteSpace(oldFileRelativePath)) {
                    var olfFileFullPath = Path.Combine(hostingEnvironment.WebRootPath, oldFileRelativePath);
                    if (File.Exists(olfFileFullPath))
                        File.Delete(olfFileFullPath);
                }

                SaveImage(dto);
            }


            mapper.Map(dto, entity);
            bookRep.Update(entity);
        }
        public List<IdNameDto> GetBookTypes() {
            return bookTypeRep.GetAll().Select(e => new IdNameDto(e.Id, e.Name)).ToList();
        }
        public List<BookTypeVM> GetBooksTypes() {
            var list = bookTypeRep.GetAll();

            return mapper.Map<List<BookTypeVM>>(list);
        }
        private void SaveImage(BookVM dto) {
            if (dto.BookImage == null)
                return;
            var imgFolderPath= Path.Combine(hostingEnvironment.WebRootPath, imgFolderName);

            if (!Directory.Exists(imgFolderPath))
                Directory.CreateDirectory(imgFolderPath);

            var fileName = Guid.NewGuid() + Path.GetExtension(dto.BookImage.FileName);
            var imgFullPath = Path.Combine(imgFolderPath, fileName);

            using (var fileStream = new FileStream(imgFullPath, FileMode.Create))
                dto.BookImage.CopyTo(fileStream);

            dto.ImagePath = Path.Combine(imgFolderName, fileName);
        }
    }
}
