using System.Collections.Generic;
using System.Data;

namespace Missing.Data
{

    public class SimpleSqlQuery<TObject> : SqlQuery<TObject>
    {
        private readonly RowMapper<TObject> mapper;

        public SimpleSqlQuery(IDbConnection connection, RowMapper<TObject> mapper, CommandType commandType)
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
            var returListe = new List<TObject>();
            command.CommandText = query;
            try
            {
                connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        returListe.Add(mapper(reader));
                    }
                    reader.Close();
                }
            }
            finally
            {
                connection.Close();
            }

            return returListe;
        }

        #endregion
    }

    
}