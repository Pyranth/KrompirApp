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
    
    public partial class KOLICINA_PROIZVEDENOG_KROMPIRA
    {
        public int KOLICINAPROIZVEDENOGKROMPIRAID { get; set; }
        public Nullable<int> PROIZVODJACID { get; set; }
        public Nullable<int> UKUPNAPROIZVEDENAKOLICINA { get; set; }
        public string SORTAID { get; set; }
        public bool DELETED { get; set; }
    
        public virtual PROIZVODJAC PROIZVODJAC { get; set; }
        public virtual SIFRA_SORTE SIFRA_SORTE { get; set; }
    }
}
