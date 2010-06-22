using System.Collections.Generic;
using System.Data;

namespace Missing.Data
{
    public interface ISqlQuery<TObject>
    {
        string Query { get; set; }
        IList<TObject> Execute();
        void RegisterParameter(DbType type, string field, object value);
        void CreateParameter(string name, SqlDbType sqlDbType, ParameterDirection parameterDirection, int size, object value);
    }
}