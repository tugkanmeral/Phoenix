using MongoDB.Driver;
using Phoenix.LayerBases.Entity;
using Phoenix.Utils;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.LayerBases.DataAccess.MongoDb
{
    public abstract class MongoContextBase
    {
        protected IMongoClient _client;
        protected IMongoDatabase _database;
        protected IClientSessionHandle _session;
        public IClientSessionHandle Session => _session;
        public IMongoDatabase Database => _database;

        //public MongoContext(string connectionString, string dbName)
        //{
        //    _client = new MongoClient(connectionString);
        //    _database = _client.GetDatabase(dbName);
        //}

        public MongoContextBase()
        {
            string connectionString = ConfigGetter.GetSectionFromJson("MongoSettings:ConnectionString");
            string dbName = ConfigGetter.GetSectionFromJson("MongoSettings:DbName");

            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(dbName);
        }

        //public MongoContext(IMongoClient client)
        //{
        //    string dbName = ConfigGetter.GetSectionFromJson("MongoSettings:DbName");

        //    _client = client;
        //    _database = _client.GetDatabase(dbName);
        //}

        public void StartTransaction()
        {
            if (_session != null && _session.IsInTransaction)
                throw new Exception("Session has been started and using in a transaction.");

            if (_session == null)
                _session = _client.StartSession();

            _session.StartTransaction();
        }

        public async void CommitAsync()
        {
            if (_session == null)
                throw new Exception("Session has been gone somehow!");

            await _session.CommitTransactionAsync();
            _session.Dispose();
        }

        public void Commit()
        {
            if (_session == null)
                throw new Exception("Session has been gone somehow!");

            _session.CommitTransaction();
            _session.Dispose();
        }

        public void RollBack()
        {
            if (_session == null)
                throw new Exception("Session has been gone somehow!");

            _session.AbortTransaction();
        }

        public async void RollBackAsync()
        {
            if (_session == null)
                throw new Exception("Session has been gone somehow!");

            await _session.AbortTransactionAsync();
        }
    }
}
