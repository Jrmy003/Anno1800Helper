using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1800Helper.App.Models;

public class PopulationLevelModel : ObservableObject
{
    private int _id;
    private string _name;
    private decimal? _amount;
    private string _iconData;
    private List<NeedModel> _need;
    private decimal _fullHouse;
    private int _order;

    /// <summary>
    /// The id.
    /// </summary>
    public int Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }
    
    /// <summary>
    /// The name.
    /// </summary>
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    /// <summary>
    /// The amount.
    /// </summary>
    public decimal? Amount
    {
        get => _amount;
        set => SetProperty(ref _amount, value);
    }

    /// <summary>
    /// the needs
    /// </summary>
    public List<NeedModel> Need
    {
        get => _need;
        set => SetProperty(ref _need, value);
    }
    
    /// <summary>
    /// The icon base 64 data.
    /// </summary>
    public string IconData
    {
        get => _iconData;
        set
        {
            if (SetProperty(ref _iconData, value)) OnPropertyChanged(nameof(Icon));
        }
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

    /// <summary>
    /// Number of people max per house.
    /// </summary>
    public decimal FullHouse
    {
        get => _fullHouse;
        set => SetProperty(ref _fullHouse, value);
    }

    /// <summary>
    /// The order in PopulationLevels Page.
    /// </summary>
    public int Order
    {
        get => _order;
        set => SetProperty(ref _order, value);
    }

    /// <summary>
    /// The keyboard return type in PopulationLevelsPage.
    /// </summary>
    public ReturnType ReturnType => _id == 51909 ? ReturnType.Done : ReturnType.Next;
}