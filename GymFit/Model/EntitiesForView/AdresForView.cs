using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymFit.Model.EntitiesForView
{
    public class AdresForView
    {
        public int Id { get; set; }
        public string Kraj { get; set; }
        public string IdWojewodztwa { get; set; }
        public string Miejscowosc { get; set; }
        public string Ulica { get; set; }
        public string NrDomu { get; set; }
        public string NrLokalu { get; set; }
        public string KodPocztowy { get; set; }
        public string Poczta { get; set; }
        public bool CzyAktywny { get; set; }
    }
}
