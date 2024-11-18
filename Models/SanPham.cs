using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{

    public partial class SanPham
    {
        public int MaSp { get; set; }
        public string? TenSanPham { get; set; }
        public double? DonGia { get; set; }
        public double? SoLuongBan { get; set; }
        public double? TienBan { get; set; }
        public int? MaNhomHang { get; set; }
        [JsonIgnore]

        public virtual NhomHang? MaNhomHangNavigation { get; set; }
    }
}
