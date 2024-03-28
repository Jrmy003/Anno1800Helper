using System.Collections.ObjectModel;
using Anno1404Helper.App.Helpers;
using Anno1404Helper.App.Models;
using Anno1404Helper.App.Views;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1404Helper.App.ViewModels;

public class ConsumptionViewModel : ObservableObject
{
    private ObservableCollection<NeedModel> _needs;
    private ObservableCollection<PopulationLevelModel> _populationLevels;
    
    public ObservableCollection<NeedModel> Needs
    {
        get => _needs;
        set => SetProperty(ref _needs, value);
    }
    
    public ObservableCollection<PopulationLevelModel> PopulationLevels
    {
        get => _populationLevels;
        set
        {
            SetProperty(ref _populationLevels, value);
            Task.Factory.StartNew(ComputeNeeds, TaskCreationOptions.LongRunning);
        }
    }
    
    private void ComputeNeeds()
    {
        if(_populationLevels == null) return;
        // cumulates needs of every population level in a flat list using dictionary
        var dico = new Dictionary<int, NeedModel>();
        foreach (var populationLevelModel in _populationLevels.OrderBy(x=>x.Id))
        {
            foreach (var need in populationLevelModel.Need)
            {
                if (dico.TryGetValue(need.Product.Id, out var value))
                {
                    value.ConsumptionPerMinute += (populationLevelModel.Amount ??
                                                   0 / populationLevelModel.FullHouse) * need.ConsumptionPerMinute;
                }
                else
                {
                    var newNeed = new NeedModel
                    {
                        Product = need.Product,
                        ConsumptionPerMinute = (populationLevelModel.Amount ?? 0 / populationLevelModel.FullHouse) * need.ConsumptionPerMinute,
                        Factory = need.Factory
                    };
                    dico.Add(need.Product.Id, newNeed);
                }
            }
        }
        Needs = new(dico.Values);
    }
    
    public async Task DisplayConsumptionDetailPage(NeedModel need)
    {
        if (need == null) return;
        // instantiates view and associate it to its viewmodel
        // TODO : Have to define in which order these instructions have to be called to optimize loading of next screen
        var page = new ProductionChainsPage();
        var consumptionViewModel = ServiceHelper.GetService<ProductionChainsViewModel>();
        if (consumptionViewModel == null)
            return;
        consumptionViewModel.InputModel = new InputModel
        {
            ChildFactory = need.Factory,
            NeededAmount = need.NbFactoriesNeeded == 0 ? 1 : need.NbFactoriesNeeded
        };
        page.BindingContext = consumptionViewModel;
        
        //displays the view 
        await Shell.Current.Navigation.PushAsync(page, true);
    }
}