using GymFit.Helpers;
using GymFit.Model.Entities;
using GymFit.Model.EntitiesForView;
using GymFit.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GymFit.ViewModel
{
    public class WejscieWyjscieViewModel : WorkspaceViewModel
    {
        #region Constructor
        public WejscieWyjscieViewModel()
            //:base("Wejście/Wyjście")
        {
            this.DisplayName = "Wejście/Wyjście";
        }
        #endregion
    }
}
