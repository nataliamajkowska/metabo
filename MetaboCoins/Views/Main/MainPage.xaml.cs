using MetaboCoins.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetaboCoins.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        MainVM _viewModel = new MainVM();
        public MainPage()
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