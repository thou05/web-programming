using System;
using System.Collections.Generic;

namespace LeThiThao_231230910.Models;

public partial class LoaiKhach
{
    public int MaLoai { get; set; }

    public string? TenLoai { get; set; }

    public virtual ICollection<HanhKhach> HanhKhaches { get; set; } = new List<HanhKhach>();
}
