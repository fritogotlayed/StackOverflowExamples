using DemoWpfApplication.Model;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;

namespace DemoWpfApplication.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _viewModel;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real"
                Messenger.Default.Register<GoToPageMessage>(this, ReceiveMessage);
                ViewModel = new CompanyViewModel();
            }
        }

        public BaseViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                _viewModel = value;
                RaisePropertyChanged();
            }
        }

        private void ReceiveMessage(GoToPageMessage action)
        {
            ViewModel = (BaseViewModel)ServiceLocator.Current.GetInstance(action.ViewType);
        }
    }
}