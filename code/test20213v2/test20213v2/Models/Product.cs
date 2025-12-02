using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test20213v2.Models;

public partial class Product
{
    [RegularExpression(@"^[A-Z]{2}\d{4}$", ErrorMessage = "ID phải có định dạng XX0000 (Ví dụ: AB1234)")]
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    [Range(101, double.MaxValue, ErrorMessage = "UnitPrice phải là số và lớn hơn 100")]
    public double UnitPrice { get; set; }

    public string? Image { get; set; }

    public bool Available { get; set; }

    public int CategoryId { get; set; }

    public string? Description { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
