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
    
    public partial class ObiektSportowy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ObiektSportowy()
        {
            this.Szafka = new HashSet<Szafka>();
            this.Karnet = new HashSet<Karnet>();
            this.Wizyta = new HashSet<Wizyta>();
        }
    
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public bool CzyAktywny { get; set; }
        public string Uwagi { get; set; }
        public Nullable<int> IdPracownikaDodajacego { get; set; }
        public Nullable<System.DateTime> DataCzasDodania { get; set; }
        public Nullable<int> IdPracownikaModyfikujacego { get; set; }
        public Nullable<System.DateTime> DataCzasModyfikacji { get; set; }
        public Nullable<int> IdPracownikaKasujacego { get; set; }
        public Nullable<System.DateTime> DataCzasSkasowania { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Szafka> Szafka { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Karnet> Karnet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wizyta> Wizyta { get; set; }
    }
}
