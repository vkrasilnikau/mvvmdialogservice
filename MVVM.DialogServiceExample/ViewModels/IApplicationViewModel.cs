using System;

namespace MVVM.DialogServiceExample.ViewModels
{
    public interface IApplicationViewModel
    {
        ISettingsViewModel Settings { get; }
        IModuleViewModel Module { get; }
        bool IsModelScreen { get; }
        void Run();
    }
}