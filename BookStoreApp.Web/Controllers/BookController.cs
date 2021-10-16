using BookStoreApp.Models.DTOs.VM;
using BookStoreApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace BookStoreApp.Web.Controllers {

    [Route("[Controller]")]
    public class BookController : Controller {

        private readonly IBookService service;
        private readonly IBookTypeService serviceTypes;

        public BookController(IBookService service, IBookTypeService serviceTypes) {
            this.service = service;
            this.serviceTypes = serviceTypes;
        }

        [HttpGet]
        public IActionResult Index(string selectedBookTypeName, string searchString) {
            var list = service.GetAllBooks();
           
            
            if (!String.IsNullOrEmpty(searchString)) {
               list = list.Where(s => s.Name.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(selectedBookTypeName)) {
                var typeId = serviceTypes.GetAllBookType().Where(s => s.Name.Equals(selectedBookTypeName)).FirstOrDefault().Id;
                list = list.Where(s => s.BookTypeId == typeId);
            }

            var listTypes = service.GetBooksTypes();
            var BookTypes = new SelectList(listTypes.Select(
              g => g.Name)).ToList();


            
            ViewBag.BookTypes = BookTypes;
            

          
            
            return View(list);
        }


        [HttpGet]
        [Route("New")]
        public IActionResult New() {
            var dto = new BookVM();
            dto.BookTypes = service.GetBookTypes();
            return View(dto);
        }


        [HttpPost]
        [Route("New")]
        public IActionResult New(BookVM dto) {
            if (!ModelState.IsValid) {
                ModelState.AddModelError(string.Empty, "There were some errors in your form");                        
                return View(dto);
            }
            var list= serviceTypes.GetAllBookType();
            dto.BookTypes = service.GetBookTypes();
            dto.BookTypeName = list.Where(s => s.Id == dto.BookTypeId).FirstOrDefault().Name;

            service.AddBook(dto);

            return View("Index", service.GetAllBooks());
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id) {
            var dto = service.GetBook(id);
            dto.BookTypes = service.GetBookTypes();
            var list = serviceTypes.GetAllBookType();
            dto.BookTypeName = list.Where(s => s.Id == dto.BookTypeId).FirstOrDefault().Name;

            return View(dto);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id, BookVM dto) {
            if (!ModelState.IsValid) {
                ModelState.AddModelError(string.Empty, "There were some errors in your form");
                dto.BookTypes = service.GetBookTypes();
                 var list = serviceTypes.GetAllBookType();
            dto.BookTypeName = list.Where(s => s.Id == dto.BookTypeId).FirstOrDefault().Name;
                return View(dto);
            }

            service.UpateBook(id, dto);

            return View("Index", service.GetAllBooks());
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public JsonResult Delete(int id) {
            service.DeleteBook(id);
            return Json(new { success = true, message = "Delete success" });
        }

    }
}
