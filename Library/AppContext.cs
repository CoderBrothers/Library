using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    //Две колекции типа Dbset, для читателей и для книг
    public class AppContext : DbContext
    {
        private readonly StreamWriter logWriter = new("logs.txt", true);
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Book> Books { get; set; }
        public AppContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=tasks.db");
            optionsBuilder.LogTo(logWriter.WriteLine, LogLevel.Information);
        }
        public override void Dispose()
        {
            base.Dispose();
            logWriter.Dispose();
        }
        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await logWriter.DisposeAsync();
        }
    }
}
