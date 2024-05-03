using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Shared.Behaviors;
using Product.Infrastructure.Data.Interceptors;
using Product.Infrastructure.EventBus;

namespace Product.Ioc;

public static class Ioc
{
  public static void InjectServices(this IServiceCollection services , Assembly assembly)
  {
    services.AddSingleton<InMemoryMessageQueue>();
    services.AddSingleton<IInternalEventBus, InternalEventBus>();
    services.AddSingleton<PublishDomainEventsInterceptor>();
    services.AddHostedService<InternalEventProcessor>();
    services.AddMediatR(config =>
    {
      config.RegisterServicesFromAssembly(assembly);
      config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    });
  }
}