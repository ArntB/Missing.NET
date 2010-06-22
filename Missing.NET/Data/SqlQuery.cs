using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Missing.Data
{
    public delegate TObject RowMapper<TObject>(IDataReader reader);
    public abstract class SqlQuery<TObject>: ISqlQuery<TObject>
    {
        protected IDbCommand command;
        protected IDbConnection connection;

        protected SqlQuery(IDbConnection connection, CommandType commandType)
        {
            this.connection = connection;
            command = connection.CreateCommand();
            command.CommandType = commandType;
        }

        private void OpenConnection()
        {
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public string Query
        {
            set; get;
        }
        
        public void RegisterParameter(DbType type, string field, object value)
        {
            command.RegisterParameter(type, field, value);
        }

        public void CreateParameter(string name, SqlDbType sqlDbType, ParameterDirection parameterDirection, int size, object value)
        {
            IDataParameterCollection parameters = command.Parameters;
            var parameter = new SqlParameter(name, sqlDbType, size);
            parameter.Direction = parameterDirection;
            parameter.Value = value;
            parameters.Add(parameter);
        }

        public void CreateParameter(string name, SqlDbType sqlDbType, object value)
        {
            IDataParameterCollection parameters = command.Parameters;
            var parameter = new SqlParameter(name, sqlDbType);
            parameter.Value = value;
            parameters.Add(parameter);
        }

        
        public abstract IList<TObject> Execute();
        public abstract IList<TObject> Execute(string query);
    }
}