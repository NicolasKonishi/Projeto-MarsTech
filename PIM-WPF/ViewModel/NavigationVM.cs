using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIM_WPF.Utilities;
using PIM_WPF.Controle;
using PIM_WPF.ViewModel;
using System.Windows.Input;
using PIM_WPF.View;
using System.Transactions;


namespace PIM_WPF.Controle
{
    internal class NavigationVM : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand IntroducaoCommand { get; set; }
        public ICommand MaisCommand { get; set; }
        public ICommand ObrasCommand { get; set; }
        public ICommand QuestionarioCommand { get; set; }
        public ICommand ResultadosCommand { get; set; }
        public ICommand SobreCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeVM();
        private void Introducao(object obj) => CurrentView = new IntroducaoVM();
        private void Mais(object obj) => CurrentView = new MaisVM();
        private void Obras(object obj) => CurrentView = new ObrasVM();
        private void Questionario(object obj) => CurrentView = new QuestionarioVM();
        private void Resultados(object obj) => CurrentView = new ResultadosVM();
        private void Sobre(object obj) => CurrentView = new SobreVM();

        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            IntroducaoCommand = new RelayCommand(Introducao);
            MaisCommand = new RelayCommand(Mais);
            ObrasCommand = new RelayCommand(Obras);
            QuestionarioCommand = new RelayCommand(Questionario);
            ResultadosCommand = new RelayCommand(Resultados);
            SobreCommand = new RelayCommand(Sobre);

            // Startup Page
            CurrentView = new HomeVM();
        }
    }
}
