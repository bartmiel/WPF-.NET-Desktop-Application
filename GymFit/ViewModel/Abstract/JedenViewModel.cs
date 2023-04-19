using GymFit.Helpers;
using GymFit.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GymFit.ViewModel.Abstract
{
    public abstract class JedenViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        public GymFitEntities GymFitEntities { get; }
        public T Item { get; set; }
        #endregion
        #region Constructor
        public JedenViewModel(string displayName)
        {
            base.DisplayName = displayName;
            GymFitEntities = new GymFitEntities();
        }
        #endregion
        #region Command
        private BaseCommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new BaseCommand(() => saveAndClose());
                return _SaveCommand;
            }
        }
        #endregion
        #region Validators
        public virtual bool IsValid()
        {
            return true;
        }
        #endregion
        #region Helpers
        public abstract void Save();
        private void saveAndClose()
        {
            if (IsValid())
            {
                Save();
                base.OnRequestClose();
            }
            else
                ShowMessageBox("Popraw błędy");
        }
        #endregion
    }
}
