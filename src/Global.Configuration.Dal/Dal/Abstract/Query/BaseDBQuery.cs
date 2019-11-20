using Global.Configuration.Dal.Abstract.Mapper.Interfaces;
using Global.Configuration.Dal.Abstract.Query.Interfaces;
using System;
using System.Collections.Generic;
using Terrasoft.Core;
using Terrasoft.Core.Factories;

namespace Global.Configuration.Dal.Abstract.Query
{
    public abstract class BaseDBQuery<TQueryType, TModel> : BaseDBOperation, IDBQuery<TModel> where TModel : class
    {
        protected BaseDBQuery(UserConnection userConnection, Dictionary<string, object> arguments = null) : base(userConnection, arguments)
        {
            InstantiateMapper();
            InstantiateQuery();
        }

        protected IQueryModelMapper<TModel> Mapper { get; private set; }

        protected TQueryType Query { get; private set; }

        private void InstantiateMapper()
        {
            var mapper = ClassFactory.Get<IQueryModelMapper<TModel>>();
            Mapper = mapper ?? throw new ArgumentNullException(string.Format("Mapper for entity {0} was not found", typeof(TModel).Name));
        }

        private void InstantiateQuery()
        {
            var query = GetQuery();
            if (query == null)
            {
                throw new ArgumentNullException("Query cannot be null");
            }
            Query = query;
        } 

        protected abstract TQueryType GetQuery();

        public abstract IEnumerable<TModel> Execute();
    }
}
