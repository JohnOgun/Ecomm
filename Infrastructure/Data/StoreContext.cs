using Core.Entities;

// Lets us use the Product class from the Core layer.

using Infrastructure.Config;
// Lets us use configuration classes like ProductConfiguration.

using Microsoft.EntityFrameworkCore;
// Gives access to Entity Framework Core features (DbContext, DbSet, etc.).

using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data;
// Organizes this class inside the Infrastructure.Data folder/layer.

public class StoreContext(DbContextOptions options) : DbContext(options)
// This creates your database context.
// It inherits from DbContext (EF Core’s main class for database work).
// "DbContextOptions options" allows configuration (like connection string).
{
    public DbSet<Product> Products { get; set; }
    // This represents the Products table in the database.
    // Each Product object = one row in the table.
    // "Products" becomes the table name.

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    // This method lets you configure how your models map to the database.
    {
        base.OnModelCreating(modelBuilder);
        // Keeps default EF Core behavior.

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
        // This automatically finds and applies all configuration classes
        // in the same assembly as ProductConfiguration.
        // Example: custom rules for Product (table name, column types, etc.)
    }
}