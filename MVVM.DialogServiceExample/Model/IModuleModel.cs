using System;

namespace MVVM.DialogServiceExample.Model
{
    public interface IModuleModel
    {
        string Login { get; }
        void Activate(UserModel user);
    }
}