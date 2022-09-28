using MetaboCoins.ViewModels.Scan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace MetaboCoins.Views.Scan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanPage : ContentPage
    {
        ScanVM _viewModel;
        public ScanPage()
        {
            _viewModel = new ScanVM();
            BindingContext = _viewModel;
            InitializeComponent();
        }

        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if(_viewModel.StartScan)
                {
                    _viewModel.ScanResult(result.Text);
                }
            });
        }
    }
}