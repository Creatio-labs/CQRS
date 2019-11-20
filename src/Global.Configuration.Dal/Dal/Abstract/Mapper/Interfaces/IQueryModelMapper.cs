using System.Data;

namespace Global.Configuration.Dal.Abstract.Mapper.Interfaces
{
    public interface IQueryModelMapper<TModel> where TModel : class
    {
        TModel Convert(IDataReader reader);
    }
}
