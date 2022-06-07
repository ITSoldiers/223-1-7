using BLL;
using BLL.DTOs;
using Microsoft.AspNetCore.Mvc;
using PLVar7.Models;
using System.Diagnostics;

namespace PLVar7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Service service;

        public HomeController(ILogger<HomeController> logger)
        {
            service = new Service();
            _logger = logger;
        }

        public IActionResult Index(UserDTO? user)
        {
            int[] starsArray = { 1, 2, 3, 4, 5 };
            List<int> Stars = starsArray.ToList<int>();

            ViewBag.Books = service.GetAll();
            ViewBag.Genres = service.GetGenres();
            ViewBag.Types = service.GetTypes();
            ViewBag.User = user;

            return View();
        }

        [HttpGet]
        [ActionName("Find")]
        public IActionResult Find(string genre, string bookType)
        {
            int[] starsArray = { 1, 2, 3, 4, 5 };
            List<int> Stars = starsArray.ToList<int>();

            ViewBag.Genres = service.GetGenres();
            ViewBag.Types = service.GetTypes();
            ViewBag.User = new UserDTO();
            ViewBag.Books = service.GetBooks(genre, bookType);

            return View("~/Views/Home/Index.cshtml");
        }

        [HttpGet]
        [ActionName("Book")]
        public IActionResult GetBook(int id)
        {
            BookDTO book = service.GetBookById(id);

            ViewBag.Book = book;

            return View("~/Views/Home/BookPage.cshtml");
        }

        [HttpGet]
        [ActionName("ReserveBook")]
        public IActionResult GetReserveBook(int bookID)
        {
            ViewBag.Price = service.GetBookById(bookID);
            return View("~/Views/Home/ReserveBook.cshtml");
        }

        [HttpPost]
        [ActionName("ReserveBook")]
        public IActionResult ReserveBook(string firstName, string lastName, string phone, string email)
        {
            ViewBag.Message = "Your order has been accepted, please wait for a call from our administrator to confirm";
            return View("~/Views/Home/Message.cshtml");
        }

        [HttpGet]
        [ActionName("Registration")]
        public IActionResult GetRegistry()
        {
            return View("~/Views/Home/Registry.cshtml");
        }

        [HttpPost]
        [ActionName("Registration")]
        public IActionResult Registry(UserDTO user)
        {
            service.AddUser(user);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("LogIn")]
        public IActionResult GetLogIn()
        {
            return View("~/Views/Home/LogIn.cshtml");
        }

        [HttpPost]
        [ActionName("LogIn")]
        public IActionResult LogIn(string Login, string Password)
        {
            UserDTO user = service.GetUser(Login, Password);

            return RedirectToAction("Index", user);
        }

        [HttpGet]
        [ActionName("LogOut")]
        public IActionResult LogOut()
        {
            return RedirectToAction("Index", new UserDTO());
        }

        [HttpGet]
        [ActionName("Add")]
        public IActionResult GetAddBook()
        {
            ViewBag.Genres = service.GetGenres();
            ViewBag.Types = service.GetTypes();

            return View("~/Views/Home/AddBook.cshtml");
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult AddBook(string genre, string bookType, string bookTitle, string author)
        {
            BookDTO book = new BookDTO(service.GetAll().Count - 1, bookTitle, author, genre, bookType);
            service.AddBook(book);
            ViewBag.Message = "Book successfully added";
            return View("~/Views/Home/Message.cshtml");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult GetDeleteTour()
        {
            ViewBag.Books = service.GetAll();
            ViewBag.Genres = service.GetGenres();
            ViewBag.Types = service.GetTypes();

            return View("~/Views/Home/DeleteBook.cshtml");
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            service.DeleteBookById(id);
            ViewBag.Message = "Book successfully deleted";
            return View("~/Views/Home/Message.cshtml");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}