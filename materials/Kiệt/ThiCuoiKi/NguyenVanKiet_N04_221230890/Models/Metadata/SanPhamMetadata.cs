using System.ComponentModel.DataAnnotations;

namespace NguyenVanKiet_N04_221230890.Models.Metadata
{
    public class SanPhamMetadata
    {
        [Display(Name = "Mã sản phẩm")]
        public string MaSanPham { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [RegularExpression(@"^[a-zA-ZÀ-ỹ][a-zA-Z0-9À-ỹ\s]*$", 
            ErrorMessage = "Tên sản phẩm phải bắt đầu bằng chữ cái")]
        public string TenSanPham { get; set; }

        [Display(Name = "Phân loại")]
        public string? MaPhanLoai { get; set; }

        [Display(Name = "Giá nhập")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [RegularExpression(@"^[0-9]+$", 
            ErrorMessage = "Giá nhập chỉ được nhập số")]
        [Range(0, long.MaxValue, ErrorMessage = "Giá nhập phải lớn hơn hoặc bằng 0")]
        public long? GiaNhap { get; set; }

        [Display(Name = "Giá bán thấp nhất")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [RegularExpression(@"^[0-9]+$", 
            ErrorMessage = "Giá bán chỉ được nhập số")]
        [Range(0, long.MaxValue, ErrorMessage = "Giá bán phải lớn hơn hoặc bằng 0")]
        public long? DonGiaBanNhoNhat { get; set; }

        [Display(Name = "Giá bán cao nhất")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [RegularExpression(@"^[0-9]+$", 
            ErrorMessage = "Giá bán chỉ được nhập số")]
        [Range(0, long.MaxValue, ErrorMessage = "Giá bán phải lớn hơn hoặc bằng 0")]
        public long? DonGiaBanLonNhat { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? TrangThai { get; set; }

        [Display(Name = "Mô tả ngắn")]
        [RegularExpression(@"^[a-zA-ZÀ-ỹ][a-zA-Z0-9À-ỹ\s]*$", 
            ErrorMessage = "Mô tả phải bắt đầu bằng chữ cái")]
        public string? MoTaNgan { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string? AnhDaiDien { get; set; }

        [Display(Name = "Nổi bật")]
        public bool? NoiBat { get; set; }

        [Display(Name = "Phân loại phụ")]
        public string? MaPhanLoaiPhu { get; set; }
    }
} 