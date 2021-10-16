using AutoMapper;
using BookStoreApp.Models.DTOs.VM;
using BookStoreApp.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Web.Controllers {
    public class OrderDetailsController : Controller {
        
        private readonly IOrderDetailsService orderDetailsService;
       private readonly IMapper mapper;
        private readonly IBookService bookService;

        public OrderDetailsController(IOrderDetailsService orderDetailsService, IMapper mapper, IBookService bookService) {
            this.orderDetailsService = orderDetailsService;
            this.mapper = mapper;
            this.bookService = bookService;
        }

        [HttpGet]
        public IActionResult Index() {
            var order = orderDetailsService.GetAllOrderDetails();
            return View(order);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public JsonResult Delete(int id) {
            orderDetailsService.DeleteOrderDetails(id);
            return Json(new { success = true, message = "Delete success" });
        }




        [HttpGet]
        [Route("New")]
        public IActionResult New() {
            var dto = new OrderDetailsVM();
            return View(dto);
        }

        [HttpPost]
        [Route("New")]
        public IActionResult New(OrderDetailsVM dto) {
            if (!ModelState.IsValid) {
                ModelState.AddModelError(string.Empty, "There were some errors in your form!");
                return View(dto);
            }
            var shopList = HttpContext.Session.Get<List<BookVM>>(SessionHelper.ShoppingCart);
            dto.BookList = new List<BookVM>();
            if(shopList!=null)
            foreach(var item in shopList) {
                dto.BookList.Add(item);
            }

           
            var list = bookService.GetAllBooks();
       
                var listToSend =  mapper.Map<List<BookVM>>(list);

            if (dto.BookList == null || dto.BookList.Count==0) {
                ModelState.AddModelError(string.Empty, "There were some errors in your form!");
                return View(dto);
            } else {
                orderDetailsService.AddOrderDetails(dto);
            }
           
           
           
            HttpContext.Session.Set(SessionHelper.ShoppingCart, new List<BookVM>());
            return RedirectToAction("Index", "Home", listToSend);
         
        }


        [HttpPost]
        [Route("Remove/{id}")]
        public IActionResult Remove(int  id) {
            var item = orderDetailsService.GetBookFromOrder(id);
            var shopList = HttpContext.Session.Get<List<BookVM>>(SessionHelper.ShoppingCart);

            if (shopList == null)
                return View();

            if (shopList.Contains(item))
                shopList.Remove(item);

            HttpContext.Session.Set(SessionHelper.ShoppingCart, shopList);

            return View();
        }
    }
}
