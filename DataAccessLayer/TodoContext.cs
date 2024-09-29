using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TodoContext:DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
        public TodoContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
                Database=TodoDatabase;Trusted_Connection=true;TrustServerCertificate=True");
        }
    }
}
