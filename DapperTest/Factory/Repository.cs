using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DapperTest.Factory
{
    public class Repository<T> : Database, IRepository<T> where T : class
    {
        private IDbConnection con = new SqlConnection(conVal("NorthwindDB"));

        public IEnumerable<T> GetById(string sqlstr, object Param)
        {
            return con.Query<T>(sqlstr, Param);
        }

        public IEnumerable<T> GetAll(string sqlstr)
        {
            return con.Query<T>(sqlstr);
        }

        public void Excute(string sqlstr)
        {
            con.Execute(sqlstr);
        }

        public void ExcuteParam(string sqlstr, object Param)
        {
            con.Execute(sqlstr, Param);
        }

        public void Add(string sqlstr)
        {
            throw new NotImplementedException();
        }

        public void AddParam(string sqlstr, object Param)
        {
            throw new NotImplementedException();
        }

        

    }
}
