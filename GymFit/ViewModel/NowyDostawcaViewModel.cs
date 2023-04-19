using GymFit.Model.Entities;
using GymFit.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymFit.ViewModel
{
    public class NowyDostawcaViewModel : JedenViewModel<Dostawca>
    {
        public NowyDostawcaViewModel()
            :base("Nowa faktura")
        {
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
