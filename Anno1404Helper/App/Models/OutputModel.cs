using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1404Helper.App.Models;

public class  OutputModel : ObservableObject
{
    private decimal _amount;
    private ProductModel _product;

    /// <summary>
    /// The amount produced.
    /// </summary>
    public decimal Amount
    {
        get => _amount;
        set => SetProperty(ref _amount, value);
    }

    /// <summary>
    /// The produced product.
    /// </summary>
    public ProductModel Product
    {
        get => _product;
        set => SetProperty(ref _product, value);
    }
}