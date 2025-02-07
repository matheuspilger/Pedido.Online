namespace Pedido.Online.Domain.Core.Bases
{
    public abstract class QueryModel<T>
    {
        public Guid Id { get; protected set; }
        public bool IsActive { get; protected set; }

        public abstract QueryModel<T> Map(T entity);
    }
}
