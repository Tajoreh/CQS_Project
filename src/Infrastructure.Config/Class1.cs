using Application;
using Autofac;
using Autofac.Core;
using Domain;
using Framework;
using Infrastructure.Persistence.Ef;
using Infrastructure.Query.Ef;

namespace Infrastructure.Config; public class AutofacQueryHandlerResolver : IQueryHandlerResolver
{
    private readonly ILifetimeScope _lifetimeScope;

    public AutofacQueryHandlerResolver(ILifetimeScope lifetimeScope)
    {
        _lifetimeScope = lifetimeScope;
    }
    public IQueryHandler<TRequest, TResponse> ResolveHandlers<TRequest, TResponse>(TRequest request) where TRequest : IQuery
    {
        return _lifetimeScope.Resolve<IQueryHandler<TRequest, TResponse>>();
    }
}
public class AutofacCommandHandlerResolver : ICommandHandlerResolver
{
    private readonly IComponentContext _context;

    public AutofacCommandHandlerResolver(IComponentContext context)
    {
        _context = context;
    }
    public IEnumerable<ICommandHandler<T>> ResolveHandlers<T>(T command) where T : ICommand
    {
        return _context.Resolve<IEnumerable<ICommandHandler<T>>>();
    }
}

public class Bootstrap
{
    private readonly ContainerBuilder _container;
    public void WireUps()
    {
        _container.RegisterType<AutofacCommandHandlerResolver>().As<ICommandHandlerResolver>().InstancePerLifetimeScope();
        _container.RegisterType<AutofacQueryHandlerResolver>().As<IQueryHandlerResolver>().InstancePerLifetimeScope();
        _container.RegisterAssemblyTypes(typeof(PersonCommandHandlers).Assembly)
            .As(type => type.GetInterfaces()
                .Where(interfaceType => interfaceType.IsClosedTypeOf(typeof(ICommandHandler<>))))
            .InstancePerLifetimeScope();

        _container
            .RegisterAssemblyTypes(typeof(PersonQueryHandlers).Assembly)
            .AsClosedTypesOf(typeof(IQueryHandler<,>))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        _container.RegisterAssemblyTypes(typeof(PersonRepository).Assembly)
            .Where(type => typeof(IRepository).IsAssignableFrom(type))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }

}