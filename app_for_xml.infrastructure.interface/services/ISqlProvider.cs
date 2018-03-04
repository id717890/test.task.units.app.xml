using System.Data.SqlClient;

namespace app_for_xml.infrastructure.services {
    /// <summary>
    /// Интерфейс описывает функционал для работы с подключение к СУБД Sql-Server
    /// </summary>
    public interface ISqlProvider {
        /// <summary>
        /// Создает новое подключение
        /// </summary>
        /// <returns></returns>
        SqlConnection CreateConnection();
        /// <summary>
        /// Инициализирует класс данными, необходимыми для подключения к северу СУДБ
        /// </summary>
        /// <param name="connectionString">Строка подлючения к серверу</param>
        void Init(string connectionString);
    }
}
