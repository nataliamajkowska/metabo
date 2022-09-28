using MetaboCoins.ViewModels.Contact;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetaboCoins.Views.Contact
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        ContactVM _viewModel = new ContactVM();
        public ContactPage()
        {
            BindingContext = _viewModel;
            InitializeComponent();
        }
    }
}