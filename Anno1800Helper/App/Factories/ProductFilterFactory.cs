using Anno1800Helper.App.Json;
using Anno1800Helper.App.Models;

namespace Anno1800Helper.App.Factories;

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