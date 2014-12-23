using System.Windows.Input;
using MVVM.DialogServiceExample.Model;

namespace MVVM.DialogServiceExample.ViewModels
{
    public interface ISettingsViewModel
    {
        string Login { get; set; }
        string Password { get; set; }
        ICommand SaveCommand { get; }
        ISettingsModel Model { get; }
        bool IsBusy { get; set; }
    }
}