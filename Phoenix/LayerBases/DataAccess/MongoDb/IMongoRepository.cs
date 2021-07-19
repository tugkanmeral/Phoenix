using MongoDB.Driver;
using Phoenix.LayerBases.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.LayerBases.DataAccess.MongoDb
{
    public interface IMongoRepository<TDocument> : IRepository<TDocument>
        where TDocument : IDocument
    {
        public void StartTransaction();
        public void CommitAsync();
        public void Commit();
        public void RollBack();

        public void RollBackAsync();
        void InsertOneAsync(TDocument document);
        void InsertOneAsyncTransactional(TDocument document);

        void Insert(TDocument document);
        void InsertTransactional(TDocument document);

        /// <summary>
        /// WARNING : When a single write operation modifies multiple documents, the modification of each document is atomic, but the operation as a whole is not atomic.
        /// </summary>
        void InsertManyAsync(IEnumerable<TDocument> documents);
        void InsertManyAsyncTransactional(IEnumerable<TDocument> documents);

        /// <summary>
        /// WARNING : When a single write operation modifies multiple documents, the modification of each document is atomic, but the operation as a whole is not atomic.
        /// </summary>
        void InsertMany(IEnumerable<TDocument> documents);
        void InsertManyTransactional(IEnumerable<TDocument> documents);

        Task<TDocument> GetAsync(Expression<Func<TDocument, bool>> filterExpression);
        Task<TDocument> GetAsyncTransactional(Expression<Func<TDocument, bool>> filterExpression);

        new TDocument Get(Expression<Func<TDocument, bool>> filterExpression);
        TDocument GetTransactional(Expression<Func<TDocument, bool>> filterExpression);

        Task<IEnumerable<TDocument>> GetListAsync(Expression<Func<TDocument, bool>> filterExpression);
        Task<IEnumerable<TDocument>> GetListAsyncTransactional(Expression<Func<TDocument, bool>> filterExpression);

        new IEnumerable<TDocument> GetList(Expression<Func<TDocument, bool>> filterExpression);
        IEnumerable<TDocument> GetListTransactional(Expression<Func<TDocument, bool>> filterExpression);

        void ReplaceOneAsync(Expression<Func<TDocument, bool>> filterExpression, TDocument document);
        void ReplaceOneAsyncTransactional(Expression<Func<TDocument, bool>> filterExpression, TDocument document);

        void ReplaceOne(Expression<Func<TDocument, bool>> filterExpression, TDocument document);
        void ReplaceOneTransactional(Expression<Func<TDocument, bool>> filterExpression, TDocument document);

        void UpdateOneAsync(Expression<Func<TDocument, bool>> filterExpression, Dictionary<string, string> updateExpression, TDocument document);
        void UpdateOneAsyncTransactional(Expression<Func<TDocument, bool>> filterExpression, Dictionary<string, string> updateExpression, TDocument document);

        void UpdateOne(Expression<Func<TDocument, bool>> filterExpression, Dictionary<string, string> updateExpression, TDocument document);
        void UpdateOneTransactional(Expression<Func<TDocument, bool>> filterExpression, Dictionary<string, string> updateExpression, TDocument document);

        void DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression);
        void DeleteOneAsyncTransactional(Expression<Func<TDocument, bool>> filterExpression);

        void DeleteOne(Expression<Func<TDocument, bool>> filterExpression);
        void DeleteOneTransactional(Expression<Func<TDocument, bool>> filterExpression);

        void DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression);
        void DeleteManyAsyncTransactional(Expression<Func<TDocument, bool>> filterExpression);

        void DeleteMany(Expression<Func<TDocument, bool>> filterExpression);
        void DeleteManyTransactional(Expression<Func<TDocument, bool>> filterExpression);
    }
}
