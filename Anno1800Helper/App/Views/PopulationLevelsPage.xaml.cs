using Anno1800Helper.App.Helpers;
using Anno1800Helper.App.ViewModels;

namespace Anno1800Helper.App.Views;

public partial class PopulationLevelsPage : ContentPage
{
    public PopulationLevelsPage()
    {
        BindingContext = ServiceHelper.GetService<PopulationLevelsViewModel>();
        InitializeComponent();
    }

    private void VisualElement_OnFocused(object sender, FocusEventArgs e)
    {
        // empties the cell after focus
        var entry = sender as Entry;
        if (entry == null) return;
        entry.Text = string.Empty;
        
        // when entry cleared keyboard doesn't appear
        // force display of keyboard
        KeyboardHelper.ForceDisplayKeyboard(entry);
    }
}