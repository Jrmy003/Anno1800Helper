using Anno1800Helper.App.Json;
using Anno1800Helper.App.Models;

namespace Anno1800Helper.App.Factories;

public static class PopulationLevelFactory
{
    public static PopulationLevelModel ToModel(PopulationLevel populationLevel)
    {
        if (populationLevel == null)  return null;
        
        return new PopulationLevelModel
        {
            Id = populationLevel.Guid,
            Name = populationLevel.LocaText.English,
            IconData = populationLevel.Base64Icon,
            Order = populationLevel.Order,
            Need = populationLevel.Needs.ConvertAll(NeedFactory.ToModel),
            FullHouse = populationLevel.FullHouse
        };
    }
}