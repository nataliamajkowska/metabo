using MetaboCoins.Helpers;
using MetaboCoins.Helpers.Response;
using MetaboCoins.ViewModels.Base;
using MetaboCoins.Views.Contact;
using MetaboCoins.Views.History;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MetaboCoins.ViewModels.Profile
{
    class ProfileVM : MyBaseViewModel
    {
        public string UserName { get; set; } = ProfileHelper.UserName;
        public int PhoneNumber { get; set; } = ProfileHelper.PhoneNumber;
        public string Email { get; set; } = ProfileHelper.Email;
        public string StoreName { get; set; } = ProfileHelper.StoreName;
        private int _turnoverThreshold { get; set; }
        public int TurnoverThreshold { get { return _turnoverThreshold; } set { _turnoverThreshold = value; OnPropertyChanged(); } }
        private int _turnover { get; set; }
        public int Turnover { get { return _turnover; } set { _turnover = value; OnPropertyChanged(); } }
        private int _metaboCoins { get; set; }
        public int MetaboCoins { get { return _metaboCoins; } set { _metaboCoins = value; OnPropertyChanged(); } }
        private int _metaboCoinsForSettlement { get; set; }
        public int MetaboCoinsForSettlement { get { return _metaboCoinsForSettlement; } set { _metaboCoinsForSettlement = value; OnPropertyChanged(); } }
        private int _metaboCoinsCleared { get; set; }
        public int MetaboCoinsCleared { get { return _metaboCoinsCleared; } set { _metaboCoinsCleared = value; OnPropertyChanged(); } }
        private bool _turnoverIsDone { get; set; }
        public bool TurnoverIsDone { get { return _turnoverIsDone; } set { _turnoverIsDone = value; OnPropertyChanged(); } }
        public ICommand GoHistoryCommand => new Command(GoHistory);
        public async Task Init()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            var userData = await _userServices.GetMetaboCoinsInformation(ProfileHelper.UserId);
            if (userData != "ERROR")
            {
                var informationModel = JsonConvert.DeserializeObject<MetaboCoinsInformationResponse>(userData);
                TurnoverThreshold = informationModel.TurnoverThreshold;
                Turnover = informationModel.Turnover;
                if (Turnover >= TurnoverThreshold) TurnoverIsDone = true;
                MetaboCoins = informationModel.MetaboCoins;
                MetaboCoinsForSettlement = informationModel.MetaboCoinsForSettlement;
                MetaboCoinsCleared = informationModel.MetaboCoinsCleared;
            }
            IsBusy = false;
        }
        private async void GoHistory()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new HistoryPage());
        }
    }
}
