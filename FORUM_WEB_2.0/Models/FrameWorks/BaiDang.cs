//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FORUM_WEB_2._0.Models.FrameWorks
{
    using System;
    using System.Collections.Generic;
    
    public partial class BaiDang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaiDang()
        {
            this.Img_BaiDang = new HashSet<Img_BaiDang>();
            this.BinhLuan = new HashSet<BinhLuan>();
        }
    
        public int ID_BaiDang { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public Nullable<System.DateTime> NgayDangBai { get; set; }
        public Nullable<int> ID_ChuDe { get; set; }
        public string TenDangNhap { get; set; }
    
        public virtual ChuDe ChuDe { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Img_BaiDang> Img_BaiDang { get; set; }
        public virtual Top_BinhLuan Top_BinhLuan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuan { get; set; }
    }
}