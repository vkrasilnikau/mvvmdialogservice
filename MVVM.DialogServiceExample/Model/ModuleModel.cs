using System;

namespace MVVM.DialogServiceExample.Model
{
    public sealed class ModuleModel : IModuleModel
    {
        public void Activate(UserModel user)
        {
            if (user == null) throw new ArgumentNullException();
            Login = user.Login;
        }

        public string Login { get; private set; }
    }
}