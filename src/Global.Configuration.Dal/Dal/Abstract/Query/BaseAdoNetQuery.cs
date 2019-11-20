using System.Collections.Generic;
using System.Data;
using Terrasoft.Core;
using Terrasoft.Core.DB;

namespace Global.Configuration.Dal.Abstract.Query
{
    public abstract class BaseAdoNetQuery<TModel> : BaseDBQuery<IDBReadableCommand, TModel> where TModel : class
    {
        protected BaseAdoNetQuery(UserConnection userConnection, Dictionary<string, object> arguments = null) : base(userConnection, arguments) { }

        public override IEnumerable<TModel> Execute()
        {
            using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection())
            {                
                using (IDataReader dataReader = Query.ExecuteReader(dbExecutor))
                {
                    while (dataReader.Read())
                    {
                        yield return Mapper.Convert(dataReader);
                    }
                }
            }
        }
    }
}
