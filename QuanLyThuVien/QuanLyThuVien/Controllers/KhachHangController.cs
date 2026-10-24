using Microsoft.AspNetCore.Mvc;
using QuanLyThuVien.Models;
using System.Linq;

namespace QuanLyThuVien.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly LibraryDbContext _context;

        public KhachHangController(LibraryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString)
        {
            var books = from b in _context.Books select b;

            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title.Contains(searchString) || s.Author.Contains(searchString));
            }

            return View(books.ToList());
        }
    }
}