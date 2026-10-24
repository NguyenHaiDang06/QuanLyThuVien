using Microsoft.AspNetCore.Mvc;
using QuanLyThuVien.Models;
using System.Linq;

namespace QuanLyThuVien.Controllers
{
    public class TaiKhoanController : Controller
    {
        private readonly LibraryDbContext _context;
        public TaiKhoanController(LibraryDbContext context) { _context = context; }

        public IActionResult Index() => View(_context.Accounts.ToList());

        [HttpGet] public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Account model)
        {
            if (ModelState.IsValid)
            {
                _context.Accounts.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var account = _context.Accounts.Find(id);
            return account == null ? NotFound() : View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Account model)
        {
            if (ModelState.IsValid)
            {
                _context.Accounts.Update(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var account = _context.Accounts.Find(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}