using System;
using System.Threading.Tasks;

namespace MVVM.DialogServiceExample.Model
{
    public interface ISettingsModel
    {
        UserModel User { get; set; }
        Task Save();
        event EventHandler<EventArgs> Saved;
    }
}