﻿namespace Framework
{
    public interface IQueryHandlerResolver
    {
        IQueryHandler<TRequest,TResponse> ResolveHandlers<TRequest, TResponse>(TRequest request) where TRequest : IQuery;
    }
}
