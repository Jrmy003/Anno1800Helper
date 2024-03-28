using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1800Helper.App.Models;

public class NeedModel : ObservableObject
{
    private ProductModel _product;
    private decimal _consumptionPerMinute;
    private FactoryModel _factory;

    /// <summary>
    /// The product needed.
    /// </summary>
    public ProductModel Product
    {
        get => _product;
        set => SetProperty(ref _product, value);
    }

    /// <summary>
    /// The consumption per minutes of the needed product.
    /// </summary>
    public decimal ConsumptionPerMinute
    {
        get => _consumptionPerMinute;
        set => SetProperty(ref _consumptionPerMinute, value);
    }

    /// <summary>
    /// The factory which creates the product.
    /// </summary>
    public FactoryModel Factory
    {
        get => _factory;
        set => SetProperty(ref _factory, value);
    }

    /// <summary>
    /// How factory's production fulfill to need in percent.
    /// </summary>
    public decimal FactoryPercentUsage => FactoryDecimalUsage * 100;
    
    /// <summary>
    /// How factory's production fulfill to need in decimal value.
    /// </summary>
    public decimal FactoryDecimalUsage => ConsumptionPerMinute == 0
        ? 0
        : (Factory.ProductionPerMinute - ((NbFactoriesNeeded * Factory.ProductionPerMinute) - ConsumptionPerMinute))
          / Factory.ProductionPerMinute;
    
    /// <summary>
    /// Integer number of factory needed. 
    /// </summary>
    public decimal NbFactoriesNeeded => Math.Ceiling(ConsumptionPerMinute / Factory?.ProductionPerMinute ?? 1);
}