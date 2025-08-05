using ToDo.Core.Entity;
using ToDo.Core.Entity.Enums;

var item = new ToDoItem 
{ 
    Title = "Test",
    Id = Guid.NewGuid(),
    CreatedAt = DateTime.UtcNow,
    Importance = Importance.Important
}; 
