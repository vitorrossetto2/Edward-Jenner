using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EdwardJenner.Domain.Interfaces.Repositories;
using EdwardJenner.Models.Interfaces.Models;
using EdwardJenner.Models.Settings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EdwardJenner.Data.Repositories
{
    public class BaseRepository<TModel> : MongoDbBaseRepository, IBaseRepository<TModel> where TModel : IModelBase
    {
        public BaseRepository(MongoConnection mongoConnection) : base(mongoConnection)
        {
        }

        protected IMongoCollection<TModel> BaseCollection => Database.GetCollection<TModel>(GetCollectionName());

        protected virtual string GetCollectionName()
        {
            return typeof(TModel).Name;
        }

        public async Task<TModel> Update(TModel order)
        {
            order.UpdatedIn = DateTime.Now;
            return await BaseCollection.FindOneAndReplaceAsync(x => x.Id == order.Id, order);
        }

        public async Task<TModel> Save(TModel entity)
        {
            entity.Id = string.IsNullOrEmpty(entity.Id) ? ObjectId.GenerateNewId().ToString() : entity.Id;
            entity.UpdatedIn = DateTime.Now;
            await BaseCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity, new UpdateOptions { IsUpsert = true });
            return entity;
        }

        public async Task<TModel> FindBy(Expression<Func<TModel, bool>> filter)
        {
            return await BaseCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task Insert(TModel order)
        {
            order.UpdatedIn = DateTime.Now;
            await BaseCollection.InsertOneAsync(order);
        }

        public async Task<IList<TModel>> ListBy(Expression<Func<TModel, bool>> filter)
        {
            return await BaseCollection.Find(filter).ToListAsync();
        }

        public async Task Delete(Expression<Func<TModel, bool>> filter)
        {
            await BaseCollection.DeleteManyAsync(filter);
        }
    }
}
