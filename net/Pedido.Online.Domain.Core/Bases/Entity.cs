namespace Pedido.Online.Domain.Core.Bases
{
    public abstract class Entity
    {
        public virtual Guid Id { get; protected set; }
    }
}
