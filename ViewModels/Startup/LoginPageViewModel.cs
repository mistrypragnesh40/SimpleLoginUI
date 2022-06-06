using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using SimpleLoginUI.Controls;
using SimpleLoginUI.Models;
using SimpleLoginUI.Views.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLoginUI.ViewModels.Startup
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        #region Commands
        [ICommand]
        async void Login()
        {
            if(!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
                // calling api 

                var userDetails = new UserBasicInfo()
                {
                    Email = Email,
                    FullName = "Test User Name"
                };


                if (Preferences.ContainsKey(nameof(App.UserDetails)))
                {
                    Preferences.Remove(nameof(App.UserDetails));
                }

                string userDetailStr = JsonConvert.SerializeObject(userDetails);
                Preferences.Set(nameof(App.UserDetails), userDetailStr);
                App.UserDetails = userDetails;
                AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();

                await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
            }


        }
        #endregion
    }
}
