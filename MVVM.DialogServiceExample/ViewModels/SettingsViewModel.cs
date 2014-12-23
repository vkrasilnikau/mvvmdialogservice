using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM.DialogServiceExample.Model;

namespace MVVM.DialogServiceExample.ViewModels
{
    public sealed class SettingsViewModel : ViewModelBase, ISettingsViewModel
    {
        private string _login = string.Empty;
        private string _password = string.Empty;
        private ICommand _saveCommand;
        private readonly ISettingsModel _settings;
        private bool _isBusy = false;

        public SettingsViewModel(ISettingsModel settings)
        {
            _settings = settings;
        }

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                Notify("Login");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                Notify("Password");
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new SaveCommandImpl(this);
                }
                return _saveCommand;
            }
        }

        public ISettingsModel Model
        {
            get { return _settings; }
        }

        private class SaveCommandImpl : ICommand
        {
            private readonly ISettingsViewModel _settingsViewModel;

            public SaveCommandImpl(ISettingsViewModel settingsViewModel)
            {
                _settingsViewModel = settingsViewModel;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                _settingsViewModel.IsBusy = true;
                _settingsViewModel.Model.User = new UserModel { Login = _settingsViewModel.Login, Password = _settingsViewModel.Password };
                _settingsViewModel.Model.Save().ContinueWith(t => _settingsViewModel.IsBusy = false, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                Notify("IsBusy");
            }
        }
    }
}