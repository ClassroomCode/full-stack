using EComm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EComm.DataAccess;

public class Repository(string connStr)
{ 
    public async Task<List<Product>> GetAllProducts()
    {
        var retVal = new List<Product>();
        using var conn = new SqlConnection(connStr);
        using var cmd = new SqlCommand("SELECT * FROM Products ORDER BY ProductName", conn);
        await conn.OpenAsync();
        using var rdr = await cmd.ExecuteReaderAsync();
        while (await rdr.ReadAsync())
        {
            var product = new Product();
            product.ProductID = (int)rdr["ProductID"];
            product.ProductName = (string)rdr["ProductName"];
            retVal.Add(product);
        }
        return retVal;
    }

    public async Task<Product?> GetProduct(int id)
    {
        Product? retVal = null;
        using var conn = new SqlConnection(connStr);
        using var cmd = new SqlCommand("SELECT * FROM Products WHERE ProductID=@id", conn);
        cmd.Parameters.AddWithValue("id", id);
        await conn.OpenAsync();
        using var rdr = await cmd.ExecuteReaderAsync();
        if (await rdr.ReadAsync())
        {
            var product = new Product();
            product.ProductID = (int)rdr["ProductID"];
            product.ProductName = (string)rdr["ProductName"];
            retVal = product;
        }
        return retVal;
    }
}
