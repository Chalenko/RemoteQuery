using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Model
{
    public interface IDatabaseContext
    {

        /// <summary>
        /// Создание экземпляра IDbCommand по параметрам
        /// </summary>
        /// <param name="commandText">Текст запроса</param>
        /// <param name="commandType">Тип запроса</param>
        /// <param name="parameters">Параметры запроса</param>
        /// <returns>Команда, готовая к выполнению</returns>
        IDbCommand CreateCommand(string commandText, CommandType commandType, Dictionary<string, object> parameters = null);

        /// <summary>
        /// Создание экзепляра IDbCommand по параметрам
        /// </summary>
        /// <param name="commandText">Текст запроса</param>
        /// <param name="commandType">Тип запроса</param>
        /// <param name="parameters">Параметры запроса</param>
        /// <returns>Команда, готовая к выполнению</returns>
        IDbCommand CreateCommand(string commandText, CommandType commandType, List<IDbDataParameter> parameters);

        /// <summary>
        /// Выполняет команду и возвращает количество задействованных строк
        /// </summary>
        /// <param name="command">SqlCommand команда</param>
        /// <returns>Возвращает количество задействованных строк</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidOperationException">Невозможно открыть подключение без указания сервера или источника данных.or
        /// Подключение уже открыто.</exception>
        int ExecuteCommand(IDbCommand command);

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
        int ExecuteCommand(string commandText, CommandType type, Dictionary<string, object> parameters = null);

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
        int ExecuteCommand(string commandText, CommandType type, List<IDbDataParameter> parameters);

        /// <summary>
        /// Выполняет команду и возвращает скаляр
        /// </summary>
        /// <param name="command">Экземпляр IDbCommand команда</param>
        /// <returns>Возвращает значение первого столбца первой строки из результирующего набора данных</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        object ExecuteScalar(IDbCommand command);

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
        object ExecuteScalar(string commandText, CommandType type, Dictionary<string, object> parameters = null);

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
        object ExecuteScalar(string commandText, CommandType type, List<IDbDataParameter> parameters);

        /// <summary>
        /// Выгрузка таблицы из БД
        /// </summary>
        /// <param name="command">Экземпляр IDbCommand команда</param>
        /// <returns>DataTable объект</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidOperationException">Невозможно открыть подключение без указания сервера или источника данных.or\r\nПодключение уже открыто.</exception>
        DataTable LoadFromDatabase(IDbCommand command);

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
        DataTable LoadFromDatabase(string commandText, CommandType type, Dictionary<string, object> parameters = null);

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
        DataTable LoadFromDatabase(string commandText, CommandType type, List<IDbDataParameter> parameters);

        /// <summary>
        /// Выполнение набора команд в одной транзакции
        /// </summary>
        /// <param name="commands">Список команд для выполнения</param>
        /// <param name="level">Уровень изоляции транзакции</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Exception"></exception>
        void ExecuteTransaction(List<IDbCommand> commands, System.Data.IsolationLevel level = System.Data.IsolationLevel.RepeatableRead);
    }
}
