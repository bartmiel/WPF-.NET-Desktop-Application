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
    
    public partial class Szafka
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Szafka()
        {
            this.Wizyta = new HashSet<Wizyta>();
        }
    
        public int Id { get; set; }
        public Nullable<int> IdObiektu { get; set; }
        public string Numer { get; set; }
        public bool CzyAktywna { get; set; }
        public string Uwagi { get; set; }
    
        public virtual ObiektSportowy ObiektSportowy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wizyta> Wizyta { get; set; }
    }
}