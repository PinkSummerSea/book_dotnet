using System;

namespace AutoLot.Dal.BulkImport;

public static class ProcessBulkImport
{
    private const string ConnectionString = 
        @"Data Source=.,1433;User Id=sa;Password=P@sswOrd;Initial Catalog=AutoLot;Encrypt=False;";
    private static SqlConnection _sqlConnection = null;
    private static void OpenConnection()
    {
        _sqlConnection=new SqlConnection(ConnectionString);
        _sqlConnection.Open();
    }
    private static void CloseConnection()
    {
        if (_sqlConnection?.State != ConnectionState.Closed)
        {
            _sqlConnection?.Close();
        }
    }

    public static void ExecuteBulkCopy<T>(IEnumerable<T> records, string tableName)
    {
        OpenConnection();
        using SqlConnection conn = _sqlConnection;
        SqlBulkCopy bc = new(conn)
        {
            DestinationTableName=tableName
        };
        var dataReader = new MyDataReader<T>(records.ToList(), _sqlConnection, "dbo", tableName);
        try
        {
            bc.WriteToServer(dataReader);
        }
        catch (Exception e)
        {
            throw;
        }
        finally
        {
            CloseConnection();
        }
    }
}
