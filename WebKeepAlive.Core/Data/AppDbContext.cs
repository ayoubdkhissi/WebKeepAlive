using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKeepAlive.Core.Entities;

namespace WebKeepAlive.Core.Data;
public class AppDbContext : DbContext
{
    public DbSet<Endpoint> Endpoints { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    // Custom Configuration
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Endpoint>(options =>
        {
            options.HasIndex(e => e.EndpointUrl).IsUnique();
        });
    }
}
