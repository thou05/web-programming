using System.ComponentModel.DataAnnotations;

namespace day06_annotation.Models
{
    public class User
    {

        public int Id { get; set; }
        [Required]
        [StringLength(10, MinimumLength=5, ErrorMessage ="toi thieu 5 ki tu, toi da 10 ki tu")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Nhap mat kau")]
        [StringLength(100, MinimumLength=6, ErrorMessage ="toi thieu 6 ki tu")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage ="Mat khau khong giong nhau")]
        public string ReenterPassword { get; set; }
        [Range(18, 60, ErrorMessage ="tuoi phai tu 18 den 60")]
        public int Age { get; set; }
        [EmailAddress(ErrorMessage ="khong dung dinh dang email")]
        public string Email { get; set; }
    }
}
