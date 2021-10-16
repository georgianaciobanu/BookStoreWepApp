using BookStoreApp.Models.DTOs.VM;
using BookStoreApp.Models.Interfaces;
using BookStoreApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Web.Controllers {
    public class HomeController : Controller {
        private readonly IBookService bookService;

        public HomeController(IBookService bookService) {
            this.bookService = bookService;
        }

        [HttpGet]
        public IActionResult Index() {
            var books = bookService.GetAllBooks();
            return View(books);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public IActionResult Details(int id) {
            var book = bookService.GetBook(id);
            return View(book);
        }

        [HttpPost]
        [Route("Add/{id}")]
        public IActionResult Add(BookVM item) {
            var shopList = HttpContext.Session.Get<List<BookVM>>(SessionHelper.ShoppingCart);

            if (shopList == null)
                shopList = new List<BookVM>();

            if (!shopList.Contains(item))
                shopList.Add(bookService.GetBook(item.Id));

            HttpContext.Session.Set(SessionHelper.ShoppingCart, shopList);

            return RedirectToAction("Index", "Home", bookService.GetAllBooks());
        }

        [HttpPost]
        [Route("Remove/{id}")]
        public IActionResult Remove(BookVM item) {
            var shopList = HttpContext.Session.Get<List<BookVM>>(SessionHelper.ShoppingCart);

            if (shopList == null)
                return RedirectToAction("Index", "Home", bookService.GetAllBooks());

            if (shopList.Contains(item))
                shopList.Remove(item);

            HttpContext.Session.Set(SessionHelper.ShoppingCart, shopList);

            return RedirectToAction("Index", "Home", bookService.GetAllBooks());
        }
    }
}
