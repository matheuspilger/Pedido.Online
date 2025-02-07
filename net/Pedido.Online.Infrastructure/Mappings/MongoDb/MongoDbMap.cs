using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Entities.CustomerAggregate;
using Pedido.Online.Domain.Events.CustomerEvent.Actions;
using Pedido.Online.Domain.Entities.ProductAggregate;
using Pedido.Online.Domain.Entities.OrderAggregate;
using Pedido.Online.Domain.Events.OrderEvent.Actions;
using Pedido.Online.Domain.Events.ProductEvent.Actions;

namespace Pedido.Online.Infrastructure.Mappings.MongoDb
{
    public class MongoDbMap
    {
        private static Dictionary<Type, string> _mappings = [];

        public static void Configure()
        {
            MapCollections();
            RegisterSerializers();
            RegisterConventions();
        }

        private static void MapCollections()
        {
            if (_mappings.Count > 0) return;

            _mappings.Add(typeof(Customer), "customers");
            _mappings.Add(typeof(Product), "products");
            _mappings.Add(typeof(Order), "orders");
            _mappings.Add(typeof(CustomerEvent), "events");
            _mappings.Add(typeof(ProductEvent), "events");
            _mappings.Add(typeof(OrderEvent), "events");
        }

        private static void RegisterConventions()
        {
            var pack = new ConventionPack
            {
                new CamelCaseElementNameConvention(),
                new IgnoreIfNullConvention(true)
            };

            ConventionRegistry.Register("Conventions", pack, filter => 
                filter.Assembly == typeof(Event).Assembly || filter.Assembly == typeof(Entity).Assembly);
        }

        private static void RegisterSerializers()
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            BsonSerializer.RegisterSerializer(new ObjectSerializer(ObjectSerializer.AllAllowedTypes));
        }

        public static string GetCollectionName(Type type)
        {
            var collectionName =_mappings.GetValueOrDefault(type) 
                ?? throw new ArgumentNullException($"Tipo: {type} não foi mapeado.");
            return collectionName;
        }

        public static List<string> GetCollectionsNames() => [.. _mappings.Values];
    }
}
