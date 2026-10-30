using System.ComponentModel.DataAnnotations;

namespace Day_3_NguyenBaQuoc.Models
{
    public class Category
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Tên danh sách phải từ 2 đến 100 ký tự")]
        public String? Name { get; set; } 
        public List<Product>? Products { get; set; }
    }
}
