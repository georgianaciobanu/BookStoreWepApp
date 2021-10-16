using BookStoreApp.Models.DTOs.VM;
using BookStoreApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace BookStoreApp.Web.Controllers {

    [Route("[Controller]")]
    public class BookTypeController : Controller {

        private readonly IBookTypeService service;

        public BookTypeController(IBookTypeService service) {
            this.service = service;
        }
        [HttpGet]
        public IActionResult Index() {
            var list = service.GetAllBookType();
            return View(list);
        }

        [HttpGet]
        [Route("New")]
        public IActionResult New() {
            var dto = new BookTypeVM();
            return View(dto);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id) {
            var dto = service.GetBookType(id);
            return View(dto);
        }

        [HttpPost]
        [Route("New")]
        public IActionResult New(BookTypeVM dto) {
            if (!ModelState.IsValid) {
                ModelState.AddModelError(string.Empty, "There were some errors in your form!");
                return View(dto);
            }

            service.AddBookType(dto);
            return View("Index",service.GetAllBookType());
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id, BookTypeVM dto) {
            if (!ModelState.IsValid) {
                ModelState.AddModelError(string.Empty, "There were some errors in your form");
                return View(dto);
            }

            service.UpateBookType( id, dto);

            return View("Index", service.GetAllBookType());
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public JsonResult Delete(int id) {
            service.DeleteBookType(id);
            return Json(new { success = true, message = "Delete success" });
        }

    }
}
