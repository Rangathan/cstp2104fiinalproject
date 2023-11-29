using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeDatabase.Models;

namespace RecipeDatabase.Data
{
    public class RecipeDatabaseContext : DbContext
    {
        public RecipeDatabaseContext (DbContextOptions<RecipeDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<RecipeDatabase.Models.Recipe> Recipe { get; set; } = default!;
    }
}
