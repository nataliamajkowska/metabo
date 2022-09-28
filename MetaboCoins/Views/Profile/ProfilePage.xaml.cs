using MetaboCoins.ViewModels.Main;
using MetaboCoins.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetaboCoins.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        ProfileVM _viewModel = new ProfileVM();
        public ProfilePage()
        {
            Init();
            InitializeComponent();
        }
        async void Init()
        {
            await _viewModel.Init();
            BindingContext = _viewModel;
        }
    }
}