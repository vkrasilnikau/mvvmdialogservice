using System;
using System.Collections.Generic;
using System.Windows;
using MVVM.DialogServiceExample.Model;
using MVVM.DialogServiceExample.Views;

namespace MVVM.DialogServiceExample.ViewModels
{
    public sealed class ApplicationViewModel : ViewModelBase, IApplicationViewModel
    {
        private const string LOGIN_DLG = "LOGIN_DLG";

        private readonly IApplicationModel _model;
        private ISettingsViewModel _settings;
        private IModuleViewModel _module;
        private bool _isModelScreen;
        private readonly IDialogService _dialogService;

        public ApplicationViewModel(IApplicationModel model, IDialogService dialogService)
        {
            _model = model;
            _dialogService = dialogService;
            var map = new Dictionary<string, Func<Window>>();
            map[LOGIN_DLG] = () => new LoginWindow();
            _dialogService.Configure(map);
            Settings = new SettingsViewModel(_model.Settings);
            Module = new ModuleViewModel(_model.Module);
        }

        void Settings_Saved(object sender, EventArgs e)
        {
            IsModelScreen = true;
            _dialogService.CloseDialog(LOGIN_DLG);
            _model.Settings.Saved -= Settings_Saved;
            Module.Refresh();
        }

        public ISettingsViewModel Settings
        {
            get { return _settings; }
            private set
            {
                _settings = value;
                Notify("Settings");
            }
        }

        public IModuleViewModel Module
        {
            get { return _module; }
            private set
            {
                _module = value;
                Notify("Module");
            }
        }

        public bool IsModelScreen
        {
            get { return _isModelScreen; }
            private set
            {
                _isModelScreen = value;
                Notify("IsModelScreen");
            }
        }

        public void Run()
        {
            _model.Run();
            _model.Settings.Saved += Settings_Saved;
            if (!_isModelScreen)
            {
                _dialogService.ShowDialog(LOGIN_DLG, Settings);
            }
        }
    }
}