using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using ToDo.Core.Entity;
using ToDo.Core.Interfaces;

namespace Infrastructure.Persistence.Repositories
{
    public class ToDoRepository : IToDoRespository
    {
        private readonly IDbContextFactory<ToDoDBContext> _dbContextFactory;

        public ToDoRepository(IDbContextFactory<ToDoDBContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public ToDoItem AddToDoToDB(ToDoItem toDoItem)
        {
            using var context=_dbContextFactory.CreateDbContext(); //using is ugyanezt csinalja ,mikor mar  nem kell meghivja a dispose() t
            context.ToDoItems.Add(toDoItem);
            context.SaveChanges();
            //context.Dispose(); garbage collectornak szolunk hogy a contexet szabaditsa fel ,nem varunk a program lefutasa vegeig
            return toDoItem;
        }

        public async Task<ToDoItem> AddToDoToDBAsync(ToDoItem toDoItem)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            await context.AddAsync(toDoItem);
            await context.SaveChangesAsync();
            return toDoItem;
        }

        public bool DeleteToDo(Guid id)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var ToDo=context.ToDoItems.Find(id);
            if(ToDo != null)
            {
                context.ToDoItems.Remove(ToDo);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteToDoAsync(Guid id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            var toDo = context.ToDoItems.Find(id);
            if(toDo!= null)
            {
                context.ToDoItems.Remove(toDo);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public IEnumerable<ToDoItem> GetAllToDos()
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.ToDoItems.AsNoTracking().ToList(); //AsNoTracking ha nem modositok az adaton gyorsabb,ha igen nem 
        }

        public async Task<IEnumerable<ToDoItem>> GetAllToDosAsync()
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.ToDoItems.AsNoTracking().ToListAsync();
        }

        public ToDoItem? GetToDoById(Guid id)
        {
            using var context=_dbContextFactory.CreateDbContext();
            return context.ToDoItems.AsNoTracking().FirstOrDefault(ToDo => ToDo.Id==id);
        }

        public async Task<ToDoItem?> GetToDoByIdAsync(Guid id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.ToDoItems.AsNoTracking().FirstOrDefaultAsync(ToDo => ToDo.Id==id);
        }

        public bool UpdateToDo(ToDoItem toDoItem)
        {
            using var context= _dbContextFactory.CreateDbContext();
            var ToDo=context.ToDoItems.Update(toDoItem);
            if (ToDo == null)
            {
                return false;
            }
            else
            {
                context.SaveChanges();
                return true;
            }
        }

        public async Task<bool> UpdateToDoAsync(ToDoItem toDoItem)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            var ToDo = context.ToDoItems.Update(toDoItem);
            if (ToDo == null)
            {
                return false;
            }
            else
            {
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
