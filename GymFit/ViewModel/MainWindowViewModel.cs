using GalaSoft.MvvmLight.Messaging;
using GymFit.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace GymFit.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        //poprzez MainWindowViewModel będziemy sterować kolekcją linków które będą znajdowały się po lewej stronie okna
        //oraz kolekcją zakładek, które będą znajdowały się po prawej stronie okna
        //to jest kolekcja linków po lewej stronie
        private ReadOnlyCollection<CommandViewModel> _Commands; //każdy link po lewej stronie jest CommandViewModelem
        //poniższe oznacza zbiór zakładek po prawej stronie
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion
        #region NaviBarCommands
        private BaseCommand _CreateWejscieWyjscieCommand;
        //to jest komenda która zostanie podpieta pod przyciski w pasku NaviBar - Pod button nie można podłączać funkcji tylko komendę która wywoła funkcję
        public ICommand CreateWejscieWyjscieCommand
        {
            get
            {
                if (_CreateWejscieWyjscieCommand == null)
                    _CreateWejscieWyjscieCommand = new BaseCommand(() => Create(new WejscieWyjscieViewModel()));
                return _CreateWejscieWyjscieCommand;
            }
        }
        private BaseCommand _CreateKarnetyCommand;
        public ICommand CreateKarnetyCommand
        {
            get
            {
                if (_CreateKarnetyCommand == null)
                    _CreateKarnetyCommand = new BaseCommand(() => ShowKarnety());
                return _CreateKarnetyCommand;
            }
        }
        private BaseCommand _CreateFakturyCommand;
        public ICommand CreateFakturyCommand
        {
            get
            {
                if (_CreateFakturyCommand == null)
                    _CreateFakturyCommand = new BaseCommand(() => Create(new FakturyViewModel()));
                return _CreateFakturyCommand;
            }
        }
        private BaseCommand _CreateNowaFakturaCommand;
        public ICommand CreateNowaFakturaCommand
        {
            get
            {
                if (_CreateNowaFakturaCommand == null)
                    _CreateNowaFakturaCommand = new BaseCommand(() => Create(new NowaFakturaViewModel()));
                return _CreateNowaFakturaCommand;
            }
        }
        private BaseCommand _CreateHistoriaWizytCommand;
        public ICommand CreateHistoriaWizytCommand
        {
            get
            {
                if (_CreateHistoriaWizytCommand == null)
                    _CreateHistoriaWizytCommand = new BaseCommand(() => ShowWizyty());
                return _CreateHistoriaWizytCommand;
            }
        }
        private BaseCommand _CreateKlienciCommand;
        public ICommand CreateKlienciCommand
        {
            get
            {
                if (_CreateKlienciCommand == null)
                    _CreateKlienciCommand = new BaseCommand(() => ShowKlienci());
                return _CreateKlienciCommand;
            }
        }
        //private BaseCommand _CreateDostawcyCommand;
        //public ICommand CreateDostawcyCommand
        //{
        //    get
        //    {
        //        if (_CreateDostawcyCommand == null)
        //            _CreateDostawcyCommand = new BaseCommand(() => Create(new DostawcyViewModel()));
        //        return _CreateDostawcyCommand;
        //    }
        //}
        #endregion
        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                //sprawdzamy czy lista linków po lewej stronie jest pusta
                if (_Commands == null)
                {
                    //Jeżeli lista linków jest pusta to tworzymy tą listę za pomocą funkcji CreateCommands()
                    List<CommandViewModel> cmds = this.CreateCommands();
                    //Tworzymy ReadOnlyCollection na bazie Listy komend utworzonej powyżej
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            //To jest massanger który czeka na przesłanie stringa i jak go otrzyma to wywołuje metodę open() w celu otwarcia odpowiedniej zakładki(zależnej od treści stringa)
            Messenger.Default.Register<string>(this, open);
            //W tej metodzie decydujemy jakie linki będą po lewej stronie
            return new List<CommandViewModel>
            {
                new CommandViewModel("Karnety", new BaseCommand(() => this.ShowKarnety())),
                new CommandViewModel("Klienci", new BaseCommand(() => this.ShowKlienci())),
                new CommandViewModel("Wizyty", new BaseCommand(() => this.ShowWizyty())),
                new CommandViewModel("Faktury", new BaseCommand(() => this.ShowFaktury())),
                new CommandViewModel("Adresy", new BaseCommand(() => this.ShowAdresy())),
                new CommandViewModel("Dostawcy", new BaseCommand(() => this.ShowDostawcy())),
                new CommandViewModel("Towary", new BaseCommand(() => this.ShowTowary())),
                //new CommandViewModel("Wejście/Wyjście", new BaseCommand(() => this.Create(new WejscieWyjscieViewModel()))), //Tworzymy link z lewej strony który nazywa się Wejście/Wyjście i wywołuje funkcję CreateTowar(), która jest niżej
                ////new CommandViewModel("Dokumenty KP/KW", new BaseCommand(() => this.Create(new FakturyViewModel()))),
                //new CommandViewModel("Dodaj nową notatke", new BaseCommand(() => this.Create(new NowaNotatkaViewModel()))),
                //new CommandViewModel("Dodaj nowe zadanie", new BaseCommand(() => this.Create(new DodajZadanieViewModel()))),
                //new CommandViewModel("Wystaw fakture", new BaseCommand(() => this.Create(new NowaFakturaViewModel()))),
                new CommandViewModel("Pełny ekran", FullScreen),
                new CommandViewModel("Zakończ", Close)
                };

        }
        #endregion
        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if(_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;
            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }
        #endregion
        #region PrivateHelpers
        private void Create(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        ////Funkcje ShowAll cokolwiek np ShowAllTowar najpierw sprawdzają czy zakładki nie ma na liście, jeżeli jest to ją uaktywnia, jeżeli nie to otwiera nową
        private void ShowKarnety()
        {
            //w kolekcji wszystkich zakładek o nazwie workspaces, szukam takiej zakładki, która jest WejscieWyjscieViewModel,
            //jeżeli jest to traktuję ja jako WejscieWyjscieViewModel
            KarnetyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is KarnetyViewModel)
                as KarnetyViewModel;
            //jeżeli nie ma jej w kolekcji tworzę nową zakładkę i dodaję do kolekcji wyświetlanych zakładek
            if (workspace == null)
            {
                workspace = new KarnetyViewModel();
                this.Workspaces.Add(workspace);
            }
            //uaktywniam zakładkę, którą znalazłem lub dodałem
            this.SetActiveWorkspace(workspace);
        }
        private void ShowWizyty()
        {
            WizytyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WizytyViewModel)
                as WizytyViewModel;
            if(workspace == null)
            {
                workspace = new WizytyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowKlienci()
        {
            KlienciViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is KlienciViewModel)
                as KlienciViewModel;
            if (workspace == null)
            {
                workspace = new KlienciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowFaktury()
        {
            FakturyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is FakturyViewModel)
                as FakturyViewModel;
            if (workspace == null)
            {
                workspace = new FakturyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAdresy()
        {
            AdresyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AdresyViewModel)
                as AdresyViewModel;
            if (workspace == null)
            {
                workspace = new AdresyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowDostawcy ()
        {
            DostawcyViewModel workspace =
               this.Workspaces.FirstOrDefault(vm => vm is DostawcyViewModel)
               as DostawcyViewModel;
            if (workspace == null)
            {
                workspace = new DostawcyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        public void ShowTowary()
        {
            TowaryViewModel workspace =
               this.Workspaces.FirstOrDefault(vm => vm is TowaryViewModel)
               as TowaryViewModel;
            if (workspace == null)
            {
                workspace = new TowaryViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        private void open(string name)
        {
            switch(name)
            {
                case "KarnetyAdd":
                    this.Create(new NowyKarnetViewModel());
                    break;
                case "KlienciAdd":
                    this.Create(new NowyKlientViewModel());
                    break;
                case "KlienciShow":
                    this.ShowKlienci();
                    break;
                case "AdresyAdd":
                    this.Create(new NowyAdresViewModel());
                    break;
                case "AdresyShow":
                    this.ShowAdresy();
                    break;
                case "WizytyAdd":
                    this.Create(new NowaWizytaViewModel());
                    break;
                case "FakturyAdd":
                    this.Create(new NowaFakturaViewModel());
                    break;
                case "DostawcyAdd":
                    this.Create(new NowyDostawcaViewModel());
                    break;
                case "TowaryAdd":
                    this.Create(new NowyTowarViewModel());
                    break;
            }
        }
        #endregion
    }
}