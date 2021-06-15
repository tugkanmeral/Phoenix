using MongoDB.Driver;
using Phoenix.LayerBases.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.LayerBases.DataAccess.MongoDb
{
    public abstract class MongoRepositoryBase<TDocument> : IMongoRepository<TDocument>
        where TDocument : IDocument
    {
        private MongoContextBase Context;

        protected IMongoCollection<TDocument> _collection;
        public IMongoCollection<TDocument> Collection => _collection;

        public MongoRepositoryBase(MongoContextBase mongoContext)
        {
            Context = mongoContext;
            _collection = Context.Database.GetCollection<TDocument>(typeof(TDocument).Name);
        }

        #region ATOMIC PROCESS
        public void StartTransaction()
        {
            Context.StartTransaction();
        }

        public void CommitAsync()
        {
            Context.CommitAsync();
        }

        public void Commit()
        {
            Context.Commit();
        }

        public void RollBack()
        {
            Context.Commit();
        }

        public void RollBackAsync()
        {
            Context.RollBackAsync();
        }
        #endregion ATOMIC PROCESS

        #region CREATE
        public virtual async void InsertOneAsync(TDocument document)
        {
            await _collection.InsertOneAsync(document);
        }

        public virtual async void InsertOneAsyncTransactional(TDocument document)
        {
            await _collection.InsertOneAsync(Context.Session, document);
        }

        public virtual void Insert(TDocument document)
        {
            _collection.InsertOne(document);
        }

        public virtual void InsertTransactional(TDocument document)
        {
            _collection.InsertOne(Context.Session, document);
        }

        public virtual async void InsertManyAsync(IEnumerable<TDocument> documents)
        {
            await _collection.InsertManyAsync(documents);
        }
        public virtual async void InsertManyAsyncTransactional(IEnumerable<TDocument> documents)
        {
            await _collection.InsertManyAsync(Context.Session, documents);
        }

        public virtual void InsertMany(IEnumerable<TDocument> documents)
        {
            _collection.InsertMany(documents);
        }

        public virtual void InsertManyTransactional(IEnumerable<TDocument> documents)
        {
            _collection.InsertMany(Context.Session, documents);
        }
        #endregion CREATE

        #region READ
        public virtual async Task<TDocument> GetAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return await _collection.Find(filterExpression).FirstOrDefaultAsync();
        }

        public virtual async Task<TDocument> GetAsyncTransactional(Expression<Func<TDocument, bool>> filterExpression)
        {
            return await _collection.Find(Context.Session, filterExpression).FirstOrDefaultAsync();
        }

        public virtual TDocument Get(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).FirstOrDefault();
        }

        public virtual TDocument GetTransactional(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(Context.Session, filterExpression).FirstOrDefault();
        }

        public virtual async Task<IEnumerable<TDocument>> GetListAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            var resultList = await _collection.FindAsync(filterExpression);
            return resultList.ToEnumerable();
        }

        public virtual async Task<IEnumerable<TDocument>> GetListAsyncTransactional(Expression<Func<TDocument, bool>> filterExpression)
        {
            var resultList = await _collection.FindAsync(Context.Session, filterExpression);
            return resultList.ToEnumerable();
        }

        public virtual IEnumerable<TDocument> GetList(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).ToEnumerable();
        }

        public virtual IEnumerable<TDocument> GetListTransactional(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(Context.Session, filterExpression).ToEnumerable();
        }
        #endregion READ

        #region UPDATE
        public virtual async void ReplaceOneAsync(Expression<Func<TDocument, bool>> filterExpression, TDocument document)
        {
            await _collection.FindOneAndReplaceAsync(filterExpression, document);
        }

        public virtual async void ReplaceOneAsyncTransactional(Expression<Func<TDocument, bool>> filterExpression, TDocument document)
        {
            await _collection.FindOneAndReplaceAsync(Context.Session, filterExpression, document);
        }

        public virtual void ReplaceOne(Expression<Func<TDocument, bool>> filterExpression, TDocument document)
        {
            _collection.FindOneAndReplace(filterExpression, document);
        }

        public virtual void ReplaceOneTransactional(Expression<Func<TDocument, bool>> filterExpression, TDocument document)
        {
            _collection.FindOneAndReplace(Context.Session, filterExpression, document);
        }

        public virtual async void UpdateOneAsync(Expression<Func<TDocument, bool>> filterExpression, Dictionary<string, string> updateExpression, TDocument document)
        {
            var filterBuilder = Builders<TDocument>.Filter.Where(filterExpression);
            var updateDefinition = Builders<TDocument>.Update.Combine();
            foreach (KeyValuePair<string, string> expression in updateExpression)
            {
                updateDefinition.AddToSet(expression.Key, expression.Value);
            }
            await _collection.UpdateOneAsync(filterBuilder, updateDefinition);
        }

        public virtual async void UpdateOneAsyncTransactional(Expression<Func<TDocument, bool>> filterExpression, Dictionary<string, string> updateExpression, TDocument document)
        {
            var filterBuilder = Builders<TDocument>.Filter.Where(filterExpression);
            var updateDefinition = Builders<TDocument>.Update.Combine();
            foreach (KeyValuePair<string, string> expression in updateExpression)
            {
                updateDefinition.AddToSet(expression.Key, expression.Value);
            }
            await _collection.UpdateOneAsync(Context.Session, filterBuilder, updateDefinition);
        }

        public virtual void UpdateOne(Expression<Func<TDocument, bool>> filterExpression, Dictionary<string, string> updateExpression, TDocument document)
        {
            var filterBuilder = Builders<TDocument>.Filter.Where(filterExpression);
            var updateDefinition = Builders<TDocument>.Update.Combine();
            foreach (KeyValuePair<string, string> expression in updateExpression)
            {
                updateDefinition.AddToSet(expression.Key, expression.Value);
            }
            _collection.UpdateOne(filterBuilder, updateDefinition);
        }

        public virtual void UpdateOneTransactional(Expression<Func<TDocument, bool>> filterExpression, Dictionary<string, string> updateExpression, TDocument document)
        {
            var filterBuilder = Builders<TDocument>.Filter.Where(filterExpression);
            var updateDefinition = Builders<TDocument>.Update.Combine();
            foreach (KeyValuePair<string, string> expression in updateExpression)
            {
                updateDefinition.AddToSet(expression.Key, expression.Value);
            }
            _collection.UpdateOne(Context.Session, filterBuilder, updateDefinition);
        }
        #endregion UPDATE

        #region DELETE
        public virtual async void DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            await _collection.DeleteOneAsync(filterExpression);
        }

        public virtual async void DeleteOneAsyncTransactional(Expression<Func<TDocument, bool>> filterExpression)
        {
            await _collection.DeleteOneAsync(Context.Session, filterExpression);
        }

        public virtual void DeleteOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            _collection.DeleteOne(filterExpression);
        }

        public virtual void DeleteOneTransactional(Expression<Func<TDocument, bool>> filterExpression)
        {
            _collection.DeleteOne(Context.Session, filterExpression);
        }

        public virtual async void DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            await _collection.DeleteManyAsync(filterExpression);
        }

        public virtual async void DeleteManyAsyncTransactional(Expression<Func<TDocument, bool>> filterExpression)
        {
            await _collection.DeleteManyAsync(Context.Session, filterExpression);
        }

        public virtual void DeleteMany(Expression<Func<TDocument, bool>> filterExpression)
        {
            _collection.DeleteMany(filterExpression);
        }

        public virtual void DeleteManyTransactional(Expression<Func<TDocument, bool>> filterExpression)
        {
            _collection.DeleteMany(Context.Session, filterExpression);
        }

        #endregion DELETE

        public void Add(TDocument entity)
        {
            Insert(entity);
        }

        public void Update(TDocument entity)
        {
            ReplaceOne(e => e._id == entity._id, entity);
        }

        public void Delete(TDocument entity)
        {
            DeleteOne(e => e._id == entity._id);
        }
    }
}
