using Anno1404Helper.App.Models;
using Anno1404Helper.App.ViewModels;

namespace Anno1404Helper.App.Views;

public partial class MaterialsPage : ContentPage
{
    public MaterialsPage()
    {
        InitializeComponent();
    }

    private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedItem = e.SelectedItem as FactoryModel;
        if (selectedItem == null) return;
        var vm = BindingContext as MaterialsViewModel;
        if (vm == null) return;

        // display consumptionDetailPage
        await vm.DisplayConsumptionDetailPage(selectedItem);

        // raz selected item
        LvNeeds.SelectedItem = null;
    }
}