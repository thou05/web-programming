using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test20215v1.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Fullname { get; set; } = null!;

    [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string RePassword { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
