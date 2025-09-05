using EComm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EComm.DataAccess;

public class Repository(string connStr)
{ 
    public List<Product> GetAllProducts()
    {
        var retVal = new List<Product>();
        using var conn = new SqlConnection(connStr);
        using var cmd = new SqlCommand("SELECT * FROM Products ORDER BY ProductName", conn);
        conn.Open();
        using var rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            var product = new Product();
            product.ProductID = (int)rdr["ProductID"];
            product.ProductName = (string)rdr["ProductName"];
            retVal.Add(product);
        }
        return retVal;
    }

    public Product GetProduct(int id)
    {
        return new Product();
    }
}
