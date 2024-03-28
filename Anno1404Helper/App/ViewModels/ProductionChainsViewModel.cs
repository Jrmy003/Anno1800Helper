using System.Collections.ObjectModel;
using Anno1404Helper.App.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1404Helper.App.ViewModels;

public class ProductionChainsViewModel : ObservableObject
{
    private InputModel _inputModel;
    private ObservableCollection<InputModel> _productionChains;
    private ObservableCollection<InputModel> _templates;

    public InputModel InputModel
    {
        get => _inputModel;
        set
        {
            if (SetProperty(ref _inputModel, value))
            {
                Task.Factory.StartNew(UpdateProductionChains, TaskCreationOptions.LongRunning);
            }
        }
    }

    public ObservableCollection<InputModel> ProductionChains
    {
        get => _productionChains;
        set => SetProperty(ref _productionChains, value);
    }

    public ObservableCollection<InputModel> Templates
    {
        get => _templates;
        set => SetProperty(ref _templates, value);
    }

    private void UpdateProductionChains()
    {
        if(_inputModel == null) return;
        
        ProductionChains = new ObservableCollection<InputModel>();
        Templates = new ObservableCollection<InputModel>();
        
        Dfs(_inputModel);
    }
    
    /// <summary>
    /// Deep first search.
    /// </summary>
    /// <param name="start">start of graph</param>
    private void Dfs(InputModel start)
    {
        var visited = new HashSet<int>();
        var stack = new Stack<InputModel>();
        stack.Push(start);

        while (stack.Count > 0)
        {
            InputModel current = stack.Pop();
            if (!visited.Contains(current.ChildFactory.Id))
            {
                ProductionChains.Add(current);
                if(!string.IsNullOrEmpty(current?.ChildFactory?.TemplateData))
                    Templates.Add(current);
                
                if(current.ChildFactory == null) continue;
                visited.Add(current.ChildFactory.Id); 
                if(current.ChildFactory.Inputs == null) continue;
                foreach (var neighbor in current.ChildFactory.Inputs)
                {
                    if (!visited.Contains(neighbor.ChildFactory.Id))
                    {
                        // updates the amount of parent factory needed.
                        neighbor.NeededAmount = current.NeededAmount;
                        stack.Push(neighbor);
                    }
                }
            }
        }
    }
}