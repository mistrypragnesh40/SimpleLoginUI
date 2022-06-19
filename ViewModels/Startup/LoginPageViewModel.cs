using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using SimpleLoginUI.Controls;
using SimpleLoginUI.Models;
using SimpleLoginUI.Services;
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


        private readonly ILoginService _loginService;
        public LoginPageViewModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        #region Commands
        [ICommand]
        async void Login()
        {
            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
                // calling api 
                var response = await _loginService.Authenticate(new LoginRequest
                {
                    UserName = Email,
                    Password = Password
                });

                if(response != null)
                {

                    if (response.UserDetail.Role == null)
                    {
                        await AppShell.Current.DisplayAlert("No Role Assigned", 
                            "No role assigned to this user.", "OK");
                        return;
                    }
                    response.UserDetail.Email = Email;

                    if (Preferences.ContainsKey(nameof(App.UserDetails)))
                    {
                        Preferences.Remove(nameof(App.UserDetails));
                    }

                    await SecureStorage.SetAsync(nameof(App.Token), response.Token);

                    string userDetailStr = JsonConvert.SerializeObject(response.UserDetail);
                    Preferences.Set(nameof(App.UserDetails), userDetailStr);
                    App.UserDetails = response.UserDetail;
                    App.Token = response.Token;
                    await AppConstant.AddFlyoutMenusDetails();
                 
                }
                else
                {
                    await AppShell.Current.DisplayAlert("Invalid User Name Or Password", "Invalid UserName or Password", "OK");
                }


              
            }


        }
        #endregion
    }
}
