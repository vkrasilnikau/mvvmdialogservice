using MVVM.DialogServiceExample.Model;
using MVVM.DialogServiceExample.ViewModels;

namespace MVVM.DialogServiceExample
{
    public static class Bootstrapper
    {
        public static IApplicationViewModel Run()
        {
            var model = new ApplicationModel(new SettingsModel(), new ModuleModel());
            return new ApplicationViewModel(model, new DialogService());
        }
    }
}