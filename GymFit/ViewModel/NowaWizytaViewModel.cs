using GalaSoft.MvvmLight.Messaging;
using GymFit.Helpers;
using GymFit.Model.Entities;
using GymFit.Model.EntitiesForView;
using GymFit.Model.Validators;
using GymFit.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GymFit.ViewModel
{
    public class NowaWizytaViewModel : JedenViewModel<Wizyta>
    {
        #region Fields
        private BaseCommand _ShowKlienci;
        #endregion
        #region Constructor
        public NowaWizytaViewModel()
            : base("Nowy wizyta")
        {
            Item = new Wizyta();
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
        public int? IdPracownika
        {
            get
            {
                return Item.IdPracownika;
            }
            set
            {
                if (Item.IdPracownika != value)
                {
                    Item.IdPracownika = value;
                    base.OnPropertyChanged(() => IdPracownika);
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
        public int? IdKarnetu
        {
            get
            {
                return Item.IdKarnetu;
            }
            set
            {
                if (Item.IdKarnetu != value)
                {
                    Item.IdKarnetu = value;
                    base.OnPropertyChanged(() => IdKarnetu);
                }
            }
        }
        public int? IdSzafki
        {
            get
            {
                return Item.IdSzafki;
            }
            set
            {
                if (Item.IdSzafki != value)
                {
                    Item.IdSzafki = value;
                    base.OnPropertyChanged(() => IdSzafki);
                }
            }
        }
        public int? IdObiektu
        {
            get
            {
                return Item.IdObiektu;
            }
            set
            {
                if (Item.IdObiektu != value)
                {
                    Item.IdObiektu = value;
                    base.OnPropertyChanged(() => IdObiektu);
                }
            }
        }
        public DateTime? DataCzasRozpoczecia
        {
            get
            {
                return Item.DataCzasRozpoczecia;
            }
            set
            {
                if (Item.DataCzasRozpoczecia != value)
                {
                    Item.DataCzasRozpoczecia = value;
                    base.OnPropertyChanged(() => DataCzasRozpoczecia);
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
        public IQueryable<KeyAndValue> ObiektyComboboxItem
        {
            get
            {
                return
                    (
                        from obiekt in GymFitEntities.ObiektSportowy
                        select new KeyAndValue
                        {
                            Key = obiekt.Id,
                            Value = obiekt.Nazwa
                        }
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<KeyAndValue> SzafkiComboboxItem
        {
            get
            {
                return
                    (
                        from szafka in GymFitEntities.Szafka
                        select new KeyAndValue
                        {
                            Key = szafka.Id,
                            Value = szafka.Numer
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
                if (_Klient != value)
                {
                    _Klient = value;
                    base.OnPropertyChanged(() => Klient);
                }
            }
        }
        private string _Obiekt;
        public string Obiekt
        {
            get
            {
                return _Obiekt;
            }
            set
            {
                if (_Obiekt != value)
                {
                    _Obiekt = value;
                    base.OnPropertyChanged(() => Obiekt);
                }
            }
        }
        private string _Szafka;
        public string Szafka
        {
            get
            {
                return _Szafka;
            }
            set
            {
                if (_Szafka != value)
                {
                    _Szafka = value;
                    base.OnPropertyChanged(() => Szafka);
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
                if (name == "DataCzasRozpoczecia")
                {
                    komunikat =
                        DateTimeValidator.CzyDataZPrzeszlosci(this.DataCzasRozpoczecia);
                }
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["DataCzasRozpoczecia"] == null)
                return true;
            return false;
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            Item.CzyAktywny = true;
            GymFitEntities.Wizyta.Add(Item);
            GymFitEntities.SaveChanges();
        }
        private void getWybranyKlient(KlienciForView klient)
        {
            IdKlienta = klient.Id;
            Klient = klient.OsobaImie + " " + klient.OsobaNazwisko;
        }
        #endregion
    }
}

