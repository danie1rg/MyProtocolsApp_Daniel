using MyProtocolsApp_Daniel.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MyProtocolsApp_Daniel.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}