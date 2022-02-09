using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FastTypingApi.Entities
{
    public class TextDbContext: DbContext
    {
        public DbSet<Text> Texts { get; set; }
        public DbSet<Score> Scores { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("Host=localhost; Database=fasttype; Username=postgres; Password=12345;");
    }
}
