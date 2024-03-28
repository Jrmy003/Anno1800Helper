using Anno1800Helper.App.Helpers;
using Anno1800Helper.App.ViewModels;

namespace Anno1800Helper.App.Views;

public partial class ProductionChainsPage : ContentPage
{
    public ProductionChainsPage()
    {
        InitializeComponent();
        BindingContext = ServiceHelper.GetService<ProductionChainsViewModel>();
    }
}