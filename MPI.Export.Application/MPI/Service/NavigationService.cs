using MPI.Core;
using MPI.Service.Common;
using MPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPI.Service
{
    public class NavigationService : ObservableObject, INavigationService
    {
        // Fields for storing the current view, content, section, article, and aside
        // These are updated by the NavigateTo methods and can be accessed by the ViewModels
        private ViewModelBase? _currentView;
        private ViewModelBase? _currentContent;

        // The factory function used to create instances of ViewModelBase objects
        // This is injected via the constructor
        private readonly Func<Type, ViewModelBase> _viewModelFactory;
        private readonly Stack<ViewModelBase> _navigationStack;

        public NavigationService(Func<Type, ViewModelBase> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
            _navigationStack = new Stack<ViewModelBase>();
        }

        // Properties for accessing the current view, content, section, article, and aside
        #region Properties
        public ViewModelBase CurrentView
        {
            get => _currentView!;
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ViewModelBase CurrentContent
        {
            get => _currentContent!;
            set { _currentContent = value; OnPropertyChanged(); }
        }
        #endregion


        /// <summary>
        /// Navigates to the specified ViewModel of type T.
        /// </summary>
        /// <typeparam name="T">Type of the ViewModel to navigate to.</typeparam>
        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        {
            var viewModel = _viewModelFactory(typeof(TViewModel));

            if (viewModel is IHandleParameters handleParameters)
            {
                handleParameters.HandleParameters(null);
            }

            CurrentView = viewModel;
            _navigationStack.Push(viewModel);

            //CurrentContent = null;
        }

        /// <summary>
        /// Navigates to the specified ViewModel of type T with the given parameters.
        /// </summary>
        /// <typeparam name="T">Type of the ViewModel to navigate to.</typeparam>
        /// <param name="parameters">Parameters to pass to the ViewModel.</param>
        public void NavigateTo<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            var viewModel = _viewModelFactory(typeof(TViewModel));

            if (viewModel is IHandleParameters handleParameters)
            {
                handleParameters.HandleParameters(parameter);
            }

            CurrentView = viewModel;
            _navigationStack.Push(viewModel);

            //CurrentContent = null;
        }

        /// <summary>
        /// Navigates to the specified ViewModel of type T with the given parameters.
        /// </summary>
        /// <typeparam name="T">Type of the ViewModel to navigate to.</typeparam>
        /// <param name="parameters">Parameters to pass to the ViewModel.</param>
        public void NavigateToContent<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            var viewModel = _viewModelFactory(typeof(TViewModel));

            if (viewModel is IHandleParameters handleParameters)
            {
                handleParameters.HandleParameters(parameter);
            }

            CurrentContent = viewModel;
        }
        public void NavigateToContent<TViewModel>() where TViewModel : ViewModelBase
        {
            CurrentContent = _viewModelFactory(typeof(TViewModel));

        }

    }
}
