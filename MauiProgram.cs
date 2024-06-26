﻿using HabitGuiderMobileSol.Data;
using HabitGuiderMobileSol.ViewModels;
using HabitGuiderMobileSol.Views;
using Microcharts.Maui;
using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace HabitGuiderMobileSol
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureMopups()
                .UseMicrocharts()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<DatabaseContext>();

            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<HabitsListViewModel>();
            builder.Services.AddSingleton<NewHabitViewModel>();

            builder.Services.AddTransient<HomeView>();
            builder.Services.AddTransient<HabitsListView>();
            builder.Services.AddTransient<NewHabitView>();

            return builder.Build();
        }
    }
}
