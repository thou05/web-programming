using System;
using System.Collections.Generic;

namespace LeThiThao_231230910.Models;

public partial class Chuyen
{
    public int MaChuyen { get; set; }

    public string? MaTuyen { get; set; }

    public string? SoXe { get; set; }

    public int? MaLaiXe { get; set; }

    public DateTime? NgayGio { get; set; }

    public virtual LaiXe? MaLaiXeNavigation { get; set; }

    public virtual Tuyen? MaTuyenNavigation { get; set; }

    public virtual Xe? SoXeNavigation { get; set; }
}
