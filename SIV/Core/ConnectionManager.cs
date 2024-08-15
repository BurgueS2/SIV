using System.Data;
using MySql.Data.MySqlClient;

namespace SIV.Core;

/// <summary>
/// A classe é responsável por gerenciar a conexão com o banco de dados MySQL.
/// Ela fornece métodos estáticos para abrir e fechar a conexão com o banco de dados,
/// garantindo que a aplicação utilize uma única instância da conexão durante sua execução.
/// </summary>
public class ConnectionManager
{
    private static string _connectionString = "SERVER=localhost; DATABASE=pdv; UID=root; PWD=root; PORT=3306;";
    private static MySqlConnection _connection;

    /// <summary>
    /// Retorna uma instância da conexão com o banco de dados.
    /// Se a conexão ainda não foi estabelecida ou se foi fechada, uma nova conexão é aberta e retornada.
    /// </summary>
    /// <returns>'MySqlConnection' representando a conexão aberta com o banco de dados.</returns>
    public static MySqlConnection GetConnection()
    {
        if (_connection == null || _connection.State != ConnectionState.Open)
        {
            _connection = new MySqlConnection(_connectionString);
            _connection.Open();
        }

        return _connection;
    }

    /// <summary>
    /// Fecha a conexão com o banco de dados se ela estiver aberta.
    /// </summary>
    public static void CloseConnection()
    {
        if (_connection != null && _connection.State == ConnectionState.Open)
        {
            _connection.Close();
        }
    }
}