using MetaboCoins.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaboCoins.ViewModels.Base
{
    public class MyBaseViewModel : BaseViewModel
    {
        public UserServices _userServices = new UserServices();
        public ScanServices _scanServices = new ScanServices();
    }
}
