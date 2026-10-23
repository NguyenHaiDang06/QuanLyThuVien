using System.ComponentModel.DataAnnotations;

namespace QuanLyThuVien.Models
{
    public class Reader
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên độc giả không được để trống")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}