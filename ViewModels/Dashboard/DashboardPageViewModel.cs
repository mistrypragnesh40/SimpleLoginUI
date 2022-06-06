using SimpleLoginUI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLoginUI.ViewModels.Dashboard
{
    public partial class DashboardPageViewModel : BaseViewModel
    {
        public DashboardPageViewModel()
        {
            AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
        }
    }
}
