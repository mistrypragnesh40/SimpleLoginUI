using Microsoft.Toolkit.Mvvm.Input;
using SimpleLoginUI.Views.Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLoginUI.ViewModels
{
    public partial class AppShellViewModel : BaseViewModel
    {

        [ICommand]
        async void SignOut()
        {
            if (Preferences.ContainsKey(nameof(App.UserDetails)))
            {
                Preferences.Remove(nameof(App.UserDetails));
            }
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
