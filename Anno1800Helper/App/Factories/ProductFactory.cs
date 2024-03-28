using Anno1800Helper.App.Json;
using Anno1800Helper.App.Models;

namespace Anno1800Helper.App.Factories;

public static class ProductFactory
{
    public static ProductModel ToModel(Product product)
    {
        if (product == null)  return null;
        
        return new ProductModel
        {
            Id = product.Guid,
            Name = product.LocaText.English,
            IconData = product.Base64Icon
        };
    }
}