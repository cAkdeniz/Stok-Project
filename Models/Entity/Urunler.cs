//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StokProject.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urunler()
        {
            this.Satislar = new HashSet<Satislar>();
        }
    
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad alan? bo? ge?ilemez.")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Marka alan? bo? ge?ilemez.")]
        public string Marka { get; set; }
        public Nullable<int> KategoriId { get; set; }
        [Required(ErrorMessage = "Fiyat alan? bo? ge?ilemez.")]
        public Nullable<decimal> Fiyat { get; set; }
        [Required(ErrorMessage = "Stok alan? bo? ge?ilemez.")]
        public Nullable<int> Stok { get; set; }
    
        public virtual Kategoriler Kategoriler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Satislar> Satislar { get; set; }
    }
}
