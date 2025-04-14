using Microsoft.EntityFrameworkCore;

namespace ToDoApi.Models
{
    public class ToDoContext(DbContextOptions<ToDoContext> options) : DbContext(options)
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
