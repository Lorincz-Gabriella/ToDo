using ToDo.Application.DTOs;

namespace ToDo.Application.Services.Interfaces
{
    public interface IToDoService
    {
        public Task<GetToDoItemDTO?> GetToDoByIdAsync(Guid id);
        public Task<IEnumerable<GetToDoItemDTO>> GetAllToDosAsync(); 
        public Task<GetToDoItemDTO> AddToDoToDBAsync(CreateToDoItemDTO dto);
        public Task<UpdateResponseDTO> UpdateToDoAsync(Guid id,UpdateToDoItemDTO toDoItem);
        public Task<DeleteResponseDTO> DeleteToDoAsync(Guid id);

        public GetToDoItemDTO? GetToDoById(Guid id);
        public IEnumerable<GetToDoItemDTO> GetAllToDos();
        public GetToDoItemDTO AddToDoToDB(CreateToDoItemDTO dto);
        public UpdateResponseDTO UpdateToDo(Guid id, UpdateToDoItemDTO toDoItem);
        public DeleteResponseDTO DeleteToDo(Guid id);
    }
}
