﻿using Microsoft.Extensions.DependencyInjection;

namespace ShoppingListParserMVVM.ViewModels.Base
{
    internal static class ViewModelRegistrator
    {
        public static IServiceCollection AddViews(this IServiceCollection services) => services
           .AddSingleton<MainWindowViewModel>()
        ;
    }
}