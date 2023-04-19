using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymFit.Model.EntitiesForView
{
    public class KlienciForView
    {
        public int Id { get; set; }
        public string OsobaImie { get; set; }
        public string OsobaNazwisko { get; set; }
        public string OsobaPlec { get; set; }
        public DateTime? OsobaDataUrodzenia { get; set; }
        public string OsobaNumerTelefonu { get; set; }
        public string OsobaEmail { get; set; }
        
    }
}
