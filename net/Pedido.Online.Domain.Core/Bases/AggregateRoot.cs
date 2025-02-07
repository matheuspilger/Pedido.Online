namespace Pedido.Online.Domain.Core.Bases
{
    public abstract class AggregateRoot : Entity
    {
        private List<Event> _domainEvents;

        public virtual bool IsActive { get; protected set; }

        public void Delete() => IsActive = !IsActive;

        public IReadOnlyCollection<Event> DomainEvents() =>
            _domainEvents.AsReadOnly();

        public void AddDomainEvent(Event domainEvent)
        {
            _domainEvents ??= [];
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents() =>
            _domainEvents?.Clear();
    }
}
