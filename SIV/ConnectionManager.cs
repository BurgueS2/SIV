using System.Data;
using MySql.Data.MySqlClient;

namespace SIV;

public class ConnectionManager
{
    private static string _connectionString = "SERVER=localhost; DATABASE=pdv; UID=root; PWD=useroot; PORT=3306;";
    private static MySqlConnection _connection;

    public static MySqlConnection GetConnection()
    {
        if (_connection == null || _connection.State != ConnectionState.Open)
        {
            _connection = new MySqlConnection(_connectionString);
            _connection.Open();
        }

        return _connection;
    }

    public static void CloseConnection()
    {
        if (_connection != null && _connection.State == ConnectionState.Open)
        {
            _connection.Close();
        }
    }
}