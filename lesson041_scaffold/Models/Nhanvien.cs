using System;
using System.Collections.Generic;

namespace lesson041_scaffold.Models;

public partial class Nhanvien
{
    public int NhanviennId { get; set; }

    public string? Ten { get; set; }

    public string? Ho { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? Anh { get; set; }

    public string? Ghichu { get; set; }
}
