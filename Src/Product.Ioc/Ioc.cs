using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Shared;

namespace Product.Ioc;

public static class Ioc
{
  public static void InjectServices(this IServiceCollection services , Assembly assembly)
  {
    services.AddMediatR(config =>
    {
      config.RegisterServicesFromAssembly(assembly);
      config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    });
  }
}