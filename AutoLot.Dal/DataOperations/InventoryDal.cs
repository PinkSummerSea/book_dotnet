using System;
using System.Data.Common;

namespace AutoLot.Dal.DataOperations;

public class InventoryDal:IDisposable
{
    private readonly string _connectionString;
    public InventoryDal(string connectionString)=> _connectionString=connectionString;
    public InventoryDal():this(@" Data Source=.,1433;User Id=sa;Password=P@sswOrd;Initial Catalog=AutoLot;Encrypt=False;"){}
    private SqlConnection _sqlConnection=null;
    private void OpenConnection()
    {
        _sqlConnection=new(_connectionString);
        _sqlConnection.Open();
    }
    private void CloseConnection()
    {
        if (_sqlConnection.State != ConnectionState.Closed)
        {
            _sqlConnection.Close();
        }
    }
    public List<CarViewModel> GetAllInventory()
    {
        OpenConnection();
        List<CarViewModel> inventory = new();
        string sql=
        @"SELECT i.Id, i.Color, i.PetName, m.Name as Make
                FROM Inventory i
                INNER JOIN Makes m
                ON m.Id = i.MakeId";
        using SqlCommand command = new(sql, _sqlConnection){CommandType=CommandType.Text};
        SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (dataReader.Read())
        {
            inventory.Add(new CarViewModel
            {
                Id=(int)dataReader["Id"],
                PetName=(string)dataReader["PetName"],
                Color=(string)dataReader["Color"],
                Make=(string)dataReader["Make"]
            });
        }
        dataReader.Close();

        return inventory;
    }
    public CarViewModel GetCar(int id)
    {
        OpenConnection();
        CarViewModel car = null;
        SqlParameter param = new()
        {
            ParameterName="@carId",
            Value=id,
            SqlDbType=SqlDbType.Int,
            Direction=ParameterDirection.Input
        };
        string sql=
        $@"SELECT i.Id, i.Color, i.PetName, m.Name as Make
        FROM Inventory i
        INNER JOIN Makes m
        ON i.MakeId = m.Id
        WHERE i.Id=@carId";
        
        using var command = new SqlCommand(sql, _sqlConnection);
        command.Parameters.Add(param);
        using (var dataReader = command.ExecuteReader(CommandBehavior.CloseConnection))
        {
            while (dataReader.Read())
            {
                car = new()
                {
                    Id=(int)dataReader["Id"],
                    PetName=(string)dataReader["PetName"],
                    Color=(string)dataReader["Color"],
                    Make=(string)dataReader["Make"]
                };
            }
        };
        return car;
    }
    public void InsertAuto(string color, int makeId, string petName)
    {
        OpenConnection();
        string sql=
        $@"INSERT INTO Inventory (MakeId,PetName,Color) VALUES ('{makeId}','{petName}','{color}')";
        using var command = new SqlCommand(sql, _sqlConnection);
        command.ExecuteNonQuery();
        CloseConnection();
    }
    public void InsertAuto(Car car)
    {
        OpenConnection();
        
        string sql=
        @"INSERT INTO Inventory
        (MakeId, Color, PetName)
        VALUES(@MakeId,@Color,@PetName)";
        using (var command = new SqlCommand(sql, _sqlConnection))
        {
            command.CommandType=CommandType.Text;
            SqlParameter param = new()
            {
                Value=car.MakeId,
                ParameterName="@MakeId",
                SqlDbType=SqlDbType.Int,
                Direction=ParameterDirection.Input
            };
            command.Parameters.Add(param);
            param = new()
            {
                Value=car.Color,
                ParameterName="@Color",
                SqlDbType=SqlDbType.NVarChar,
                Size=50,
                Direction=ParameterDirection.Input
            };
            command.Parameters.Add(param);
            param = new()
            {
                Value=car.PetName,
                ParameterName="@PetName",
                SqlDbType=SqlDbType.NVarChar,
                Size=50,
                Direction=ParameterDirection.Input
            };
            command.Parameters.Add(param);
            command.ExecuteNonQuery();
            CloseConnection();
        };
    }
    public void DeleteCar(int id)
    {
        OpenConnection();
        SqlParameter param = new()
        {
          ParameterName="@id",
          Value=id,
          SqlDbType=SqlDbType.Int,
          Direction=ParameterDirection.Input  
        };
        string sql=
        @"DELETE FROM Inventory
        WHERE Id=@id";
        using var command = new SqlCommand(sql,_sqlConnection);
        command.Parameters.Add(param);
        try
        {
            command.ExecuteNonQuery();
        }
        catch (SqlException e)
        {
            Exception error = new Exception("Sorry, that car is on order.",e);
            throw error;
        }
        CloseConnection();
    }
    public void UpdateCar(int id, string petName)
    {
        OpenConnection();
        SqlParameter paramId = new()
        {
          ParameterName="@id",
          Value=id,
          SqlDbType=SqlDbType.Int,
          Direction=ParameterDirection.Input  
        };
        SqlParameter paramPetName = new()
        {
          ParameterName="@petName",
          Value=petName,
          SqlDbType=SqlDbType.NVarChar,
          Size=50,
          Direction=ParameterDirection.Input  
        };
        string sql=
        @"UPDATE Inventory
        SET PetName=@petName
        WHERE Id=@id";
        using var command = new SqlCommand(sql,_sqlConnection);
        command.Parameters.Add(paramId);
        command.Parameters.Add(paramPetName);
        command.ExecuteNonQuery();
        CloseConnection();
    }
    public string LookUpPetName(int carID)
    {
        OpenConnection();
        string petName;
        //using stored procedure instead of sql statement as the CommandText
        using var command = new SqlCommand("GetPetName",_sqlConnection);
        SqlParameter paramId = new()
        {
            ParameterName="@carID",
            Value=carID,
            SqlDbType=SqlDbType.Int,
            Direction=ParameterDirection.Input
        };
        SqlParameter paramPetName = new()
        {
            ParameterName="@petName",
            SqlDbType=SqlDbType.NVarChar,
            Size=50,
            Direction=ParameterDirection.Output
        };
        command.Parameters.Add(paramId);
        command.Parameters.Add(paramPetName);
        command.CommandType=CommandType.StoredProcedure;
        command.ExecuteNonQuery();
        petName = (string)command.Parameters["@petName"].Value;
        CloseConnection();
        return petName;
    }
    public void ProcessCreditRisk(bool throwEx, int customerId)
    {
        OpenConnection();
        string fName;
        string lName;
        //find the customer in the Customers table
        var commandSelect = new SqlCommand(
            "SELECT * FROM Customers WHERE Id=@customerId",
            _sqlConnection
        ); 
        SqlParameter paramCustomerId = new()
        {
          ParameterName="@customerId",
          Value=customerId,
          SqlDbType=SqlDbType.Int,
          Direction=ParameterDirection.Input
        };
        commandSelect.Parameters.Add(paramCustomerId);
        using (var reader = commandSelect.ExecuteReader())
        {
            if (reader.HasRows)
            {
                reader.Read();
                fName=(string)reader["FirstName"];
                lName=(string)reader["LastName"];
            }
            else
            {
                CloseConnection();
                return;
            }
        };
        
        commandSelect.Parameters.Clear();
        //insert the customer to the CreditRisk table
        SqlCommand commandInsert = new(
            "INSERT CreditRisks (FirstName,LastName,CustomerId) VALUES (@FirstName, @LastName, @customerId)",
            _sqlConnection
        );
        SqlParameter paramFirstName=new()
        {
            ParameterName="@FirstName",
            Value=fName,
            SqlDbType=SqlDbType.NVarChar,
            Size=50,
            Direction=ParameterDirection.Input
        };

        SqlParameter paramLastName=new()
        {
            ParameterName="@LastName",
            Value=lName,
            SqlDbType=SqlDbType.NVarChar,
            Size=50,
            Direction=ParameterDirection.Input
        };
        SqlParameter paramCustomerId2= new()
        {
          ParameterName="@customerId",
          Value=customerId,
          SqlDbType=SqlDbType.Int,
          Direction=ParameterDirection.Input
        };
        commandInsert.Parameters.Add(paramFirstName);
        commandInsert.Parameters.Add(paramLastName);
        commandInsert.Parameters.Add(paramCustomerId2);
        //update their last name by adding "(Credit Risk)" to the end
        SqlCommand commandUpdate = new(
            "UPDATE Customers SET LastName = LastName + ' (Credit Risk) ' WHERE Id=@customerId",
            _sqlConnection
        );

        commandUpdate.Parameters.Add(paramCustomerId);
        var tx = _sqlConnection.BeginTransaction();
        try
        {
            commandInsert.Transaction=tx;
            commandUpdate.Transaction=tx;
            commandInsert.ExecuteNonQuery();
            commandUpdate.ExecuteNonQuery();
            //simulate error
            if (throwEx)
            {
                throw new Exception("database error, transaction failed");
            }
            //otherwise commit it
            tx.Commit();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            tx?.Rollback();
        }
        finally
        {
            CloseConnection();
        }
    }
    bool _disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if(_disposed) return;
        if(disposing) _sqlConnection.Dispose();
        _disposed=true;


    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
