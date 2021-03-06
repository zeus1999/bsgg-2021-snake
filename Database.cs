using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;

namespace Snake_OOP {
    class Database {

        private MongoClient client;
        private IMongoDatabase database;

        public Database(){
            client = new MongoClient("mongodb://snake:snake@jung-tobias.de:27017,jung-tobias.de:27018,jung-tobias.de:27019/?authSource=bsgg&replicaSet=main&readPreference=primary&appname=MongoDB%20Compass&ssl=false");
            database = client.GetDatabase("bsgg");  
        }

        public List<BsonDocument> getScoreboard(){
            var sort = Builders<BsonDocument>.Sort.Descending("counter");
            var collection = database.GetCollection<BsonDocument>("snake");
            var documents = collection.Find(new BsonDocument()).Sort(sort).Limit(5).ToList();

            return documents;
        }

        public bool insertPoints(string name, int points){
          
            var doc = new BsonDocument {
                {"name", name },
                {"counter", points },
            };

            var collection = database.GetCollection<BsonDocument>("snake");

            collection.InsertOne(doc);


            return true;
        }
    }
}
