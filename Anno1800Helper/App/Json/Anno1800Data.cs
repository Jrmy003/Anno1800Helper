// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

namespace Anno1800Helper.App.Json;

public class Factory
{
    public int Guid { get; set; }
    public string IconPath { get; set; }
    public string TemplatePath { get; set; }
    public List<Input> Inputs { get; set; }
    public LocaText LocaText { get; set; }
    public string Name { get; set; }
    public List<Output> Outputs { get; set; }
    public decimal Tpmin { get; set; }
    public string Base64Icon { get; set; }
    public string Base64Template { get; set; }
}

public class GoodsProduction
{
    public int Good { get; set; }
    public decimal ProductionPerMinute { get; set; }
}

public class Input
{
    public decimal Amount { get; set; }
    public int Product { get; set; }
    public Product ProductObject { get; set; }
    public Factory FactoryObject { get; set; }
}

public class LocaText
{
    public string Czech { get; set; }
    public string English { get; set; }
    public string French { get; set; }
    public string German { get; set; }
    public string Italian { get; set; }
    public string Polish { get; set; }
    public string Russian { get; set; }
    public string Spanish { get; set; }
    public string Brazilian { get; set; }
    public string Chinese { get; set; }
    public string Japanese { get; set; }
    public string Korean { get; set; }
    public string Portuguese { get; set; }
    public string Taiwanese { get; set; }
}

public class Need
{
    public int Guid { get; set; }
    public decimal? Tpmin { get; set; }
    public UnlockCondition UnlockCondition { get; set; }
    public Product ProductObject { get; set; }
    public Factory Factory { get; set; }
}

public class Output
{
    public int Amount { get; set; }
    public int Product { get; set; }
    public Product ProductObject { get; set; }
}

public class PopulationLevel
{
    public int FullHouse { get; set; }
    public int Guid { get; set; }
    public string IconPath { get; set; }
    public int Order { get; set; }
    public LocaText LocaText { get; set; }
    public string Name { get; set; }
    public List<Need> Needs { get; set; }
    public int Residence { get; set; }
    public int? ResidenceUpgradeAmountMaxPercent { get; set; }
    public string Base64Icon { get; set; }
}
public class PopulationGroup
{
    public int Guid { get; set; }
    public LocaText LocaText { get; set; }
    public string Name { get; set; }
    public List<int> PopulationLevels { get; set; }
}

public class Product
{
    public int Guid { get; set; }
    public string IconPath { get; set; }
    public LocaText LocaText { get; set; }
    public string Name { get; set; }
    public List<int> Producers { get; set; }
    public string Base64Icon { get; set; }
}

public class ProductFilter
{
    public int Guid { get; set; }
    public string Icon { get; set; }
    public LocaText LocaText { get; set; }
    public string Name { get; set; }
    public List<int> Products { get; set; }
    public List<Product> ProductObjects { get; set; } = new ();
    public List<Factory> FactoryObjects { get; set; } = new ();
}

public class ResidenceBuilding
{
    public int Guid { get; set; }
    public string IconPath { get; set; }
    public LocaText LocaText { get; set; }
    public int MaxResidentCount { get; set; }
    public string Name { get; set; }
}

public class Anno1800Data
{
    public List<Factory> Factories { get; set; }
    public Dictionary<string, string> Icons { get; set; }
    public List<object> Items { get; set; }
    public List<string> Languages { get; set; }
    public List<PopulationGroup> PopulationGroups { get; set; }
    public List<PopulationLevel> PopulationLevels { get; set; }
    public List<ProductFilter> ProductFilter { get; set; }
    public List<Product> Products { get; set; }
    public List<ResidenceBuilding> ResidenceBuildings { get; set; }
    public List<Trader> Traders { get; set; }
    public List<object> Workforce { get; set; }
}

public class Trader
{
    public List<GoodsProduction> GoodsProduction { get; set; }
    public int Guid { get; set; }
    public string IconPath { get; set; }
    public string Name { get; set; }
}

public class UnlockCondition
{
    public int Amount { get; set; }
    public int PopulationLevel { get; set; }
}
