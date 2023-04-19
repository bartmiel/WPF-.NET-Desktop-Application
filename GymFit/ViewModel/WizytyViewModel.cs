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
    public class WizytyViewModel : WszystkieViewModel<WizytyForView>
    {
        #region Constructor
        public WizytyViewModel()
            : base("Wizyty")
        {
        }
        #endregion
        #region Properties
        public WizytyForView SelectedItemToDelete { get; set; }
        private WizytyForView _WybranaWizyta;
        public WizytyForView WybranaWizyta
        {
            get
            {
                return _WybranaWizyta;
            }
            set
            {
                _WybranaWizyta = value;
            }
        }
        #endregion
        #region Sort/Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Imię", "Nazwisko", "Obiekt", "Wejście" };
        }
        public override void Sort()
        {
            switch (SortField)
            {
                case "Imię":
                    List = new ObservableCollection<WizytyForView>(List.OrderBy(Item => Item.OsobaImie));
                    break;
                case "Nazwisko":
                    List = new ObservableCollection<WizytyForView>(List.OrderBy(Item => Item.OsobaNazwisko));
                    break;
                case "Obiekt":
                    List = new ObservableCollection<WizytyForView>(List.OrderBy(Item => Item.ObiektSportowyNazwa));
                    break;
                case "Wejście":
                    List = new ObservableCollection<WizytyForView>(List.OrderBy(Item => Item.CzasRozpoczecia));
                    break;
            }
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Imię", "Nazwisko", "Obiekt", "Szafka" };
        }
        public override void Find()
        {
            switch (FindField)
            {
                case "Imię":
                    List = new ObservableCollection<WizytyForView>(List.Where(item => item.OsobaImie != null && item.OsobaImie.StartsWith(FindTextBox)));
                    break;
                case "Nazwisko":
                    List = new ObservableCollection<WizytyForView>(List.Where(item => item.OsobaNazwisko != null && item.OsobaNazwisko.StartsWith(FindTextBox)));
                    break;
                case "Obiekt":
                    List = new ObservableCollection<WizytyForView>(List.Where(item => item.ObiektSportowyNazwa != null && item.ObiektSportowyNazwa.StartsWith(FindTextBox)));
                    break;
                case "Szafka":
                    List = new ObservableCollection<WizytyForView>(List.Where(item => item.NrSzafki != null && item.NrSzafki.StartsWith(FindTextBox)));
                    break;
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<WizytyForView>
                (
                     from wizyta in GymFitEntities.Wizyta
                     where wizyta.CzyAktywny == true
                     select new WizytyForView
                     {
                         Id = wizyta.Id,
                         OsobaImie = wizyta.Klient.Osoba.Imie,
                         OsobaNazwisko = wizyta.Klient.Osoba.Nazwisko,
                         CzasRozpoczecia = wizyta.DataCzasRozpoczecia,
                         CzasZakonczenia = wizyta.DataCzasZakonczenia,
                         NrSzafki = wizyta.Szafka.Numer,
                         ObiektSportowyNazwa = wizyta.ObiektSportowy.Nazwa,
                         CzyAktywny = wizyta.CzyAktywny
                     }
                );
        }
        public override void DeleteRecord()
        {
                var modified = GymFitEntities.Wizyta.Find(SelectedItemToDelete.Id);
                modified.CzyAktywny = false;
                GymFitEntities.SaveChanges();
        }
        #endregion
    }
}