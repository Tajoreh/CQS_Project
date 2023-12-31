﻿namespace Framework
{
    public interface IQueryBus
    {
        Task<TResponse> Execute<TRequest, TResponse>(TRequest request) where TRequest : IQuery;
    }
}
