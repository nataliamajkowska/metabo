using MetaboCoins.Views.History;
using MetaboCoins.Views.Main;
using MetaboCoins.Views.Profile;
using MetaboCoins.Views.Scan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetaboCoins.Views.Base.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomNavigationBar : ContentView
    {
        public BottomNavigationBar()
        {
            InitializeComponent();
        }

        private void Main_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
        private void Profil_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new ProfilePage());
        }
        private void QrcodeScan_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new ScanPage());
        }
        private void History_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new HistoryPage());
        }
        private void Cart_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}