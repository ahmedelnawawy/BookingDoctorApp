using Microsoft.Extensions.DependencyInjection;

namespace Availability.Application.Contract
{
    public interface IStartUp
    {
        void ConfigureServices(IServiceCollection services);
    }
}
