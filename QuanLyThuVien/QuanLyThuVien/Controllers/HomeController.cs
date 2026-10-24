using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Controllers
{
   
        public class HomeController : Controller
        {
        private readonly LibraryDbContext _context;

        public HomeController(LibraryDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.TotalBooks = _context.Books.Count();
            ViewBag.TotalReaders = _context.Readers.Count();
            ViewBag.ActiveBorrows = _context.BorrowRecords.Count(b => b.Status == "Đang mượn");

         
            ViewBag.OverdueBorrows = _context.BorrowRecords.Count(b =>
                b.Status == "Đang mượn" && b.ReturnDate.HasValue && b.ReturnDate.Value < DateTime.Now);

            return View();
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
