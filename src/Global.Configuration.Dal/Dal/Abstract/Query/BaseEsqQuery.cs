using System;
using System.Collections.Generic;
using Terrasoft.Core;
using Terrasoft.Core.Entities;

namespace Global.Configuration.Dal.Abstract.Query
{
    public abstract class BaseEsqQuery<TModel>: BaseDBQuery<EntitySchemaQuery, TModel> where TModel : class
    {
        protected BaseEsqQuery(UserConnection userConnection, Dictionary<string, object> arguments = null) : base(userConnection, arguments) { }

        public override IEnumerable<TModel> Execute()
        {
            throw new NotImplementedException();
        }
    }
}
