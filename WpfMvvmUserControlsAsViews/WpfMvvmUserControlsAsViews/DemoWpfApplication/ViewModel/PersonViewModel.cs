using System.Windows.Input;
using DemoWpfApplication.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace DemoWpfApplication.ViewModel
{
    public class PersonViewModel : BaseViewModel
    {
        public PersonViewModel()
        {
            NavigateToCompanyCommand = new RelayCommand(NavigateToCompanyCommandHandler, () => true);
        }

        public ICommand NavigateToCompanyCommand { get; private set; }

        public void NavigateToCompanyCommandHandler()
        {
            var msg = new GoToPageMessage { ViewType = typeof(CompanyViewModel) };
            Messenger.Default.Send(msg);
        }
    }
}