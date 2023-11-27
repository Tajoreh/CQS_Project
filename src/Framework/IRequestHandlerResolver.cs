namespace Framework;

public interface IRequestHandlerResolver
{
    IRequestHandler<TRequest, TResponse> ResolveHandler<TRequest, TResponse>(TRequest request) where TRequest : IRequest;
}