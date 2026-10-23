using System.ComponentModel.DataAnnotations;

namespace QuanLyThuVien.Models
{
    public class Penalty
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên độc giả không được để trống")]
        public string ReaderName { get; set; }

        [Required(ErrorMessage = "Lý do phạt không được để trống")]
        public string Reason { get; set; }

        public decimal Amount { get; set; }

        public bool IsPaid { get; set; } // Trạng thái: true (Đã nộp), false (Chưa nộp)
    }
}