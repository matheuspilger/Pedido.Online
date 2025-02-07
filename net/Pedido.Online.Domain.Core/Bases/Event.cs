using MediatR;

namespace Pedido.Online.Domain.Core.Bases
{
    public class Event(EventType eventType, object entity) : Entity, INotification
    {
        public override Guid Id { get; protected set; } = Guid.NewGuid();
        public DateTime ModifyDate { get; private set; } = DateTime.Now;
        public string Type { get; private set; } = entity.GetType().Name;
        public EventType EventType { get; private set; } = eventType;
        public object Entity { get; private set; } = entity;

        public T GetEntity<T>() => (T)Entity;
    }
}
