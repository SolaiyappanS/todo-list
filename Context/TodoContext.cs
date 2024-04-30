using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_list.Models;

namespace todo_list.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

        public DbSet<Todo> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(
                new Todo
                {
                    Id = Guid.NewGuid(),
                    Title = "First Task",
                    Description = "First Description",
                    CreatedDate = DateTime.UtcNow,
                    IsCompleted = false,
                },
                new Todo
                {
                    Id = Guid.NewGuid(),
                    Title = "Second Task",
                    Description = "Second Description",
                    CreatedDate = DateTime.UtcNow,
                    IsCompleted = false,
                }
            );
        }
    }
}