namespace Distro.Domain.Common;

public interface IDomainEventDispatcher
{
    void Publish<T>(T @event) where T : IDomainEvent;
    TResponse Request<TRequest, TResponse>(TRequest request) where TRequest : IDomainRequest;
}