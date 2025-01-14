using Microsoft.Extensions.DependencyInjection;

namespace SharedKernel.Contract
{
    public interface IStartUp
    {
        void ConfigureServices(IServiceCollection services);
    }
}
