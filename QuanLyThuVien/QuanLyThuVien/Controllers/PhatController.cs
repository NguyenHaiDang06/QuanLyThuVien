using Microsoft.AspNetCore.Mvc;
using QuanLyThuVien.Models;
using System.Linq;

namespace QuanLyThuVien.Controllers
{
    public class PhatController : Controller
    {
        private readonly LibraryDbContext _context;
        public PhatController(LibraryDbContext context) { _context = context; }

        public IActionResult Index() => View(_context.Penalties.ToList());

        [HttpGet] public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Penalty model)
        {
            if (ModelState.IsValid)
            {
                _context.Penalties.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var penalty = _context.Penalties.Find(id);
            return penalty == null ? NotFound() : View(penalty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Penalty model)
        {
            if (ModelState.IsValid)
            {
                _context.Penalties.Update(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var penalty = _context.Penalties.Find(id);
            if (penalty != null)
            {
                _context.Penalties.Remove(penalty);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}