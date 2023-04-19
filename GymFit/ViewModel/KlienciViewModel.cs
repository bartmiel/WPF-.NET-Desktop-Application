using GalaSoft.MvvmLight.Messaging;
using GymFit.Model.Entities;
using GymFit.Model.EntitiesForView;
using GymFit.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymFit.ViewModel
{
    public class KlienciViewModel : WszystkieViewModel<KlienciForView>
    {
        #region Constructor
        public KlienciViewModel()
            :base("Klienci")
        {
        }
        #endregion
        #region Properties
        public KlienciForView SelectedItemToDelete { get; set; }
        private KlienciForView _WybranyKlient;
        public KlienciForView WybranyKlient
        {
            get
            {
                return _WybranyKlient;
            }
            set
            {
                _WybranyKlient = value;
                Messenger.Default.Send(_WybranyKlient);
                base.OnRequestClose();
            }
        }
        #endregion
        #region Sort/Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Imię", "Nazwisko", "Płeć", "Data ur." };
        }
        public override void Sort()
        {
            switch (SortField)
            {
                case "Data ur.":
                    List = new ObservableCollection<KlienciForView>(List.OrderBy(Item => Item.OsobaDataUrodzenia));
                    break;
                case "Płeć":
                    List = new ObservableCollection<KlienciForView>(List.OrderBy(Item => Item.OsobaPlec));
                    break;
                case "Imię":
                    List = new ObservableCollection<KlienciForView>(List.OrderBy(Item => Item.OsobaImie));
                    break;
                case "Nazwisko":
                    List = new ObservableCollection<KlienciForView>(List.OrderBy(Item => Item.OsobaNazwisko));
                    break;
            }
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Imię", "Nazwisko", "E-mail", "Nr telefonu" };
        }
        public override void Find()
        {
            switch (FindField)
            {
                case "E-mail":
                    List = new ObservableCollection<KlienciForView>(List.Where(item => item.OsobaEmail != null && item.OsobaEmail.StartsWith(FindTextBox)));
                    break;
                case "Nr telefonu":
                    List = new ObservableCollection<KlienciForView>(List.Where(item => item.OsobaNumerTelefonu != null && item.OsobaNumerTelefonu.StartsWith(FindTextBox)));
                    break;
                case "Imię":
                    List = new ObservableCollection<KlienciForView>(List.Where(item => item.OsobaImie != null && item.OsobaImie.StartsWith(FindTextBox)));
                    break;
                case "Nazwisko":
                    List = new ObservableCollection<KlienciForView>(List.Where(item => item.OsobaNazwisko != null && item.OsobaNazwisko.StartsWith(FindTextBox)));
                    break;
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KlienciForView>
                (
                     from klient in GymFitEntities.Klient
                     where klient.CzyAktywny == true
                     select new KlienciForView
                     {
                         Id = klient.Id,
                         OsobaImie = klient.Osoba.Imie,
                         OsobaNazwisko = klient.Osoba.Nazwisko,
                         OsobaPlec = klient.Osoba.Plec,
                         OsobaDataUrodzenia = klient.Osoba.DataUrodzenia,
                         OsobaNumerTelefonu = klient.Osoba.NrTelefonu,
                         OsobaEmail = klient.Osoba.Email
                     }
                );
        }
        public override void DeleteRecord()
        {
            var modified = GymFitEntities.Karnet.Find(SelectedItemToDelete.Id);
            modified.CzyAktywny = false;
            GymFitEntities.SaveChanges();
        }
        #endregion
    }
}
