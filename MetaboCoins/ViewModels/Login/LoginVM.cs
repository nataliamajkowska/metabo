using MetaboCoins.Helpers;
using MetaboCoins.Services;
using MetaboCoins.ViewModels.Base;
using MetaboCoins.Views.Main;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MetaboCoins.Helpers.Response;

namespace MetaboCoins.ViewModels.Login
{
    class LoginVM : MyBaseViewModel
    {
        public AuthenticateServices _authenticateServices = new AuthenticateServices();
        public string ContactName { get; set; } = BaseInfoHelper.ContactName;
        public int ContactPhone { get; set; } = BaseInfoHelper.ContactPhone;
        public string ContactEmail { get; set; } = BaseInfoHelper.ContactEmail;
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public ICommand SignInCommand => new Command(SignIn);
        public ICommand RemindPasswordCommand => new Command(RemindPassword);
        async void SignIn()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            var userData = await _authenticateServices.Login(Login, Password);
            if (userData != "ERROR")
            {
                var userModel = JsonConvert.DeserializeObject<UserResponse>(userData);
                ProfileHelper.Token = userModel.Token;
                ProfileHelper.UserId = userModel.UserId;
                ProfileHelper.UserName = userModel.Name;
                ProfileHelper.StoreName = userModel.StoreName;
                ProfileHelper.Email = userModel.Email;
                ProfileHelper.PhoneNumber = userModel.PhoneNumber;
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }
            IsBusy = false;
        }
        async void RemindPassword()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            await PopupNavigation.Instance.PushAsync(new NotificationAlertPopup("password"));
            IsBusy = false;
        }
    }
}
