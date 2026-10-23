using Microsoft.AspNetCore.Mvc;
using QuanLyThuVien.Models;
using System.Linq;

namespace QuanLyThuVien.Controllers
{
    public class DocGiaController : Controller
    {
        private readonly LibraryDbContext _context;

        public DocGiaController(LibraryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Readers.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reader model)
        {
            if (ModelState.IsValid)
            {
                _context.Readers.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var reader = _context.Readers.Find(id);
            if (reader == null) return NotFound();
            return View(reader);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Reader model)
        {
            if (ModelState.IsValid)
            {
                _context.Readers.Update(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var reader = _context.Readers.Find(id);
            if (reader != null)
            {
                _context.Readers.Remove(reader);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}