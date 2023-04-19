using GymFit.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymFit.ViewModel
{
    public class DostawcyViewModel : WszystkieViewModel<DostawcyForView>
    {
        #region Constructor
        public DostawcyViewModel()
            :base("Dostawcy")
        {
        }
        #endregion
        #region Properties
        public DostawcyForView SelectedItemToDelete { get; set; }
        #endregion
        #region Sort/Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa", "Status", "Kod" };
        }
        public override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    List = new ObservableCollection<DostawcyForView>(List.OrderBy(Item => Item.Nazwa));
                    break;
                case "Status":
                    List = new ObservableCollection<DostawcyForView>(List.OrderBy(Item => Item.Status));
                    break;
                case "Kod":
                    List = new ObservableCollection<DostawcyForView>(List.OrderBy(Item => Item.Kod));
                    break;
            }
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa", "Kod", "Adres siedziby" };
        }
        public override void Find()
        {
            switch (FindField)
            {
                case "Nazwa":
                    List = new ObservableCollection<DostawcyForView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
                    break;
                case "Kod":
                    List = new ObservableCollection<DostawcyForView>(List.Where(item => item.Kod != null && item.Kod.StartsWith(FindTextBox)));
                    break;
                case "Adres siedziby":
                    List = new ObservableCollection<DostawcyForView>(List.Where(item => item.AdresSiedziby != null && item.AdresSiedziby.StartsWith(FindTextBox)));
                    break;
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<DostawcyForView>
                (
                    from dostawca in GymFitEntities.Dostawca
                    where dostawca.CzyAktywny == true
                    select new DostawcyForView
                    {
                        Id = dostawca.Id,
                        AdresSiedziby = dostawca.Adres.Miejscowosc + ", ul."+ dostawca.Adres.Ulica + " " + dostawca.Adres.NrDomu + "/" + dostawca.Adres.NrLokalu,
                        Status = dostawca.Status.Nazwa,
                        Nazwa = dostawca.Nazwa,
                        Kod = dostawca.Kod,
                        OsobaKontaktowa = dostawca.OsobaKontaktowa,
                        NrTelefonu = dostawca.NrTelefonu,
                        Email = dostawca.Email,
                        CzyAktywny = dostawca.CzyAktywny
                    }
                );
        }
        public override void DeleteRecord()
        {
            var modified = GymFitEntities.Dostawca.Find(SelectedItemToDelete.Id);
            modified.CzyAktywny = false;
            GymFitEntities.SaveChanges();
        }
        #endregion
    }
}