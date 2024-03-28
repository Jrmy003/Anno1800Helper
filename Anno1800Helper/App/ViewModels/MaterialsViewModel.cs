using System.Collections.ObjectModel;
using Anno1800Helper.App.Helpers;
using Anno1800Helper.App.Models;
using Anno1800Helper.App.Services;
using Anno1800Helper.App.Views;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1800Helper.App.ViewModels;

public class MaterialsViewModel : ObservableObject
{
    private ObservableCollection<FactoryModel> _factories;

    public ObservableCollection<FactoryModel> Factories
    {
        get => _factories;
        set => SetProperty(ref _factories, value);
    }
    
    private readonly Anno1800Service _anno1800Service = ServiceHelper.GetService<Anno1800Service>();

    public MaterialsViewModel()
    {
        Initialize();
    }

    private async void Initialize()
    {
        _factories = new(_anno1800Service.GetMaterials().Factories);
    }
    
    public async Task DisplayConsumptionDetailPage(FactoryModel factory)
    {
        if (factory == null) return;
        // instantiates view and associate it to its viewmodel
        // TODO : Have to define in which order these instructions have to be called to optimize loading of next screen
        var page = new ProductionChainsPage();
        var consumptionViewModel = ServiceHelper.GetService<ProductionChainsViewModel>();
        if (consumptionViewModel == null)
            return;
        consumptionViewModel.InputModel = new InputModel
        {
            ChildFactory = factory,
        };
        page.BindingContext = consumptionViewModel;
        
        //displays the view 
        await Shell.Current.Navigation.PushAsync(page, true);
    }
}