using EComm.Models;
using Microsoft.Data.SqlClient;

namespace EComm.DataAccess;

public class Repository(string connStr)
{ 
    public List<Product> GetAllProducts()
    {
        var retVal = new List<Product>();
        using var conn = new SqlConnection(connStr);
        conn.Open();

        // fetch data

        return retVal;
    }
}
