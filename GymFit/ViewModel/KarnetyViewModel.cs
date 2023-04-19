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
    public class KarnetyViewModel  : WszystkieViewModel<KarnetyForView>
    {
        #region Constructor
        public KarnetyViewModel()
            :base("Karnety")
        {
        }
        #endregion
        #region Properties
        public KarnetyForView SelectedItemToDelete { get; set; }
        #endregion
        #region Sort/Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nr karnetu", "Ważny od", "Ważny do", "Imię", "Nazwisko" };
        }
        public override void Sort()
        {
            switch(SortField)
            {
                case "Nr karnetu":
                    List = new ObservableCollection<KarnetyForView>(List.OrderBy(Item => Item.NrKarty));
                    break;
                case "Ważny od":
                    List = new ObservableCollection<KarnetyForView>(List.OrderBy(Item => Item.WaznyOd));
                    break;
                case "Ważny do":
                    List = new ObservableCollection<KarnetyForView>(List.OrderBy(Item => Item.WaznyDo));
                    break;
                case "Imię":
                    List = new ObservableCollection<KarnetyForView>(List.OrderBy(Item => Item.KlientImie));
                    break;
                case "Nazwisko":
                    List = new ObservableCollection<KarnetyForView>(List.OrderBy(Item => Item.KlientNazwisko));
                    break;
            }
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nr karnetu", "Imię", "Nazwisko" };
        }
        public override void Find()
        {
            switch(FindField)
            {
                case "Nr karnetu":
                    List = new ObservableCollection<KarnetyForView>(List.Where(item => item.NrKarty != null && item.NrKarty.StartsWith(FindTextBox)));
                    break;
                case "Imię":
                    List = new ObservableCollection<KarnetyForView>(List.Where(item => item.KlientImie != null && item.KlientImie.StartsWith(FindTextBox)));
                    break;
                case "Nazwisko":
                    List = new ObservableCollection<KarnetyForView>(List.Where(item => item.KlientNazwisko != null && item.KlientNazwisko.StartsWith(FindTextBox)));
                    break;
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            //Do listy przekazuję z bazy danych wszystkie dane o karnetach używając dostępu do bazy danych poprzez gimFitEntities
            List = new ObservableCollection<KarnetyForView>
                (
                    from karnet in GymFitEntities.Karnet
                    where karnet.CzyAktywny == true
                    select new KarnetyForView
                    {
                        IdKarnetu = karnet.Id,
                        NrKarty = karnet.NumerKarty,
                        WaznyOd = karnet.WaznyOd,
                        WaznyDo = karnet.WaznyDo,
                        KlientImie = karnet.Klient.Osoba.Imie,
                        KlientNazwisko = karnet.Klient.Osoba.Nazwisko,
                        CzyAktywny = karnet.CzyAktywny
                    }
                );
        }
        public override void DeleteRecord()
        {
            var modified = GymFitEntities.Karnet.Find(SelectedItemToDelete.IdKarnetu);
            modified.CzyAktywny = false;
            GymFitEntities.SaveChanges();
        }
        #endregion
    }
}
