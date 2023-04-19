using GymFit.Model.Entities;
using GymFit.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymFit.ViewModel
{
    public class NowyKlientViewModel : JedenViewModel<Osoba>
    {
        #region Constructor
        public NowyKlientViewModel()
            : base("Nowy klient")
        {
            Item = new Osoba();
        }
        #endregion
        #region Properties
        #endregion
        #region Helpers
        public override void Save()
        {
            //Item.CzyAktywny = true;
            //GymFitEntities.Karnet.Add(Item);
            //GymFitEntities.SaveChanges();
        }
        #endregion
    }
}
