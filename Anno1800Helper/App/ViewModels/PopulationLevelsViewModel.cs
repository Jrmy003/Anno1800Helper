using System.Collections.ObjectModel;
using Anno1800Helper.App.Helpers;
using Anno1800Helper.App.Models;
using Anno1800Helper.App.Services;
using Anno1800Helper.App.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Anno1800Helper.App.ViewModels;

public partial class PopulationLevelsViewModel : ObservableObject
{
    private ObservableCollection<PopulationLevelModel> _populationLevels;

    public ObservableCollection<PopulationLevelModel> PopulationLevels
    {
        get => _populationLevels;
        set => SetProperty(ref _populationLevels, value);
    }

    private readonly Anno1800Service _anno1800Service = ServiceHelper.GetService<Anno1800Service>();

    public PopulationLevelsViewModel()
    {
        Initialize();
    }

    /// <summary>
    /// Initialize data to display.
    /// </summary>
    private async void Initialize()
    {
        // load json and convert everything to models
        await _anno1800Service.LoadJsonAsync();
        // gets population levels models to display
        PopulationLevels = new ObservableCollection<PopulationLevelModel>(_anno1800Service
            .PopulationLevelModels.OrderBy(x=>x.Order));
    }

    [RelayCommand]
    private async Task DisplayConsumptionPage()
    {
        // instantiates view and associate it to its viewmodel
        var page = new ConsumptionPage();
        var consumptionViewModel = ServiceHelper.GetService<ConsumptionViewModel>();
        if (consumptionViewModel == null)
            return;
        consumptionViewModel.PopulationLevels = PopulationLevels;
        page.BindingContext = consumptionViewModel;
        
        //displays the view 
        await Shell.Current.Navigation.PushAsync(page, true);
    }
    
    [RelayCommand]
    private async Task DisplayMaterialsPage()
    {
        // instantiates view and associate it to its viewmodel
        var page = new MaterialsPage();
        var consumptionViewModel = ServiceHelper.GetService<MaterialsViewModel>();
        if (consumptionViewModel == null)
            return;
        page.BindingContext = consumptionViewModel;
        
        //displays the view 
        await Shell.Current.Navigation.PushAsync(page, true);
    }
}