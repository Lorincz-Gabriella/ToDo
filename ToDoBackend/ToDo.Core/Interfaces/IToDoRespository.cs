using System.Runtime.CompilerServices;
using ToDo.Core.Entity;

namespace ToDo.Core.Interfaces
{
    public  interface IToDoRespository
    {
        public ToDoItem? GetToDoById(Guid id);
        public IEnumerable<ToDoItem> GetAllToDos(); //nem teszek ? ,hogy ne dolgozzunk ures listaval (exception)
        public ToDoItem AddToDoToDB(ToDoItem toDoItem);
        public bool UpdateToDo(ToDoItem toDoItem);
        public bool DeleteToDo(Guid id);

        public Task<ToDoItem?> GetToDoByIdAsync(Guid id); //kulon szalon fog futni 
        public Task<IEnumerable<ToDoItem>> GetAllToDosAsync(); 
        public Task<ToDoItem> AddToDoToDBAsync(ToDoItem toDoItem);
        public Task<bool> UpdateToDoAsync(ToDoItem toDoItem);
        public Task<bool> DeleteToDoAsync(Guid id);

    }
}
