//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KrompirApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class SIFRA_SORTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SIFRA_SORTE()
        {
            this.ETIKETA = new HashSet<ETIKETA>();
            this.KOLICINA_PROIZVEDENOG_KROMPIRA = new HashSet<KOLICINA_PROIZVEDENOG_KROMPIRA>();
            this.PARCELA = new HashSet<PARCELA>();
        }
    
        public string SORTAID { get; set; }
        public string NAZIV { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ETIKETA> ETIKETA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KOLICINA_PROIZVEDENOG_KROMPIRA> KOLICINA_PROIZVEDENOG_KROMPIRA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PARCELA> PARCELA { get; set; }
    }
}
