using Microsoft.Extensions.DependencyInjection;

namespace SharedKernel
{
    public interface IStartUp
    {
        void ConfigureServices(IServiceCollection services);
    }
}
