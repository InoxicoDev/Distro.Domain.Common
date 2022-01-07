namespace Distro.Domain.Common
{
    public class DomainEventPublisher
    {
        private static IDomainEventDispatcher _instance;
        public static void SetInstance(IDomainEventDispatcher instance)
        {
            _instance = instance; 
        }
        public static IDomainEventDispatcher Instance
        {
            get => _instance;
            private set => _instance = value;
        }
    }
    
    public interface IDomainEventDispatcher
    {
        void Publish<T>(T @event) where T : IDomainEvent;
        
        void Send<T>(T command)where T : IDomainCommand;

        TResponse Request<TRequest, TResponse>(TRequest request) where TRequest : IDomainRequest;
    }

    public interface IDomainEvent { }
    public interface IDomainCommand { }
    public interface IDomainRequest { }
    
    public interface IDomainEventHandler<T> where T : IDomainEvent
    {
        void Handle(T @event);
    }
    
    public interface IDomainCommandHandler<T> where T : IDomainCommand
    {
        void Handle(T @event);
    }
    
    public interface IDomainRequestHandler<TRequest, TResponse> where TRequest : IDomainRequest
    {
        TResponse Handle(TRequest request);
    }
}
