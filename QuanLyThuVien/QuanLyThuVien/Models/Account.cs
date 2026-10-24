using System.ComponentModel.DataAnnotations;

namespace QuanLyThuVien.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn phân quyền")]
        public string Role { get; set; } // Ví dụ: Admin, Thủ thư

        public bool IsActive { get; set; } = true;
    }
}