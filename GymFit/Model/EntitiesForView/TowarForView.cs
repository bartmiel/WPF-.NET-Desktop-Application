using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymFit.Model.EntitiesForView
{
    public class TowarForView
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string Nazwa { get; set; }
        public decimal? StawkaVatZakupu { get; set; }
        public decimal? StawkaVatSprzedazy { get; set; }
        public decimal? Marza { get; set; }
        public decimal? Cena { get; set; }
        public bool CzyAktywny { get; set; }
    }
}
