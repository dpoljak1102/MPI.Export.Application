using MPI.Core;
using MPI.Service.Common;

namespace MPI.ViewModels
{
    public abstract class ViewModelBase : ObservableObject
    {
        private INavigationService? _navigationService;

        public INavigationService? NavigationService
        {
            get => _navigationService;
            set { _navigationService = value; OnPropertyChanged(); }
        }
    }
}
