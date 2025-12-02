using System;
using System.Collections.Generic;

namespace LeThiThao_231230910.Models;

public partial class LaiXe
{
    public int MaLaiXe { get; set; }

    public string HoTen { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    public string? Anh { get; set; }

    public virtual ICollection<Chuyen> Chuyens { get; set; } = new List<Chuyen>();
}
