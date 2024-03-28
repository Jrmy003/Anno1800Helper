using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1404Helper.App.Models;

public class FactoryModel : ObservableObject
{
    private int _id;
    private string _iconData;
    private string _templateData;
    private List<InputModel> _inputs;
    private string _name;
    private List<OutputModel> _outputs;
    private decimal _productionPerMinute;

    /// <summary>
    /// The Id
    /// </summary>
    public int Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }

    /// <summary>
    /// The inputs factories that are needed to this factory to produce.
    /// </summary>
    public List<InputModel> Inputs
    {
        get => _inputs;
        set
        {
            if (SetProperty(ref _inputs, value))
                OnPropertyChanged(nameof(HasInputs));
        }
    }

    /// <summary>
    /// The factory name.
    /// </summary>
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    /// <summary>
    /// The output of this factory.
    /// </summary>
    public List<OutputModel> Outputs
    {
        get => _outputs;
        set => SetProperty(ref _outputs, value);
    }

    /// <summary>
    /// The production per minute.
    /// </summary>
    public decimal ProductionPerMinute
    {
        get => _productionPerMinute;
        set => SetProperty(ref _productionPerMinute, value);
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
    /// The optimized in game template (for farms only).
    /// </summary>
    public string TemplateData
    {
        get => _templateData;
        set
        {
            if (SetProperty(ref _templateData, value)) OnPropertyChanged(nameof(Template));
        }
    }

    /// <summary>
    /// The icon produce from IconData.
    /// </summary>
    public ImageSource Icon
    {
        get
        {
            if (_iconData == null) return null;
            var imageBytes = Convert.FromBase64String(_iconData);
            MemoryStream imageDecodeStream = new(imageBytes);
            return ImageSource.FromStream(() => imageDecodeStream);
        }
    }
    
    /// <summary>
    /// The template (farms only).
    /// </summary>
    public ImageSource Template
    {
        get
        {
            if (_templateData == null) return null;
            var imageBytes = Convert.FromBase64String(_templateData);
            MemoryStream imageDecodeStream = new(imageBytes);
            return ImageSource.FromStream(() => imageDecodeStream);
        }
    }

    /// <summary>
    /// Indicates if this factory need inputs to produce products.
    /// </summary>
    public bool HasInputs => (_inputs?.Count ?? 0) > 0;

    public override bool Equals(object obj)
    {
        var factory = obj as FactoryModel;
        if (factory == null)
            return false;
        return Equals(factory);
    }

    protected bool Equals(FactoryModel other)
    {
        return _id == other._id;
    }

    public override int GetHashCode()
    {
        return _id;
    }
}