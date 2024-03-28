using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1800Helper.App.Models;

public class InputModel : ObservableObject
{
    private decimal _productAmount;
    private FactoryModel _childFactory;
    private FactoryModel _parentFactory;
    private decimal _neededAmount = 1;

    /// <summary>
    /// Number of factory needed (comes from Need calculation)
    /// </summary>
    public decimal NeededAmount
    {
        get => _neededAmount;
        set
        {
            if (SetProperty(ref _neededAmount, value)) OnPropertyChanged(nameof(NeededFactories));
        }
    }

    /// <summary>
    /// Number of product created.
    /// </summary>
    public decimal ProductAmount
    {
        get => _productAmount;
        set => SetProperty(ref _productAmount, value);
    }

    /// <summary>
    /// Child's factory.
    /// </summary>
    public FactoryModel ChildFactory
    {
        get => _childFactory;
        set => SetProperty(ref _childFactory, value);
    }
    
    /// <summary>
    /// Parent's factory.
    /// </summary>
    public FactoryModel ParentFactoryModel
    {
        get => _parentFactory;
        set => SetProperty(ref _parentFactory, value);
    }

    /// <summary>
    /// Gets the number of factories need in Production Chains Page.
    /// </summary>
    public decimal NeededFactories =>Math.Ceiling(_parentFactory == null
        ? NeededAmount
        : _parentFactory.ProductionPerMinute * ProductAmount * NeededAmount / (_childFactory.ProductionPerMinute * _childFactory.Outputs[0]?.Amount ?? 1));
}