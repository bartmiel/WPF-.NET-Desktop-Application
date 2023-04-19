using GymFit.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymFit.Model.EntitiesForView
{
    public class WizytyForView
    {
        public int Id { get; set; }
        public string OsobaImie { get; set; }
        public string OsobaNazwisko { get; set; }
        public DateTime? CzasRozpoczecia { get; set; }
        public DateTime? CzasZakonczenia { get; set; }
        public string NrSzafki { get; set; }
        public string ObiektSportowyNazwa { get; set; }
        public bool CzyAktywny { get; set; }
    }
}
