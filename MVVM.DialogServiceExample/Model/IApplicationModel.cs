using System;

namespace MVVM.DialogServiceExample.Model
{
    public interface IApplicationModel
    {
        ISettingsModel Settings { get; }
        IModuleModel Module { get; }
        void Run();
    }
}