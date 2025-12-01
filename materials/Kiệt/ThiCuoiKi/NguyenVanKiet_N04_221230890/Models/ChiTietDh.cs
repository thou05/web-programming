using System;
using System.Collections.Generic;

namespace NguyenVanKiet_N04_221230890.Models;

public partial class ChiTietDh
{
    public string MaDonHang { get; set; } = null!;

    public string MaChiTietSp { get; set; } = null!;

    public int? SoLuongMua { get; set; }

    public long? DonGiaBan { get; set; }

    public virtual ChiTietSpban MaChiTietSpNavigation { get; set; } = null!;

    public virtual DonHang MaDonHangNavigation { get; set; } = null!;
}
