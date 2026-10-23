using Microsoft.AspNetCore.Mvc;
using QuanLyThuVien.Models; // Khai báo để dùng model
using System.Linq;

namespace QuanLyThuVien.Controllers
{
    public class MuonTraController : Controller
    {
        private readonly LibraryDbContext _context;

        // Tiêm Database Context vào Controller
        public MuonTraController(LibraryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Lấy toàn bộ danh sách từ bảng BorrowRecords
            var records = _context.BorrowRecords.ToList();
            return View(records); // Gửi dữ liệu sang giao diện
        }
        // GET: MuonTra/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: MuonTra/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BorrowRecord borrowRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(borrowRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(borrowRecord);
        }
        public IActionResult Delete(int id)
        {
            var record = _context.BorrowRecords.Find(id);
            if (record != null)
            {
                _context.BorrowRecords.Remove(record);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}