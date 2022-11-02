using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using RecipieBook.Api.Models;

namespace RecipeBook.Api.Data
{
    public class RecipieDbContext : DbContext
    {

        public RecipieDbContext(DbContextOptions options):base(options)
        {
            
        }
        
        public DbSet<Recipie> Recipies {get; set;}
    }
}