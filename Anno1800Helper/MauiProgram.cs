using Anno1800Helper.App.Helpers;
using Anno1800Helper.App.Services;
using Anno1800Helper.App.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace Anno1800Helper;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App.App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .RegisterViewModels()
            .RegisterServices();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();
        ServiceHelper.Initialize(app.Services);
        // force initialization of first screen viewmodel at very startup
        ServiceHelper.GetService<PopulationLevelsViewModel>();
        return app;
    }
    
    private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<PopulationLevelsViewModel>();
        mauiAppBuilder.Services.AddSingleton<ConsumptionViewModel>();
        mauiAppBuilder.Services.AddSingleton<ProductionChainsViewModel>();
        mauiAppBuilder.Services.AddSingleton<MaterialsViewModel>();
        return mauiAppBuilder;
    }
    
    private static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<Anno1800Service>();
        return mauiAppBuilder;
    }
    
    //
    // private static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    // {
    //     mauiAppBuilder.Services.AddSingleton<PopulationLevelsPage>();
    //     return mauiAppBuilder;
    // }
}