using System;
using System.Collections.Generic;

namespace lesson041_scaffold.Models;

public partial class Danhmuc
{
    public int DanhmucId { get; set; }

    public string? TenDanhMuc { get; set; }

    public string? MoTa { get; set; }
}
