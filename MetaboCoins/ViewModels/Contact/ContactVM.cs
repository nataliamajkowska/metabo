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

namespace MetaboCoins.ViewModels.Contact
{
    class ContactVM : MyBaseViewModel
    {
        public string ContactName { get; set; } = BaseInfoHelper.ContactName;
        public int ContactPhone { get; set; } = BaseInfoHelper.ContactPhone;
        public string ContactEmail { get; set; } = BaseInfoHelper.ContactEmail;
    }
}
