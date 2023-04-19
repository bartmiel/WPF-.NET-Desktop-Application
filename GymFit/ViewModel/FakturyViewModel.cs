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
    public class FakturyViewModel : WszystkieViewModel<FakturyForView>
    {
        #region Constructor
        public FakturyViewModel()
            : base("Faktury")
        {
        }
        #endregion
        #region Properties
        public FakturyForView SelectedItemToDelete { get; set; }
        #endregion
        #region Sort/Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nr dokumentu", "Dostawca", "Sposób płatności", "Data wystawienia" };
        }
        public override void Sort()
        {
            switch (SortField)
            {
                case "Nr dokumentu":
                    List = new ObservableCollection<FakturyForView>(List.OrderBy(Item => Item.Numer));
                    break;
                case "Dostawca":
                    List = new ObservableCollection<FakturyForView>(List.OrderBy(Item => Item.NazwaDostawcy));
                    break;
                case "Sposób płatności":
                    List = new ObservableCollection<FakturyForView>(List.OrderBy(Item => Item.SposobPlatnosci));
                    break;
                case "Data wystawienia":
                    List = new ObservableCollection<FakturyForView>(List.OrderBy(Item => Item.DataWystawienia));
                    break;
            }
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nr dokumentu", "Dostawca" };
        }
        public override void Find()
        {
            switch (FindField)
            {
                case "Nr dokumentu":
                    List = new ObservableCollection<FakturyForView>(List.Where(item => item.Numer != null && item.Numer.StartsWith(FindTextBox)));
                    break;
                case "Dostawca":
                    List = new ObservableCollection<FakturyForView>(List.Where(item => item.NazwaDostawcy != null && item.NazwaDostawcy.StartsWith(FindTextBox)));
                    break;
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<FakturyForView>
                (
                    from faktura in GymFitEntities.Faktura
                    where faktura.CzyAktywny == true
                    select new FakturyForView
                    {
                        Id = faktura.Id,
                        Numer = faktura.Numer,
                        NazwaDostawcy = faktura.Dostawca.Nazwa,
                        SposobPlatnosci = faktura.SposobPlatnosci.Nazwa,
                        DataWystawienia = faktura.DataWystawienia,
                        TerminPlatnosci = faktura.TerminPlatnosci,
                        CzyAktywny = faktura.CzyAktywny
                    }
                );
        }
        public override void DeleteRecord()
        {
            var modified = GymFitEntities.Faktura.Find(SelectedItemToDelete.Id);
            modified.CzyAktywny = false;
            GymFitEntities.SaveChanges();
        }
        #endregion
    }
}