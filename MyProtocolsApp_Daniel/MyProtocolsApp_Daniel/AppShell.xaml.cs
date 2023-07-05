using MyProtocolsApp_Daniel.ViewModels;
using MyProtocolsApp_Daniel.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MyProtocolsApp_Daniel
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
