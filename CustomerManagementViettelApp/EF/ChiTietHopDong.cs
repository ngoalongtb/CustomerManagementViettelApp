//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CustomerManagementViettelApp.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietHopDong
    {
        public int MaChiTietHopDong { get; set; }
        public Nullable<int> MaDichVu { get; set; }
        public string GhiChu { get; set; }
        public string DiaChiLapDat { get; set; }
        public Nullable<int> MaHopDong { get; set; }
    
        public virtual DichVu DichVu { get; set; }
        public virtual HopDong HopDong { get; set; }
    }
}