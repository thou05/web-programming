using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace day09LabCodeFirst.Models
{
    [Table("LttSanPham")]
    public class LttSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long lttId { get; set; }

        public string lttMaSP { get; set; }
        public string lttTenSP { get; set; }
        public string lttHinhAnh { get; set; }
        public int lttSoLuong { get; set; }
        public decimal lttGiaBan { get; set; }
        public long lttMaLoai { get; set; }
        public bool lttTrangThai { get; set; }

        public virtual LttLoaiSanPham LttLoaiSanPham { get; set; }
    }
}
