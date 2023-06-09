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
    
    public partial class Wizyta
    {
        public int Id { get; set; }
        public Nullable<int> IdPracownika { get; set; }
        public Nullable<int> IdKlienta { get; set; }
        public Nullable<int> IdKarnetu { get; set; }
        public Nullable<int> IdSzafki { get; set; }
        public Nullable<System.DateTime> DataCzasRozpoczecia { get; set; }
        public Nullable<System.DateTime> DataCzasZakonczenia { get; set; }
        public bool CzyAktywny { get; set; }
        public string Uwagi { get; set; }
        public Nullable<int> IdPracownikaDodajacego { get; set; }
        public Nullable<System.DateTime> DataCzasDodania { get; set; }
        public Nullable<int> IdPracownikaModyfikujacego { get; set; }
        public Nullable<System.DateTime> DataCzasModyfikacji { get; set; }
        public Nullable<int> IdPracownikaKasujacego { get; set; }
        public Nullable<System.DateTime> DataCzasSkasowania { get; set; }
        public Nullable<int> IdObiektu { get; set; }
    
        public virtual Karnet Karnet { get; set; }
        public virtual Klient Klient { get; set; }
        public virtual Pracownik Pracownik { get; set; }
        public virtual ObiektSportowy ObiektSportowy { get; set; }
        public virtual Szafka Szafka { get; set; }
    }
}
