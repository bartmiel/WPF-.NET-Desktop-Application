﻿using GymFit.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GymFit.ViewModel
{
    public abstract class WorkspaceViewModel : BaseViewModel
    {
        #region Constructor
        public WorkspaceViewModel()
        {

        }
        #endregion
        #region CloseCommand
        //tu będzie komenda do zamykania zakładki
        private BaseCommand _CloseCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                    _CloseCommand = new BaseCommand(()=>this.OnRequestClose()); // ta komenda wywoła metodę OnRequestClose
                return _CloseCommand;
            }
        }
        #endregion
        #region Helpers
        public event EventHandler RequestClose;
        protected void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion
    }
}
