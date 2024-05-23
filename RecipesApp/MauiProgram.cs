﻿using Microsoft.Extensions.Logging;
using RecipeApp.Screens;

namespace RecipesApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<EventScreen>();
            builder.Services.AddSingleton<FavouritesScreen>();
            builder.Services.AddSingleton<LoginScreen>();
            builder.Services.AddSingleton<MainScreen>();
            builder.Services.AddSingleton<PurchasesScreen>();
            builder.Services.AddSingleton<RecipesScreen>();
            builder.Services.AddSingleton<RegisterScreen>();
            builder.Services.AddSingleton<RecipeDetails>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}