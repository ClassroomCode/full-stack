using EComm.Models;
using Microsoft.EntityFrameworkCore;

namespace EComm.DataAccess;

public class EFRepository : DbContext
{
    public EFRepository(DbContextOptions<EFRepository> options)
        : base(options) { }

    public DbSet<Product> Products => Set<Product>();
}
