using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using RemoteQuery.Utils;
using RemoteQuery.Model;


namespace RemoteQuery.Application
{
    /// <summary>
    /// Класс для работы с запросами в БД
    /// </summary>
    public abstract class DatabaseContext : IDatabaseContext
    {

        /// <summary>
        /// Соединение с БД
        /// </summary>
        protected IDbConnection _connection;

        ///// <summary>
        ///// Список реализованных провайдеров
        ///// </summary>
        //protected static Dictionary<string, DatabaseContext> _providers = new Dictionary<string, DatabaseContext>();
        //public static IEnumerable<KeyValuePair<string, DatabaseContext>> Providers { get => _providers.ToList(); }

        protected DatabaseContext() { }

        /// <summary>
        /// Создание команды по параметрам
        /// </summary>
        /// <param name="commandText">Текст запроса</param>
        /// <param name="commandType">Тип запроса</param>
        /// <param name="parameters">Параметры запроса</param>
        /// <returns>Команда, готовая к выполнению</returns>
        public IDbCommand CreateCommand(string commandText, CommandType commandType, Dictionary<string, object> parameters = null)
        {
            IDbCommand command = CreateCommand(commandText, commandType);
            IncludeParameters(command, parameters);
            return command;
        }

        /// <summary>
        /// Создание команды по параметрам
        /// </summary>
        /// <param name="commandText">Текст запроса</param>
        /// <param name="commandType">Тип запроса</param>
        /// <param name="parameters">Параметры запроса</param>
        /// <returns>Команда, готовая к выполнению</returns>
        public IDbCommand CreateCommand(string commandText, CommandType commandType, List<IDbDataParameter> parameters)
        {
            IDbCommand command = CreateCommand(commandText, commandType);
            IncludeParameters(command, parameters);
            return command;
        }

        /// <summary>
        /// Выполняет команду и возвращает количество задействованных строк
        /// </summary>
        /// <param name="command">Экземпляр команды</param>
        /// <returns>Возвращает количество задействованных строк</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidOperationException">Невозможно открыть подключение без указания сервера или источника данных.or
        /// Подключение уже открыто.</exception>
        public int ExecuteCommand(IDbCommand command)
        {
            int rowCount;
            if (command == null)
                throw new ArgumentNullException("command");
            if (command.Connection == null || string.IsNullOrWhiteSpace(command.Connection.ConnectionString))
                throw new ArgumentNullException("connection");
            if (string.IsNullOrWhiteSpace(command.CommandText))
                throw new ArgumentNullException("command text");
            if (!command.Connection.ConnectionString.Equals(_connection.ConnectionString))
                throw new ArgumentException("Illegal command connection");

            try
            {
                command.Connection.Open();
                rowCount = command.ExecuteNonQuery();
            }
            finally
            {
                command.Connection.Close();
            }
            return rowCount;
        }

        /// <summary>
        /// Выполняет команду и возвращает количество задействованных строк
        /// </summary>
        /// <param name="commandText">Текст команды</param>
        /// <param name="type">Тип команды System.Data.CommandType</param>
        /// <param name="parameters">Набор параметров с именами и значениями</param>
        /// <returns>Возвращает количество задействованных строк</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        public int ExecuteCommand(string commandText, CommandType type, Dictionary<string, object> parameters = null)
        {
            using (IDbCommand command = CreateCommand(commandText, type, parameters))
            {
                return this.ExecuteCommand(command);
            }
        }

        /// <summary>
        /// Выполняет команду и возвращает количество задействованных строк
        /// </summary>
        /// <param name="commandText">Текст команды</param>
        /// <param name="type">Тип команды System.Data.CommandType</param>
        /// <param name="parameters">Набор параметров с именами и значениями</param>
        /// <returns>Возвращает количество задействованных строк</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        public int ExecuteCommand(string commandText, CommandType type, List<IDbDataParameter> parameters)
        {
            using (IDbCommand command = CreateCommand(commandText, type, parameters))
            {
                return this.ExecuteCommand(command);
            }
        }

        /// <summary>
        /// Выполняет команду и возвращает скаляр
        /// </summary>
        /// <param name="command">Экземпляр команды</param>
        /// <returns>Возвращает значение первого столбца первой строки из результирующего набора данных</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        public object ExecuteScalar(IDbCommand command)
        {
            object result = null;
            if (command == null)
                throw new ArgumentNullException("command");
            if (command.Connection == null || string.IsNullOrWhiteSpace(command.Connection.ConnectionString))
                throw new ArgumentNullException("connection");
            if (string.IsNullOrWhiteSpace(command.CommandText))
                throw new ArgumentNullException("command text");
            if (!command.Connection.ConnectionString.Equals(_connection.ConnectionString)) 
                throw new ArgumentException("Illegal command connection");
            try
            {
                command.Connection.Open();
                result = command.ExecuteScalar();
            }
            finally
            {
                command.Connection.Close();
            }

            return result;
        }

        /// <summary>
        /// Выполняет команду и возвращает скаляр
        /// </summary>
        /// <param name="commandText">Текст команды</param>
        /// <param name="type">Тип команды System.Data.CommandType</param>
        /// <param name="parameters">Набор параметров с именами и значениями</param>
        /// <returns>Возвращает значение первого столбца первой строки из результирующего набора данных</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        public object ExecuteScalar(string commandText, CommandType type, Dictionary<string, object> parameters = null)
        {
            using (IDbCommand command = CreateCommand(commandText, type, parameters))
            {
                return this.ExecuteScalar(command);
            }
        }

