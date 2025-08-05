using Microsoft.EntityFrameworkCore;
using ToDo.Core.Entity;


namespace Infrastructure.Persistence.Context
{
    public class ToDoDBContext: DbContext //ezzel erjuk el az adatbazist
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public ToDoDBContext(DbContextOptions<ToDoDBContext> options) : base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //migracios fajlhoz
            modelBuilder.Entity<ToDoItem>().HasKey(ToDoItem => ToDoItem.Id);
            modelBuilder.Entity<ToDoItem>().Property(ToDoItem => ToDoItem.Title).IsRequired() //nem lehet null
           .HasMaxLength(100);
        }
    }
}
