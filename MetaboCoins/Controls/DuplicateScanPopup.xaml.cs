using System;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace MetaboCoins
{
    public partial class DuplicateScanPopup : PopupPage
    {
        public DuplicateScanPopup()
        {
            InitializeComponent();
        }
        private void OnClose(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}
