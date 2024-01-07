using System;
using FirebirdSql.Data.FirebirdClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class FirebirdDBConnection
{
    private FbConnection _connection;
    private readonly string _connectionString;

    public FirebirdDBConnection()
    {
        // Set your database information here
        string databasePath = @"C:\SYS_NET\SERVER\BD\BASE.FDB";
        string userName = "sysdba";
        string password = "masterkey";

        // Connection string format for Firebird
        _connectionString = $"User={userName};Password={password};Database={databasePath};DataSource=localhost;Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;\r\nServerType=0;";
    }

    public void OpenConnection()
    {
        try
        {
          //  Console.WriteLine($"ConnectionString: {_connectionString}");
            _connection = new FbConnection(_connectionString);
            _connection.Open();
            Console.WriteLine("Connection opened successfully.");
        }   
        catch (FbException fbEx)
        {
            Console.WriteLine($"Firebird Exception: {fbEx.Message}");
            foreach (FbError error in fbEx.Errors)
            {
                Console.WriteLine($"Message: {error.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error opening connection: {ex.Message}");
        }
    }

    public void CloseConnection()
    {
        try
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
                Console.WriteLine("Connection closed successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error closing connection: {ex.Message}");
        }
    }
    public FbDataReader ExecuteSelectQuery(string query)
    {
        FbCommand command = new FbCommand(query, _connection);

        try
        {
            Console.WriteLine($"Executing query: {query}");
            FbDataReader reader = command.ExecuteReader();
            return reader;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing query: {ex.Message}");
            return null;
        }
    }
}
