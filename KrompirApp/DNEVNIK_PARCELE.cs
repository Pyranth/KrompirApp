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
    
    public partial class DNEVNIK_PARCELE
    {
        public int DNEVNIKID { get; set; }
        public string NAZIVRADNEOPERACIJE { get; set; }
        public Nullable<System.DateTime> DATUM { get; set; }
        public string KORISCENOPOGONSKOSREDSTVOMEHANIZACIJE { get; set; }
        public string KORISCENIPRIKLJUCAK { get; set; }
        public string NAZIVKORISCENOGPOTROSNOGMATERIJALA { get; set; }
        public string JEDINICAMJERE { get; set; }
        public Nullable<int> KOLICINAUTROSENOGPOTROSNOGMATERIJALA { get; set; }
        public Nullable<int> UTROSENOVRIJEMERADAMEHANIZACIJE { get; set; }
        public Nullable<int> UTROSENOVRIJEMERADARADNIKA { get; set; }
        public Nullable<int> PARCELAID { get; set; }
        public bool DELTED { get; set; }
    
        public virtual PARCELA PARCELA { get; set; }
    }
}
