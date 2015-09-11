using System.Windows.Input;
using DemoWpfApplication.Model;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;

namespace DemoWpfApplication.ViewModel
{
    public class CompanyViewModel : BaseViewModel
    {
        public CompanyViewModel()
        {
            NavigateToPersonCommand = new RelayCommand(NavigateToPersonCommandHandler, () => true);
        }

        public ICommand NavigateToPersonCommand { get; private set; }

        public void NavigateToPersonCommandHandler()
        {
            var msg = new GoToPageMessage { ViewType = typeof(PersonViewModel) };
            Messenger.Default.Send(msg);
        }
    }
}