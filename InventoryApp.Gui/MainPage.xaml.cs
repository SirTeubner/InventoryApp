using InventoryApp.Core.ViewModels;

namespace InventoryApp.Gui;

public partial class MainPage : ContentPage
{

    public MainPage(DashboardViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}
