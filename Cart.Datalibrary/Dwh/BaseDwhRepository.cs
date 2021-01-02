using Cart.DataModels.DwhEntities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace SLOT.Infrastructure.DataLibrary.Dwh
{
    public class BaseDwhRepository<TModel>
          where TModel : BaseDwhModel
    {
        private readonly IMongoCollection<TModel> mongoCollection;

        public BaseDwhRepository(string mongoDBConnectionString, string dbName)
        {
            var client = new MongoClient(mongoDBConnectionString);
            var database = client.GetDatabase(dbName);
            mongoCollection = database.GetCollection<TModel>(typeof(TModel).Name);
        }

        public virtual IQueryable<TModel> GetList()
        {
            return mongoCollection.AsQueryable(new AggregateOptions { AllowDiskUse = true });
        }

        public virtual IMongoCollection<TModel> GetColletion()
        {
            return mongoCollection;
        }

        public virtual TModel GetById(ObjectId id)
        {
            return mongoCollection.Find<TModel>(m => m.Id == id).FirstOrDefault();
        }

        public virtual TModel Create(TModel model)
        {
            mongoCollection.InsertOne(model);
            return model;
        }

        public virtual List<TModel> Create(List<TModel> model)
        {
            mongoCollection.InsertMany(model);
            return model;
        }

        public virtual void Update(ObjectId id, TModel model)
        {
            mongoCollection.ReplaceOne(m => m.Id == id, model);
        }

        public virtual void Delete(TModel model)
        {
            mongoCollection.DeleteOne(m => m.Id == model.Id);
        }

        public virtual void Delete(ObjectId id)
        {
            mongoCollection.DeleteOne(m => m.Id == id);
        }
    }
}
