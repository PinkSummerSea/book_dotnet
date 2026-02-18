using Microsoft.Data.SqlClient;

using (SqlConnection connection = new SqlConnection())
{
    
    // connection.ConnectionString = @" Data Source=.,1433;User Id=sa;Password=P@sswOrd;Initial Catalog=AutoLot;Encrypt=False;";

    var connectionStringBuilder = new SqlConnectionStringBuilder
    {
        DataSource=".,1433",
        UserID="sa",
        Password="P@sswOrd",
        InitialCatalog="AutoLot",
        Encrypt=false,
        ConnectTimeout=30
    };
    connection.ConnectionString=connectionStringBuilder.ConnectionString;

    connection.Open();
    // create a sql command object
    string sql = 
        @"Select i.Id, m.Name as Make, i.Color, i.PetName
          From Inventory i
          INNER JOIN Makes m
          on i.MakeId=m.Id";
    //SqlCommand myCommand = new SqlCommand(sql, connection);
    SqlCommand myCommand = new();
    myCommand.Connection=connection;
    myCommand.CommandText=sql;


    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
    {
        while (myDataReader.Read())
        {
            // Console.WriteLine($"Make: {myDataReader["Make"]}, PetName: {myDataReader["PetName"]}, Color: {myDataReader["Color"]}");
            for(int i = 0; i < myDataReader.FieldCount; i++)
            {
                Console.Write(i!=myDataReader.FieldCount-1?
                    $"{myDataReader.GetName(i)}:{myDataReader.GetValue(i)},":
                    $"{myDataReader.GetName(i)}:{myDataReader.GetValue(i)}\n"
                );

            }
        }
    }

}
