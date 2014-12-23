using MVVM.DialogServiceExample.Model;

namespace MVVM.DialogServiceExample.ViewModels
{
    public sealed class ModuleViewModel : ViewModelBase, IModuleViewModel
    {
        private readonly IModuleModel _model;

        public ModuleViewModel(IModuleModel model)
        {
            _model = model;
        }

        public string Login
        {
            get { return _model.Login; }
        }

        public void Refresh()
        {
            Notify("Login");
        }
    }
}