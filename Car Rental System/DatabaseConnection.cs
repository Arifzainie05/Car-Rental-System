using System;
using System.Data;
using System.Data.SqlClient;

public class DatabaseConnection : IDisposable
{
    private readonly string _connectionString;
    private SqlConnection _connection;

    public DatabaseConnection(string connectionString)
    {
        _connectionString = connectionString;
        _connection = new SqlConnection(_connectionString);
    }

    // Buka connection
    public void Open()
    {
        if (_connection.State != ConnectionState.Open)
            _connection.Open();
    }

    // Tutup connection
    public void Close()
    {
        if (_connection.State != ConnectionState.Closed)
            _connection.Close();
    }

    // Execute query yang return data (SELECT)
    public SqlDataReader ExecuteReader(string query)
    {
        SqlCommand command = new SqlCommand(query, _connection);
        return command.ExecuteReader();
    }

    // Execute query SELECT dengan parameter
    public SqlDataReader ExecuteReader(string query, SqlParameter[] parameters)
    {
        SqlCommand command = new SqlCommand(query, _connection);

        if (parameters != null)
        {
            command.Parameters.AddRange(parameters);
        }

        return command.ExecuteReader();
    }

    // Execute query untuk INSERT, UPDATE, DELETE (return rows affected)
    public int ExecuteNonQuery(string query)
    {
        SqlCommand command = new SqlCommand(query, _connection);
        return command.ExecuteNonQuery();
    }

    // Dispose untuk bersihkan resource
    public void Dispose()
    {
        if (_connection != null)
        {
            if (_connection.State == ConnectionState.Open)
                _connection.Close();

            _connection.Dispose();
            _connection = null;
        }
    }
}
