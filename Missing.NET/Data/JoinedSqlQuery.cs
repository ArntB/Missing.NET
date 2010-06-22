using System.Collections.Generic;
using System.Data;

namespace Missing.Data
{
    public delegate TObject JoinMapper<TObject>(IDataReader reader, IDictionary<object, TObject> objects);

    public class JoinedSqlQuery<TObject> : SqlQuery<TObject> 
    {
        private JoinMapper<TObject> mapper;

        public JoinedSqlQuery(IDbConnection connection, JoinMapper<TObject> mapper, CommandType commandType)
            : base(connection,commandType)
        {
            this.mapper = mapper;
        }

        #region ISqlQuery<TObject> Members

        public override IList<TObject> Execute()
        {
            return Execute(Query);
        }

        public override IList<TObject> Execute(string query)
        {
            command.CommandText = query;
            IDictionary<object, TObject> objects = new Dictionary<object, TObject>();
            try
            {
                connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mapper(reader, objects);
                    }
                }
            }
            finally
            {
                connection.Close();
            }
            return new List<TObject>(objects.Values);
        }

        #endregion
    }
}