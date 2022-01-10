namespace Distro.Domain.Common;

public interface IDomainRequestHandler<TRequest, TResponse> where TRequest : IDomainRequest
{
    TResponse Handle(TRequest request);
}