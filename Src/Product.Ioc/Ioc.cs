using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Shared;
using Product.Application.Shared.Behaviors;
using Product.Infrastructure.EventBus;
using Product.Infrastructure.Interceptor;

namespace Product.Ioc;

public static class Ioc
{
  public static void InjectServices(this IServiceCollection services , Assembly assembly)
  {
    services.AddSingleton<InMemoryMessageQueue>();
    services.AddSingleton<IEventBus, EventBus>();
    services.AddSingleton<PublishDomainEventsInterceptor>();
    services.AddHostedService<IntegrationEventProcessor>();
    services.AddMediatR(config =>
    {
      config.RegisterServicesFromAssembly(assembly);
      config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    });
  }
}