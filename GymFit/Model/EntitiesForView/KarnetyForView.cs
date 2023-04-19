using GymFit.Model.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymFit.Model.EntitiesForView
{
    public class KarnetyForView
    {
        public int IdKarnetu { get; set; }
        public string NrKarty { get; set; }
        public DateTime? WaznyOd { get; set; }
        public DateTime? WaznyDo { get; set; }
        public string KlientImie { get; set; }
        public string KlientNazwisko { get; set; }
        public bool CzyAktywny { get; set; }
    }
}
