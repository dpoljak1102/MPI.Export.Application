using MPI.ViewModels;

namespace MPI.Service.Common
{
    /// <summary>
    /// IService for navigating between different ViewModels in the application.
    /// </summary>
    public interface INavigationService
    {
        ViewModelBase CurrentView { get; }
        ViewModelBase CurrentContent { get; set; }

        void NavigateTo<T>() where T : ViewModelBase;
        void NavigateTo<T>(object parameters) where T : ViewModelBase;
        void NavigateToContent<T>() where T : ViewModelBase;
        void NavigateToContent<T>(object parameters) where T : ViewModelBase;
    }
}
