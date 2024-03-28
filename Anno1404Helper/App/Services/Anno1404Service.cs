using Anno1404Helper.App.Factories;
using Anno1404Helper.App.Json;
using Anno1404Helper.App.Models;
using Newtonsoft.Json;

namespace Anno1404Helper.App.Services;

public class Anno1404Service
{
    private const int ConsumerGoodsProductFilterId = 502031; 
    private const int MaterialsProductFilterId = 501957; 
    public List<PopulationLevelModel> PopulationLevelModels { get; set; }
    private List<ProductFilterModel> ProductFilters { get; set; }
    private Anno1404Data Anno1404Data { get; set; }

    /// <summary>
    /// Loads json and convert json structure to internal models structure
    /// </summary>
    /// <returns></returns>
    public async Task LoadJsonAsync()
    {
        await using var stream = await FileSystem.OpenAppPackageFileAsync("params.json");
        using var reader = new StreamReader(stream);

        Anno1404Data = JsonConvert.DeserializeObject<Anno1404Data>(await reader.ReadToEndAsync());

        //loads products icons
        foreach (var product in Anno1404Data.Products)
        {
            product.Base64Icon = GetBase64Icon(product.IconPath);
        }

        // loads factories icons, and associate products to inputs and outputs
        foreach (var factory in Anno1404Data.Factories)
        {
            factory.Base64Icon = GetBase64Icon(factory.IconPath);
            factory.Base64Template = GetBase64Icon(factory.TemplatePath);
            if (factory.Inputs != null)
                foreach (var input in factory.Inputs)
                {
                    input.ProductObject = Anno1404Data.Products.FirstOrDefault(x => x.Guid == input.Product);
                    input.FactoryObject =
                        Anno1404Data.Factories.FirstOrDefault(x => x.Outputs[0]?.Product == input.Product);
                }

            foreach (var output in factory.Outputs)
            {
                output.ProductObject = Anno1404Data.Products.FirstOrDefault(x => x.Guid == output.Product);
            }
        }

        // loads icons to population levels, and associate factory to need through product id
        foreach (var populationLevel in Anno1404Data.PopulationLevels)
        {
            populationLevel.Base64Icon = GetBase64Icon(populationLevel.IconPath);
            foreach (var need in populationLevel.Needs)
            {
                need.ProductObject = Anno1404Data.Products.FirstOrDefault(x => x.Guid == need.Guid);
                foreach (var factory in Anno1404Data.Factories)
                {
                    if (factory.Outputs != null && factory.Outputs.Count == 1 &&
                        factory.Outputs[0].Product == need.ProductObject?.Guid)
                    {
                        need.Factory = factory;
                        break;
                    }
                }
            }
        }

        // chargement des products filters
        foreach (var productFilter in Anno1404Data.ProductFilter)
        {
            foreach (var productId in productFilter.Products)
            {
                var product = Anno1404Data.Products.FirstOrDefault(x => x.Guid == productId);
                if (product == null) continue;
                if (product.Producers?.Count != 1) continue;
                productFilter.ProductObjects.Add(product);
                var factory = Anno1404Data.Factories.FirstOrDefault(x => x.Guid == product.Producers[0]);
                if (factory == null) continue;
                productFilter.FactoryObjects.Add(factory);
            }
        }

        // saves data in service while app dont not have database
        PopulationLevelModels = Anno1404Data.PopulationLevels.ConvertAll(PopulationLevelFactory.ToModel);
        ProductFilters = Anno1404Data.ProductFilter.ConvertAll(ProductFilterFactory.ToModel);
    }

    /// <summary>
    /// Gets materials.
    /// </summary>
    /// <returns></returns>
    public ProductFilterModel GetMaterials()
    {
        return ProductFilters.FirstOrDefault(x => x.Guid == MaterialsProductFilterId);
    }
    
    /// <summary>
    /// Gets consumer goods.
    /// </summary>
    /// <returns></returns>
    public ProductFilterModel GetConsumerGoods()
    {
        return ProductFilters.FirstOrDefault(x => x.Guid == ConsumerGoodsProductFilterId);
    }

    /// <summary>
    /// Gets the base 64 icon data from icon path.
    /// </summary>
    /// <param name="iconPath">the icon's path</param>
    /// <returns></returns>
    private string GetBase64Icon(string iconPath)
    {
        if (iconPath == null) return null;
        return Anno1404Data.Icons.TryGetValue(iconPath, out var icon)
            ? icon.Substring(23)
            : null;
    }
}