        /// <summary>
        /// Выполняет команду и возвращает скаляр
        /// </summary>
        /// <param name="commandText">Текст команды</param>
        /// <param name="type">Тип команды System.Data.CommandType</param>
        /// <param name="parameters">Набор параметров с именами и значениями</param>
        /// <returns>Возвращает значение первого столбца первой строки из результирующего набора данных</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        public object ExecuteScalar(string commandText, CommandType type, List<IDbDataParameter> parameters)
        {
            using (IDbCommand command = CreateCommand(commandText, type, parameters))
            {
                return this.ExecuteScalar(command);
            }
        }

        /// <summary>
        /// Выгрузка таблицы из БД
        /// </summary>
        /// <param name="command">Экземпляр команда</param>
        /// <returns>DataTable объект</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidOperationException">Невозможно открыть подключение без указания сервера или источника данных.or\r\nПодключение уже открыто.</exception>
        public DataTable LoadFromDatabase(IDbCommand command)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            if (command.Connection == null || string.IsNullOrWhiteSpace(command.Connection.ConnectionString))
                throw new ArgumentNullException("connection");
            if (string.IsNullOrWhiteSpace(command.CommandText))
                throw new ArgumentNullException("command text");
            if (!command.Connection.ConnectionString.Equals(_connection.ConnectionString))
                throw new ArgumentException("Illegal command connection");

            DataTable table = new DataTable();
            try
            {
                command.Connection.Open();
                table.Load(command.ExecuteReader());
            }
            finally
            {
                command.Connection.Close();
            }
            return table;
        }

        /// <summary>
        /// Выгрузка таблицы из БД
        /// </summary>
        /// <param name="commandText">Текст команды</param>
        /// <param name="type">Тип команды System.Data.CommandType</param>
        /// <param name="parameters">Набор параметров с именами и значениями</param>
        /// <returns>DataTable объект</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        public DataTable LoadFromDatabase(string commandText, CommandType type, Dictionary<string, object> parameters = null)
        {
            using (IDbCommand command = CreateCommand(commandText, type, parameters))
            {
                return this.LoadFromDatabase(command);
            }
        }

        /// <summary>
        /// Выгрузка таблицы из БД
        /// </summary>
        /// <param name="commandText">Текст команды</param>
        /// <param name="type">Тип команды System.Data.CommandType</param>
        /// <param name="parameters">Набор параметров с именами и значениями</param>
        /// <returns>DataTable объект</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        public DataTable LoadFromDatabase(string commandText, CommandType type, List<IDbDataParameter> parameters)
        {
            using (IDbCommand command = CreateCommand(commandText, type, parameters))
            {
                return this.LoadFromDatabase(command);
            }
        }

        /// <summary>
        /// Выполнение набора команд в одной транзакции
        /// </summary>
        /// <param name="commands">Список команд для выполнения</param>
        /// <param name="level">Уровень изоляции транзакции</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Exception"></exception>
        public void ExecuteTransaction(List<IDbCommand> commands, System.Data.IsolationLevel level = System.Data.IsolationLevel.RepeatableRead)
        {
            if (commands == null)
                throw new ArgumentNullException("commands");

            IDbTransaction transaction = null;
            try
            {
                _connection.Open();
                // Start a local transaction.
                transaction = _connection.BeginTransaction(level);
                foreach (IDbCommand command in commands)
                {
                    //command.Transaction = transaction;
                    ExecuteTransaction(command, transaction);
                }
                // Attempt to commit the transaction.
                // connection.Close();
                transaction.Commit();
            }
            catch (DbException ex)
            {
                // Attempt to roll back the transaction.
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                _connection.Close();
            }
        }

        /// <summary>
        /// Выполнение набора команд в одной транзакции
        /// </summary>
        /// <param name="command">Экземпляр команды</param>
        /// <param name="transaction"></param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        private int ExecuteTransaction(IDbCommand command, IDbTransaction transaction)
        {
            int rowCount;
            if (command == null)
                throw new ArgumentNullException("command");
            if (command.Connection == null || string.IsNullOrWhiteSpace(command.Connection.ConnectionString))
                throw new ArgumentNullException("connection");
            if (string.IsNullOrWhiteSpace(command.CommandText))
                throw new ArgumentNullException("command text");
            if (!command.Connection.ConnectionString.Equals(_connection.ConnectionString))
                throw new ArgumentException("Illegal command connection");
                
            command.Transaction = transaction;
            rowCount = command.ExecuteNonQuery();

            return rowCount;
        }

        private IDbCommand CreateCommand(string commandText, CommandType commandType)
        {
            IDbCommand command = _connection.CreateCommand();
            command.CommandTimeout = 60000; //In seconds
            command.CommandText = commandText;
            command.CommandType = commandType;
            return command;
        }

        private void IncludeParameters(IDbCommand command, Dictionary<string, object> parameters)
        {
            command.Parameters.Clear();
            if (!parameters.IsNullOrEmpty())
            {
                foreach (var parametr in parameters)
                {
                    IDbDataParameter dbParametr = command.CreateParameter();
                    dbParametr.ParameterName = parametr.Key;
                    dbParametr.Value = parametr.Value ?? DBNull.Value;
                    command.Parameters.Add(dbParametr);
                }
            }
        }

        private void IncludeParameters(IDbCommand command, List<IDbDataParameter> parameters)
        {
            command.Parameters.Clear();
            if (!parameters.IsNullOrEmpty())
            {
                foreach (var parametr in parameters)
                {
                    command.Parameters.Add(parametr);
                }
            }
        }
    }
}
