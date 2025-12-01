using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace day09LabCodeFirst.Models
{
    [Table("LttLoaiSanPham")]
    //[Index (nameof(lttMaLoai), IsUnique = true)]
    public class LttLoaiSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int lttId { get; set; }

        [Display(Name = "Mã Loại")]
        [StringLength(10)]
        public string lttMaLoai { get; set; }

        [Display(Name = "Tên Loại")]
        [StringLength(50)]
        public string lttTenLoai { get; set; }

        [Display(Name = "Trạng Thái")]
        public bool lttTrangThai { get; set; }

        public virtual ICollection<LttSanPham> LttSanPhams { get; set; }
    }
}
