using MetaboCoins.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetaboCoins.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginVM _viewModel;
        public LoginPage()
        {
            _viewModel = new LoginVM();
            BindingContext = _viewModel;
            InitializeComponent();
        }
    }
}