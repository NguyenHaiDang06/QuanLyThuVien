using Microsoft.AspNetCore.Mvc;
using QuanLyThuVien.Models;
using System.Linq;

namespace QuanLyThuVien.Controllers
{
    public class SachController : Controller
    {
        private readonly LibraryDbContext _context;

        public SachController(LibraryDbContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách
        public IActionResult Index()
{

    return View();
}

        // Giao diện thêm mới
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý lưu sách
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book model)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book model)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}