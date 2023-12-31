﻿namespace Framework;

public class RequestBus : IRequestBus
{
    private readonly IRequestHandlerResolver _resolver;

    public RequestBus(IRequestHandlerResolver resolver)
    {
        _resolver = resolver;
    }
    public async Task<TResponse> Dispatch<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken) where TRequest : class, IRequest
    {
        var handler = _resolver.ResolveHandler<TRequest, TResponse>(request);

        return await handler.Handle(request, cancellationToken);
    }
}