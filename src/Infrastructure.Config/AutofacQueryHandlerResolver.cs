﻿using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Domain;
using Framework;

namespace Infrastructure.Config; 

public class AutofacQueryHandlerResolver : IQueryHandlerResolver
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