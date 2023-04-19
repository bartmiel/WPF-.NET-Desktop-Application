using GymFit.Helpers;
using GymFit.Model.Entities;
using GymFit.Model.Validators;
using GymFit.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GymFit.ViewModel
{
    public class NowyTowarViewModel : JedenViewModel<Towar>, IDataErrorInfo
    {
        #region Fields
        #endregion
        #region Constructor
        public NowyTowarViewModel()
            : base("Nowy towar")
        {
            Item = new Towar();
            DataCzasDodania = DateTime.Now;
        }
        #endregion
        #region Commands
        #endregion
        #region Properties
        public string Kod
        {
            get
            {
                return Item.Kod;
            }
            set
            {
                if (Item.Kod != value)
                {
                    Item.Kod = value;
                    base.OnPropertyChanged(() => Kod);
                }
            }
        }
        public string Nazwa
        {
            get
            {
                return Item.Nazwa;
            }
            set
            {
                if (Item.Nazwa != value)
                {
                    Item.Nazwa = value;
                    base.OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public decimal? StawkaVatSprzedazy
        {
            get
            {
                return Item.StawkaVatSprzedazy;
            }
            set
            {
                if (Item.StawkaVatSprzedazy != value)
                {
                    Item.StawkaVatSprzedazy = value;
                    base.OnPropertyChanged(() => StawkaVatSprzedazy);
                }
            }
        }
        public decimal? StawkaVatZakupu
        {
            get
            {
                return Item.StawkaVatZakupu;
            }
            set
            {
                if (Item.StawkaVatZakupu != value)
                {
                    Item.StawkaVatZakupu = value;
                    base.OnPropertyChanged(() => StawkaVatZakupu);
                }
            }
        }
        public decimal? Marza
        {
            get
            {
                return Item.Marza;
            }
            set
            {
                if (Item.Marza != value)
                {
                    Item.Marza = value;
                    base.OnPropertyChanged(() => Marza);
                }
            }
        }
        public decimal? Cena
        {
            get
            {
                return Item.Cena;
            }
            set
            {
                if (Item.Cena != value)
                {
                    Item.Cena = value;
                    base.OnPropertyChanged(() => Cena);
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
                if (name == "Kod")
                {
                    komunikat =
                        StringValidator.SprawdzCzyCyfryILitery(this.Kod);
                }
                if (name == "Nazwa")
                {
                    komunikat =
                        StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Nazwa);
                }
                if (name == "StawkaVatSprzedazy")
                {
                    komunikat =
                        BusinessValidator.SprawdzVat(this.StawkaVatSprzedazy);
                }
                if (name == "StawkaVatZakupu")
                {
                    komunikat =
                        BusinessValidator.SprawdzVat(this.StawkaVatZakupu);
                }
                if (name == "Marza")
                {
                    komunikat =
                        BusinessValidator.SprawdzMarze(this.Marza, this.Cena);
                }
                if (name == "Cena")
                {
                    komunikat =
                        BusinessValidator.SprawdzCene(this.Cena);
                }
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Kod"] == null && this["Nazwa"] == null && this["StawkaVatSprzedazy"] == null && this["StawkaVatZakupu"] == null && this["Marza"] == null && this["Cena"] == null)
                return true;
            return false;
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            Item.CzyAktywny = true;
            GymFitEntities.Towar.Add(Item);
            GymFitEntities.SaveChanges();
        }
        #endregion
    }
}
