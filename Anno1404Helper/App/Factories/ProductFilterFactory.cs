using Anno1404Helper.App.Json;
using Anno1404Helper.App.Models;

namespace Anno1404Helper.App.Factories;

public static class ProductFilterFactory
{
    public static ProductFilterModel ToModel(ProductFilter productFilter)
    {
        if (productFilter == null)  return null;
        return new ProductFilterModel
        {
            Guid = productFilter.Guid,
            Name = productFilter.LocaText.English,
            Factories = productFilter?.FactoryObjects?.ConvertAll(FactoryFactory.ToModel),
            Products = productFilter?.ProductObjects?.ConvertAll(ProductFactory.ToModel)
        };
    }
}