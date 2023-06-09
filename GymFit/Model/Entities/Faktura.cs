//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GymFit.Model.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Faktura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Faktura()
        {
            this.PozycjaFaktury = new HashSet<PozycjaFaktury>();
        }
    
        public int Id { get; set; }
        public string Numer { get; set; }
        public Nullable<int> IdDostawcy { get; set; }
        public Nullable<int> IdKlienta { get; set; }
        public Nullable<int> IdSposobuPlatnosci { get; set; }
        public Nullable<System.DateTime> DataWystawienia { get; set; }
        public string TerminPlatnosci { get; set; }
        public bool CzyAktywny { get; set; }
        public string Uwagi { get; set; }
        public Nullable<int> IdPracownikaDodajacego { get; set; }
        public Nullable<System.DateTime> DataCzasDodania { get; set; }
        public Nullable<int> IdPracownikaModyfikujacego { get; set; }
        public Nullable<System.DateTime> DataCzasModyfikacji { get; set; }
        public Nullable<int> IdPracownikaKasujacego { get; set; }
        public Nullable<System.DateTime> DataCzasSkasowania { get; set; }
    
        public virtual Dostawca Dostawca { get; set; }
        public virtual SposobPlatnosci SposobPlatnosci { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PozycjaFaktury> PozycjaFaktury { get; set; }
    }
}
