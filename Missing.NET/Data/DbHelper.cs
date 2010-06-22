using System.Data;

namespace Missing.Data
{
    public static class DbHelper
    {
        #region AddDataParameterToDbCommand
        public static void RegisterParameter(this IDbCommand command, DbType type, string name, object value)
        {
            IDataParameter parameter = command.CreateParameter();
            parameter.DbType = type;
            parameter.ParameterName = name;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }
        #endregion
    }
}