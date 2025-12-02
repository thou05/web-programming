using System;
using System.Collections.Generic;

namespace LeThiThao_231230910.Models;

public partial class Xe
{
    public string SoXe { get; set; } = null!;

    public string? MauXe { get; set; }

    public int? SoChoNgoi { get; set; }

    public int? MaLoaiXe { get; set; }

    public string? MaCongTy { get; set; }

    public string? Anh { get; set; }

    public virtual ICollection<Chuyen> Chuyens { get; set; } = new List<Chuyen>();

    public virtual CongTy? MaCongTyNavigation { get; set; }

    public virtual LoaiXe? MaLoaiXeNavigation { get; set; }
}
