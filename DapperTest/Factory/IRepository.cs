using System.Collections.Generic;

namespace DapperTest.Factory
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll(string sqlstr);
        IEnumerable<T> GetById(string sqlstr, object Param);
        void Add(string sqlstr);
        void AddParam(string sqlstr, object Param);
        void Excute(string sqlstr);
        void ExcuteParam(string sqlstr, object Param);
    }
}
