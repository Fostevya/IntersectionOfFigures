using Microsoft.Extensions.DependencyInjection;

namespace IntersectionOfFigures.Services
{
    public static class ServicesDependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IDialogService, DialogService>();
            services.AddTransient<ILineCoordinatesProvider, ExcelLineCoordinatesProvider>();
        }
    }
}
