using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anno1404Helper.App.Helpers;
using Anno1404Helper.App.ViewModels;

namespace Anno1404Helper.App.Views;

public partial class ProductionChainsPage : ContentPage
{
    public ProductionChainsPage()
    {
        InitializeComponent();
        BindingContext = ServiceHelper.GetService<ProductionChainsViewModel>();
    }
}