using MediatR;
using Microsoft.EntityFrameworkCore;
using Pedido.Online.Domain.Core.Bases;

namespace Pedido.Online.Infrastructure.Extensions
{
    public static class MediatorExtensions
    {
        public static async Task PublishEvent<T>(this IMediator mediator, T context) where T : DbContext
        {
            var domainEntities = context.ChangeTracker
                .Entries<AggregateRoot>()
                .Where(x => x.Entity.DomainEvents() is not null && x.Entity.DomainEvents().Count != 0);

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents()).ToList();

            domainEntities.ToList().ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents.Select(async (domainEvent) =>
                await mediator.Publish(domainEvent));

            await Task.WhenAll(tasks);
        }
    }
}
