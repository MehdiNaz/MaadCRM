using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
// using FluentValidation;

namespace Application;

public static class RegisterService
{
    public static void ConfigureApplication(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        // var assembly = typeof(DependencyInjection).Assembly;
        // services.AddValidatorsFromAssembly(assembly);
        
        // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
    }
}