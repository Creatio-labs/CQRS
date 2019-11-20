using System.Collections.Generic;

namespace Global.Configuration.Dal.Abstract.Query.Interfaces
{
    public interface IDBQuery<TModel> where TModel : class
    {
        IEnumerable<TModel> Execute();
    }
}
