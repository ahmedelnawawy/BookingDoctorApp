using Microsoft.Extensions.DependencyInjection;
using SharedKernel.EventBus.Infrastructure;

namespace SharedKernel.Contract
{
    public interface IStartUp
    {
        void ConfigureServices(IServiceCollection services, InMemoryEventBus eventBus);
    }
}
