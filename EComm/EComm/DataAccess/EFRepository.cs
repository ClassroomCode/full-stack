using EComm.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Reflection.Metadata;

namespace EComm.DataAccess;

public class EFRepository : DbContext
{
    public EFRepository(DbContextOptions<EFRepository> options)
        : base(options) { }

    public DbSet<Product> Products => Set<Product>();
}
