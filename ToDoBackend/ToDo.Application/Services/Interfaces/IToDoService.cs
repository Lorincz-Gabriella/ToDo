using ToDo.Application.DTOs;

namespace ToDo.Application.Services.Interfaces
{
    public interface IToDoService
    {
        public Task<GetToDoItemDTO?> GetToDoByIdAsync(Guid id);
        public Task<IEnumerable<GetToDoItemDTO>> GetAllToDosAsync(); 
        public Task<GetToDoItemDTO> AddToDoToDBAsync(CreateToDoItemDTO dto);
        public Task<bool> UpdateToDoAsync(Guid id,UpdateToDoItemDTO toDoItem);
        public Task<bool> DeleteToDoAsync(Guid id);

        public GetToDoItemDTO? GetToDoById(Guid id);
        public IEnumerable<GetToDoItemDTO> GetAllToDos();
        public GetToDoItemDTO AddToDoToDB(CreateToDoItemDTO dto);
        public bool UpdateToDo(Guid id, UpdateToDoItemDTO toDoItem);
        public bool DeleteToDo(Guid id);
    }
}
