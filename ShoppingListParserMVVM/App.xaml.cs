using Microsoft.Extensions.Hosting;
using ShoppingListParserMVVM.Services;
using ShoppingListParserMVVM.ViewModels.Base;
using System;
using System.Linq;
using System.Windows;

namespace ShoppingListParserMVVM
{
    public partial class App
    {
        /// <summary> Активное окно приложения </summary>
        public static Window ActiveWindow => Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsActive);

        /// <summary> Проектирование в режиме дизайнера Visual Studio </summary>
        public static bool IsDesignTime { get; private set; } = true;

        private static IHost __Host;

        public static IHost Host => __Host ??= Microsoft.Extensions.Hosting.Host
           .CreateDefaultBuilder(Environment.GetCommandLineArgs())
           .ConfigureServices((host, services) => services
               .AddViews()
               .AddServices()
                )
           .Build();

        public static IServiceProvider Services => Host.Services;

        protected override async void OnStartup(StartupEventArgs e)
        {
            IsDesignTime = false;
            var host = Host;
            base.OnStartup(e);
            await host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            using var host = Host;
            await host.StopAsync();
        }
    }
}
