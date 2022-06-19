using SimpleLoginUI.Models;
using SimpleLoginUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLoginUI.ViewModels.Dashboard
{
    public class StudentDashboardPageVieiwModel
    {
        public ObservableCollection<UserListResponse> Users { get; set; } =
            new ObservableCollection<UserListResponse>();

        private readonly ILoginService _loginService;
        public StudentDashboardPageVieiwModel(ILoginService loginService)
        {
            _loginService = loginService;
            GetAllUsers();
        }

        private void GetAllUsers()
        {
            Task.Run(async() =>
            {
                var userList = await _loginService.GetAllUsers();

                App.Current.Dispatcher.Dispatch(() =>
                {
                    if (userList?.Count > 0)
                    {
                        foreach(var user in userList)
                        {
                            Users.Add(user);
                        }
                    }
                });
            });
        }
    }
}
