using GalaSoft.MvvmLight.Messaging;
using GymFit.Helpers;
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
using System.Windows.Input;

namespace GymFit.ViewModel
{
    public class NowyKarnetViewModel : JedenViewModel<Karnet>, IDataErrorInfo
    {
        #region Fields
        private BaseCommand _ShowKlienci;
        #endregion
        #region Constructor
        public NowyKarnetViewModel()
            : base("Nowy karnet")
        {
            Item = new Karnet();
            WaznyOd = DateTime.Now;
            DataCzasDodania = DateTime.Now;
            Messenger.Default.Register<KlienciForView>(this, getWybranyKlient);
        }
        #endregion
        #region Commands
        public ICommand ShowKlienci
        {
            get
            {
                if (_ShowKlienci == null)
                    _ShowKlienci = new BaseCommand(() => Messenger.Default.Send("KlienciShow"));
                return _ShowKlienci;
            }
        }
        #endregion
        #region Properties
        public string NrKarty
        {
            get
            {
                return Item.NumerKarty;
            }
            set
            {
                if(Item.NumerKarty != value)
                {
                    Item.NumerKarty = value;
                    base.OnPropertyChanged(() => NrKarty);
                }
            }
        }
        public DateTime? WaznyOd
        {
            get
            {
                return Item.WaznyOd;
            }
            set
            {
                if(Item.WaznyOd != value)
                {
                    Item.WaznyOd = value;
                    base.OnPropertyChanged(() => WaznyOd);
                }
            }
        }
        public DateTime? WaznyDo
        {
            get
            {
                return Item.WaznyDo;
            }
            set
            {
                if(Item.WaznyDo != value)
                {
                    Item.WaznyDo = value;
                    base.OnPropertyChanged(() => WaznyDo);
                }
            }
        }
        public int? IdKlienta
        {
            get
            {
                return Item.IdKlienta;
            }
            set
            {
                if (Item.IdKlienta != value)
                {
                    Item.IdKlienta = value;
                    base.OnPropertyChanged(() => IdKlienta);
                }
            }
        }
        public IQueryable<KeyAndValue> KlienciComboBoxItems
        {
            get
            {
                return
                    (
                        from klient in GymFitEntities.Klient
                        select new KeyAndValue
                        {
                            Key = klient.Id,
                            Value = klient.Osoba.Imie + " " + klient.Osoba.Nazwisko
                        }
                    ).ToList().AsQueryable();
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
        private string _Klient;
        public string Klient
        {
            get
            {
                return _Klient;
            }
            set
            {
                if(_Klient != value)
                {
                    _Klient = value;
                    base.OnPropertyChanged(() => Klient);
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
                if(name == "NrKarty")
                {
                    komunikat =
                        StringValidator.SprawdzCzyCyfryILitery(this.NrKarty);
                }
                if(name == "WaznyOd")
                {
                    komunikat =
                        DateTimeValidator.CzyDataZPrzeszlosci(this.WaznyOd);
                }
                if(name == "WaznyDo")
                {
                    komunikat =
                        DateTimeValidator.CzyDataPozniejszaNiz1Rok(this.WaznyDo);
                    komunikat =
                        DateTimeValidator.CzyDataZPrzeszlosci(this.WaznyDo);
                }
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["NrKarty"] == null && this["WaznyOd"] == null && this["WaznyDo"] == null)
                return true;
            return false;
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            Item.CzyAktywny = true;
            GymFitEntities.Karnet.Add(Item);
            GymFitEntities.SaveChanges();
        }
        private void getWybranyKlient(KlienciForView klient)
        {
            IdKlienta = klient.Id;
            Klient = klient.OsobaImie+" "+klient.OsobaNazwisko;
        }
        #endregion
    }
}
