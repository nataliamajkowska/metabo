using MetaboCoins.Helpers;
using MetaboCoins.ViewModels.Base;
using Newtonsoft.Json;
using System.Threading.Tasks;
using MetaboCoins.Helpers.Response;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using MetaboCoins.Views.Main;
using MetaboCoins.Views.Contact;

namespace MetaboCoins.ViewModels.Main
{
    class MainVM : MyBaseViewModel
    {
        public string UserName {get; set; } = ProfileHelper.UserName;
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
        public ICommand GoContactCommand => new Command(GoContact);
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
        private async void GoContact()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ContactPage());
        }
    }
}
