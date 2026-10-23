using System.ComponentModel.DataAnnotations;

namespace QuanLyThuVien.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sách không được để trống")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Tác giả không được để trống")]
        public string Author { get; set; }

        public string Category { get; set; }

        public int Quantity { get; set; }
    }
}