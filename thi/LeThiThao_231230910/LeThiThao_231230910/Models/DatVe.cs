using System;
using System.Collections.Generic;

namespace LeThiThao_231230910.Models;

public partial class DatVe
{
    public string? MaKhach { get; set; }

    public int? MaChuyen { get; set; }

    public int? SoVe { get; set; }

    public virtual Chuyen? MaChuyenNavigation { get; set; }

    public virtual HanhKhach? MaKhachNavigation { get; set; }
}
