using MPI.Service.Common;

namespace MPI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            NavigationService.NavigateTo<HomeViewModel>();
        }
    }
}
