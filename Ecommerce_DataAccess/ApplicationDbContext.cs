using Ecommerce_DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Category> Categories { get; set; }
}
