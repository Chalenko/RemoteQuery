using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemoteQuery.Application;

namespace RemoteQuery.SQL
{
    public sealed class SQLDatabaseContext : DatabaseContext
    {
        /// <summary>
        /// Хранилище контекстов БД которые и взаимодействует с БД, с которыми в свою очередь работают все остальные классы
        /// </summary>
        private static Dictionary<string, DatabaseContext> _contexts = new Dictionary<string, DatabaseContext>();

        private SQLDatabaseContext(string connectionString) : base()
        {
            _connection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Свойство для предоставления в окрущающую среду объекта для работы с БД используещее connection в качестве строки подключения
        /// </summary>
        /// <param name="connection"> Строка подключения</param>
        /// <returns>Объект для работы с БД</returns>
        public static DatabaseContext GetInstance(string connection)
        {
            if (!_contexts.ContainsKey(connection)) 
                _contexts.Add(connection, new SQLDatabaseContext(connection));
            return _contexts[connection];
        }

        /// <summary>
        /// Свойство для предоставления в окрущающую среду объекта для работы с БД используещее объект connection в качестве подключения
        /// </summary>
        /// <param name="connection">SqlConnection объект</param>
        /// <returns>Объект для работы с БД</returns>
        public static DatabaseContext GetInstance(SqlConnection connection)
        {
            return GetInstance(connection.ConnectionString);
        }
    }
}
