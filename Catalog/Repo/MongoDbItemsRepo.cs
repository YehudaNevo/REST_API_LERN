using Catalog.Entities;
using MongoDB.Driver;

namespace Catalog.Repo
{
    public class MongoDbItemsRepo : IItemRepo
    {
        private const string databaseName = "catalog";
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> ItemsCollection;
        public MongoDbItemsRepo(IMongoClient mongoClient)
        {
           IMongoDatabase database = mongoClient.GetDatabase(databaseName);
           ItemsCollection = database.GetCollection<Item>(collectionName);
        }

        public void CreateItem(Item item)
        {
            ItemsCollection.InsertOne(item);
        }

        public void DeleteItem(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}