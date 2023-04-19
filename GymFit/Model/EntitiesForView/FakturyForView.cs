using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymFit.Model.EntitiesForView
{
    public class FakturyForView
    {
        public int Id { get; set; }
        public string Numer { get; set; }
        public string NazwaDostawcy { get; set; }
        public string SposobPlatnosci { get; set; }
        public DateTime? DataWystawienia { get; set; }
        public string TerminPlatnosci { get; set; }
        public bool CzyAktywny { get; set; }
    }
}
