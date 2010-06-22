using System;
using System.Data;
using System.Data.SqlClient;

namespace Missing.Data
{
    public static class DbConnectionExtensions
    {
        public static bool IsOpen(this IDbConnection self)
        {
            return self.State == ConnectionState.Open;
        }

        public static T DbQuery<T>(this SqlConnection connection, Func<SqlConnection, T> func)
        {
            try
            {
                if (!connection.IsOpen())
                    connection.Open();
                return func(connection);
            }
            finally
            {
                if (connection.IsOpen())
                    connection.Close();
            }
        }

        public static DataTable GetDataTabel(this SqlConnection connection, Func<SqlConnection,DataTable> func)
        {
            return DbQuery(connection, func);
        }

    }
}