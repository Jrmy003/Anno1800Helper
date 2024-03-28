namespace Anno1800Helper.App.Models;

public class ProductFilterModel
{
    public int Guid { get; set; }
    public string Name { get; set; }
    public List<FactoryModel> Factories { get; set; }
    public List<ProductModel> Products { get; set; }
}