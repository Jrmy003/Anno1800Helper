using Anno1800Helper.App.Json;
using Anno1800Helper.App.Models;

namespace Anno1800Helper.App.Factories;

public static class InputFactory
{
    public static InputModel ToModel(Input input, FactoryModel parentFactory)
    {
        if (input == null) return null;
        
        return new InputModel
        {
            ProductAmount = input.Amount,
            ChildFactory = FactoryFactory.ToModel(input.FactoryObject),
            ParentFactoryModel = parentFactory
        };
    }
}