using GymFit.Model.Entities;
using GymFit.Model.EntitiesForView;
using GymFit.Model.Validators;
using GymFit.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymFit.ViewModel
{
    public class NowyAdresViewModel : JedenViewModel<Adres>, IDataErrorInfo
    {
        #region Fields
        #endregion
        #region Constructor
        public NowyAdresViewModel()
            : base("Nowy Adres")
        {
            Item = new Adres();
            DataCzasDodania = DateTime.Now;
        }
        #endregion
        #region Commands
        #endregion
        #region Properties
        public string Kraj
        {
            get
            {
                return Item.Kraj;
            }
            set
            {
                if (Item.Kraj != value)
                {
                    Item.Kraj = value;
                    base.OnPropertyChanged(() => Kraj);
                }
            }
        }
        public string Miejscowosc
        {
            get
            {
                return Item.Miejscowosc;
            }
            set
            {
                if (Item.Miejscowosc != value)
                {
                    Item.Miejscowosc = value;
                    base.OnPropertyChanged(() => Miejscowosc);
                }
            }
        }
        public string Ulica
        {
            get
            {
                return Item.Ulica;
            }
            set
            {
                if (Item.Ulica != value)
                {
                    Item.Ulica = value;
                    base.OnPropertyChanged(() => Ulica);
                }
            }
        }
        public string NrDomu
        {
            get
            {
                return Item.NrDomu;
            }
            set
            {
                if (Item.NrDomu != value)
                {
                    Item.NrDomu = value;
                    base.OnPropertyChanged(() => NrDomu);
                }
            }
        }
        public string NrLokalu
        {
            get
            {
                return Item.NrLokalu;
            }
            set
            {
                if (Item.NrLokalu != value)
                {
                    Item.NrLokalu = value;
                    base.OnPropertyChanged(() => NrLokalu);
                }
            }
        }
        public string KodPocztowy
        {
            get
            {
                return Item.KodPocztowy;
            }
            set
            {
                if (Item.KodPocztowy != value)
                {
                    Item.KodPocztowy = value;
                    base.OnPropertyChanged(() => KodPocztowy);
                }
            }
        }
        public string Poczta
        {
            get
            {
                return Item.Poczta;
            }
            set
            {
                if (Item.Poczta != value)
                {
                    Item.Poczta = value;
                    base.OnPropertyChanged(() => Poczta);
                }
            }
        }
        public bool CzyAktywny
        {
            get
            {
                return Item.CzyAktywny;
            }
            set
            {
                if (Item.CzyAktywny != value)
                {
                    Item.CzyAktywny = value;
                    base.OnPropertyChanged(() => CzyAktywny);
                }
            }
        }
        public DateTime? DataCzasDodania
        {
            get
            {
                return Item.DataCzasDodania;
            }
            set
            {
                if (Item.DataCzasDodania != value)
                {
                    Item.DataCzasDodania = value;
                    base.OnPropertyChanged(() => DataCzasDodania);
                }
            }
        }
        public IQueryable<Wojewodztwo> WojewodztwaComboBoxItems
        {
            get
            {
                return
                    (
                        from wojewodztwo in GymFitEntities.Wojewodztwo
                        select wojewodztwo
                    ).ToList().AsQueryable();
            }
        }
        public string IdWojewodztwa
        {
            get
            {
                return Item.IdWojewodztwa;
            }
            set
            {
                if(Item.IdWojewodztwa != value)
                {
                    Item.IdWojewodztwa = value;
                    base.OnPropertyChanged(() => IdWojewodztwa);
                }
            }
        }

        #endregion
        #region Validation
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "Kraj")
                {
                    komunikat =
                        StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Kraj);
                }
                if (name == "Miejscowosc")
                {
                    komunikat =
                         StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Miejscowosc);
                }
                if (name == "Ulica")
                {
                    komunikat =
                         StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Ulica);
                }
                if (name == "NrDomu")
                {
                    komunikat =
                        StringValidator.SprawdzCzyZawieraCyfręNaPoczatku(this.NrDomu);
                }
                if (name == "NrLokalu")
                {
                    komunikat =
                         StringValidator.SprawdzCzyZawieraCyfręNaPoczatkuLubPuste(this.NrLokalu);
                }
                if (name == "KodPocztowy")
                {
                    komunikat =
                         StringValidator.SprawdzCzyZawieraCyfręNaPoczatku(this.KodPocztowy);
                }
                if (name == "Poczta")
                {
                    komunikat =
                         StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Poczta);
                }
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Kraj"] == null && this["Miejscowosc"] == null && this["Ulica"] == null && this["NrDomu"] == null && this["NrLokalu"] == null && this["KodPocztowy"] == null && this["Poczta"] == null)
                return true;
            return false;
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            Item.CzyAktywny = true;
            GymFitEntities.Adres.Add(Item);
            GymFitEntities.SaveChanges();
        }
        #endregion
    }
}