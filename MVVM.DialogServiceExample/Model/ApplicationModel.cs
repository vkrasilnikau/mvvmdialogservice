using System;

namespace MVVM.DialogServiceExample.Model
{
    public sealed class ApplicationModel : IApplicationModel
    {
        private readonly ISettingsModel _settings;
        private readonly IModuleModel _module;

        public ApplicationModel(ISettingsModel settings, IModuleModel module)
        {
            _settings = settings;
            _module = module;
        }

        public ISettingsModel Settings
        {
            get { return _settings; }
        }

        public IModuleModel Module
        {
            get { return _module; }
        }

        public void Run()
        {
            if (_settings != null)
            {
                _settings.Saved += SettingsOnSaved;
            }
        }

        private void SettingsOnSaved(object sender, EventArgs eventArgs)
        {
            if (_module != null)
            {
                _module.Activate(_settings.User);
            }
        }
    }
}