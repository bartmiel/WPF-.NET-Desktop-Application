using GalaSoft.MvvmLight.Messaging;
using GymFit.Helpers;
using GymFit.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GymFit.ViewModel.Abstract
{
    //Klasa działa na typie genertycznym <T> pod który podstawiamy to co chcemy wyświetlać
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        //To jest dostęp do bazy danych
        public GymFitEntities GymFitEntities { get; }
        //To jest komenda którą podepniemy pod przycisk i ta komenda wywoła funkcję
        private BaseCommand _LoadCommand;
        //To jest komenda która zostanie podpięta pod przycisk plus, który wywoła okno do dodawania rekordu
        private BaseCommand _AddCommand;
        private BaseCommand _SortCommand;
        private BaseCommand _FindCommand;
        private BaseCommand _DeleteSelected;
        //Tu będą przechowywane wszystkie karnety itd
        private ObservableCollection<T> _List;
        #endregion
        #region Properties
        //Podpinamy pod LoadCommand funkcję Load
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                    _LoadCommand = new BaseCommand(() => Load());
                return _LoadCommand;
            }
        }
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                    _AddCommand = new BaseCommand(() => add());
                return _AddCommand;
            }
        }
        public string SortField { get; set; }
        public List<string> SortComboboxItems
        {
            get
            {
                return GetComboboxSortList();
            }
        }
        public ICommand SortCommand
        {
            get
            {
                if(_SortCommand == null)
                {
                    _SortCommand = new BaseCommand(() => Sort());
                }
                return _SortCommand;
            }
        }
        public string FindField { get; set; }
        public List<string> FindComboboxItems
        {
            get
            {
                return GetComboboxFindList();
            }
        }
        public ICommand FindCommand
        {
            get
            {
                if(_FindCommand == null)
                {
                    _FindCommand = new BaseCommand(() => Find());
                }
                return _FindCommand;
            }
        }
        public string FindTextBox { get; set; }

        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                    Load();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        public ICommand DeleteSelected
        {
            get
            {
                if (_DeleteSelected == null)
                    _DeleteSelected = new BaseCommand(() => DeleteRecord());
                return _DeleteSelected;
            }
        }
        #endregion
        #region Constructor
        public WszystkieViewModel(String displayName)
        {
            base.DisplayName = displayName;
            GymFitEntities = new GymFitEntities();
        }
        #endregion
        #region Helpers
        public abstract void Load();
        
        private void add()
        {
            //To jest messanger z biblioteki MVVM Light
            //Wysyła komunikat displayName+"Add", który zostaje przejęcty przez klasę MainWindowViewModel
            Messenger.Default.Send(DisplayName + "Add");
        }
        public abstract void Sort();
        public abstract List<string> GetComboboxSortList();
        public abstract void Find();
        public abstract void DeleteRecord();
        public abstract List<string> GetComboboxFindList();
        #endregion
    }
}