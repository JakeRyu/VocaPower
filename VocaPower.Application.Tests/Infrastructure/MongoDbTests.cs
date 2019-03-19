using System.Diagnostics;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Shouldly;
using Xunit;

namespace VocaPower.Application.Tests.Infrastructure
{
    public class MongoDbTests
    {
        [Fact]
        public async Task ConnectionTest()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("foo");
            var collection = database.GetCollection<BsonDocument>("bar");
            var document = new BsonDocument
            {
                { "name", "MongoDB" },
                { "type", "Database" },
                { "count", 1 },
                { "info", new BsonDocument
                {
                    { "x", 203 },
                    { "y", 102 }
                }}
            };
            
            collection.InsertOne(document);
            await collection.InsertOneAsync(document);
            
            var count = await collection.CountDocumentsAsync(new BsonDocument());
            count.ShouldBe(1);
            
        }

        [Fact]
        public async Task Query()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("foo");
            var collection = database.GetCollection<BsonDocument>("bar");
            var document = collection.Find(new BsonDocument()).FirstOrDefault();
            
            Debug.WriteLine(document.ToString());
        }
    }
}