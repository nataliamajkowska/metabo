using System;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using System.Threading.Tasks;
using MetaboCoins.Resx;
using System.Resources;

namespace MetaboCoins
{
    public partial class NotificationAlertPopup : PopupPage
    {
        ResourceManager myManager = new ResourceManager(typeof(AppResources));
        public NotificationAlertPopup(string type)
        {
            InitializeComponent();
            if(type == "login")
            {
                titleLabel.Text = GetString("StringLoginError");
                messageLabel.Text = GetString("StringLoginErrorMessage");
            }
            else if(type == "password")
            {
                titleLabel.Text = GetString("StringContact");
                messageLabel.Text = GetString("StringContactTheSupport");
            }
            else if (type == "noConnection")
            {
                titleLabel.Text = GetString("StringConnectionError");
                messageLabel.Text = GetString("StringNoConnectionToTheServer");
            }
        }
        public NotificationAlertPopup(string type, string errorMessage)
        {
            InitializeComponent();
            if (type == "error")
            {
                titleLabel.Text = GetString("StringError");
                messageLabel.Text = GetString(errorMessage);
            }
            if (type == "internalError")
            {
                titleLabel.Text = GetString("StringInternalError");
                messageLabel.Text = GetString(errorMessage);
            }
        }
        private void OnClose(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }
        public string GetString(string name)
        {
            try { return myManager.GetString(name); }
            catch { return name; }
        }
    }
}
