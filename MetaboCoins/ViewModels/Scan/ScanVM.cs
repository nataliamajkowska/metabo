using MetaboCoins.Helpers;
using MetaboCoins.Models;
using MetaboCoins.ViewModels.Base;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing;

namespace MetaboCoins.ViewModels.Scan
{
    public class ScanVM : MyBaseViewModel
    {
        private bool _startScan { get; set; }
        public bool StartScan { get { return _startScan; } set { _startScan = value; OnPropertyChanged(); } }
        public bool Exist { get; set; }
        public ICommand ScanCommand => new Command(Scan);
        private void Scan()
        {
            StartScan = true; // oficjalnie
        }
        public async void ScanResult(string result)
        {
            if (IsBusy)
                return;
            IsBusy = true;
            StartScan = false;
            try
            {
                if (result != null && result.Length > 9)
                {
                    var productType = result.Substring(0, 8);
                    var serialNumber = result.Substring(8);

                    var itemData = await _scanServices.AddScanResult(ProfileHelper.UserId, productType, serialNumber);
                    if (itemData != "ERROR")
                    {
                        var itemModel = JsonConvert.DeserializeObject<ItemModel>(itemData);
                        await PopupNavigation.Instance.PushAsync(new SuccessScanPopup(itemModel.Name, itemModel.Image));
                    }
                }
                else await PopupNavigation.Instance.PushAsync(new FailedScanPopup());
            }
            catch
            {
                await PopupNavigation.Instance.PushAsync(new FailedScanPopup());
            }
            IsBusy = false;
        }
    }
}
