
using MPI.Service.Common;

namespace MPI.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {

        public HomeViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
    }
}
