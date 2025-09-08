using EComm.Models;
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

    public async Task<bool> UpdateProduct(Product product)
    {
        using var conn = new SqlConnection(connStr);
        using var cmd = new SqlCommand("UPDATE Products SET ProductName=@name WHERE ProductID=@id", conn);
        cmd.Parameters.AddWithValue("id", product.ProductID);
        cmd.Parameters.AddWithValue("name", product.ProductName);
        await conn.OpenAsync();
        int numRows = await cmd.ExecuteNonQueryAsync();
        
        return (numRows == 1);
    }

    public async Task AddProduct(Product product)
    {
        using var conn = new SqlConnection(connStr);
        using var cmd = new SqlCommand("INSERT INTO Products (ProductName) VALUES (@name); SELECT SCOPE_IDENTITY();", conn);
        cmd.Parameters.AddWithValue("name", product.ProductName);
        await conn.OpenAsync();
        object? newID = (await cmd.ExecuteScalarAsync());
        if (newID is null) throw new ApplicationException("Database fail");

        product.ProductID = Convert.ToInt32(newID);
    }

    public async Task DeleteProduct(Product product)
    {
        using var conn = new SqlConnection(connStr);
        using var cmd = new SqlCommand("DELETE FROM Products WHERE ProductID=@id", conn);
        cmd.Parameters.AddWithValue("id", product.ProductID);
        await conn.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
    }
}
