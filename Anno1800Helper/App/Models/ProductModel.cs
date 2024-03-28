using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1800Helper.App.Models;

public class ProductModel : ObservableObject
{
    private int _id;
    private string _iconData;
    private string _name;

    /// <summary>
    /// Id
    /// </summary>
    public int Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }

    /// <summary>
    /// Icon data in base 64.
    /// </summary>
    public string IconData
    {
        get => _iconData;
        set => SetProperty(ref _iconData, value);
    }

    /// <summary>
    /// Name of product.
    /// </summary>
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }
    
    /// <summary>
    /// The icon.
    /// </summary>
    public ImageSource Icon
    {
        get
        {
            var imageBytes = Convert.FromBase64String(IconData);
            MemoryStream imageDecodeStream = new(imageBytes);
            return ImageSource.FromStream(() => imageDecodeStream);
        }
    }
}