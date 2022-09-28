using MetaboCoins.Helpers;
using MetaboCoins.Helpers.Response;
using MetaboCoins.ViewModels.Base;
using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MetaboCoins.ViewModels.History
{
    class HistoryVM : MyBaseViewModel
    {
        private ObservableRangeCollection<ScanItemResponse> _scanStatusList { get; set; } = new ObservableRangeCollection<ScanItemResponse>();
        public ObservableRangeCollection<ScanItemResponse> ScanStatusList { get { return _scanStatusList; } set { _scanStatusList = value; OnPropertyChanged(); } }
        public int SkipRecords { get; set; }
        public ICommand LoadListCommand => new Command(LoadList);
        public ICommand RefreshCommand => new Command(Refresh);
        private async void Refresh()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            await ScanStatusList.RemoveAllAsync();
            SkipRecords = 0;
            ScanStatusList.AddRange(await GetScanStatusList());
            IsBusy = false;
        }
        private async void LoadList()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            ScanStatusList.AddRange(await GetScanStatusList());

            IsBusy = false;
        }
        public async Task Init()
        {
            ScanStatusList = await GetScanStatusList();
        }
        private async Task<ObservableRangeCollection<ScanItemResponse>> GetScanStatusList()
        {
            var helpList = new ObservableRangeCollection<ScanItemResponse>();
            var scanStatusData = await _scanServices.GetScanStatusList(ProfileHelper.UserId, SkipRecords);
            if (scanStatusData != "ERROR")
            {
                var scanStatusList = JsonConvert.DeserializeObject<ObservableRangeCollection<ScanItemResponse>>(scanStatusData);
                SkipRecords += scanStatusList.Count;
                helpList = scanStatusList;
            }
            return helpList;
        }
    }
}
