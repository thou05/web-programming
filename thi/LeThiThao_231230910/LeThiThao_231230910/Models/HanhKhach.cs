using System;
using System.Collections.Generic;

namespace LeThiThao_231230910.Models;

public partial class HanhKhach
{
    public string MaKhach { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public string? Cccd { get; set; }

    public string? DienThoai { get; set; }

    public string? Email { get; set; }

    public string? Anh { get; set; }

    public double? DiemTichLuy { get; set; }

    public int? MaLoai { get; set; }

    public virtual LoaiKhach? MaLoaiNavigation { get; set; }
}
