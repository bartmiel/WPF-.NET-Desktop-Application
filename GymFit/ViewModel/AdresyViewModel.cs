using GalaSoft.MvvmLight.Messaging;
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
    public class AdresyViewModel : WszystkieViewModel<AdresForView>
    {
        #region Constructor
        public AdresyViewModel()
            : base("Adresy")
        {
        }
        #endregion
        #region Properties
        public AdresForView SelectedItemToDelete { get; set; }
        private AdresForView _WybranyAdres;
        public AdresForView WybranyAdres
        {
            get
            {
                return _WybranyAdres;
            }
            set
            {
                _WybranyAdres = value;
                Messenger.Default.Send(_WybranyAdres);
                base.OnRequestClose();
            }
        }
        #endregion
        #region Sort/Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Kraj", "Województwo", "Miejscowość", "Kod pocztowy"};
        }
        public override void Sort()
        {
            switch (SortField)
            {
                case "Kraj":
                    List = new ObservableCollection<AdresForView>(List.OrderBy(Item => Item.Kraj));
                    break;
                case "Miejscowość":
                    List = new ObservableCollection<AdresForView>(List.OrderBy(Item => Item.Miejscowosc));
                    break;
                case "Kod pocztowy":
                    List = new ObservableCollection<AdresForView>(List.OrderBy(Item => Item.KodPocztowy));
                    break;
                case "Województwo":
                    List = new ObservableCollection<AdresForView>(List.OrderBy(Item => Item.IdWojewodztwa));
                    break;
            }
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Kraj", "Województwo", "Miejscowość", "Kod pocztowy" };
        }
        public override void Find()
        {
            switch (FindField)
            {
                case "Kraj":
                    List = new ObservableCollection<AdresForView>(List.Where(item => item.Kraj != null && item.Kraj.StartsWith(FindTextBox)));
                    break;
                case "Miejscowość":
                    List = new ObservableCollection<AdresForView>(List.Where(item => item.Miejscowosc != null && item.Miejscowosc.StartsWith(FindTextBox)));
                    break;
                case "Kod pocztowy":
                    List = new ObservableCollection<AdresForView>(List.Where(item => item.KodPocztowy != null && item.KodPocztowy.StartsWith(FindTextBox)));
                    break;
                case "Województwo":
                    List = new ObservableCollection<AdresForView>(List.Where(item => item.IdWojewodztwa != null && item.IdWojewodztwa.StartsWith(FindTextBox)));
                    break;
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<AdresForView>
                (
                     from adres in GymFitEntities.Adres
                     where adres.CzyAktywny == true
                     select new AdresForView
                     {
                         Id = adres.Id,
                         Kraj = adres.Kraj,
                         IdWojewodztwa = adres.IdWojewodztwa,
                         Miejscowosc = adres.Miejscowosc,
                         Ulica = adres.Ulica,
                         NrDomu = adres.NrDomu,
                         NrLokalu = adres.NrLokalu,
                         KodPocztowy = adres.KodPocztowy,
                         Poczta = adres.Poczta,
                         CzyAktywny = adres.CzyAktywny
                     }
                );
        }
        public override void DeleteRecord()
        {
            var modified = GymFitEntities.Adres.Find(SelectedItemToDelete.Id);
            modified.CzyAktywny = false;
            GymFitEntities.SaveChanges();
        }
        #endregion
    }
}