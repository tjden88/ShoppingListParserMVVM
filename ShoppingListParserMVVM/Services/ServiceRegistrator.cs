using Microsoft.Extensions.DependencyInjection;
using ShoppingListParserMVVM.Services.Interfaces;

namespace ShoppingListParserMVVM.Services
{
    static class ServiceRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
           .AddTransient<IDataService, DataService>()
           .AddTransient<IUserDialog, UserDialog>()
        ;
    }
}
