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
    public class TowaryViewModel : WszystkieViewModel<TowarForView>
    {

        #region Constructor
        public TowaryViewModel()
            : base("Towary")
        {
        }
        #endregion
        #region Properties
        public TowarForView SelectedItemToDelete { get; set; }
        #endregion
        #region Sort/Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa", "Kod", "Cena", "Marża"};
        }
        public override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    List = new ObservableCollection<TowarForView>(List.OrderBy(Item => Item.Nazwa));
                    break;
                case "Kod":
                    List = new ObservableCollection<TowarForView>(List.OrderBy(Item => Item.Kod));
                    break;
                case "Cena":
                    List = new ObservableCollection<TowarForView>(List.OrderBy(Item => Item.Cena));
                    break;
                case "Marża":
                    List = new ObservableCollection<TowarForView>(List.OrderBy(Item => Item.Marza));
                    break;
            }
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa", "Kod" };
        }
        public override void Find()
        {
            switch (FindField)
            {
                case "Nazwa":
                    List = new ObservableCollection<TowarForView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
                    break;
                case "Kod":
                    List = new ObservableCollection<TowarForView>(List.Where(item => item.Kod != null && item.Kod.StartsWith(FindTextBox)));
                    break;
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<TowarForView>
                (
                    from towar in GymFitEntities.Towar
                    where towar.CzyAktywny == true
                    select new TowarForView
                    {
                        Id = towar.Id,
                        Kod = towar.Kod,
                        Nazwa = towar.Nazwa,
                        StawkaVatZakupu = towar.StawkaVatZakupu,
                        StawkaVatSprzedazy = towar.StawkaVatSprzedazy,
                        Marza = towar.Marza,
                        Cena = towar.Cena,
                        CzyAktywny = towar.CzyAktywny
                    }
                );
        }
        public override void DeleteRecord()
        {
            var modified = GymFitEntities.Towar.Find(SelectedItemToDelete.Id);
            modified.CzyAktywny = false;
            GymFitEntities.SaveChanges();
        }
        #endregion
    }
}