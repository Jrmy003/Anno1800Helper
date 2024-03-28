using Anno1800Helper.App.Json;
using Anno1800Helper.App.Models;

namespace Anno1800Helper.App.Factories;

public static class OutputFactory
{
    public static OutputModel ToModel(Output input)
    {
        if (input == null)  return null;
        
        return new OutputModel
        {
            Amount = input.Amount,
            Product = ProductFactory.ToModel(input.ProductObject)
        };
    }
}