

using ToDoMAUI.Models.DTOs;

namespace ToDoMAUI.Services.Interfaces
{
    public interface IService  //ezek csak a meghivasok => async hogy ui ne blokkolodjon
    {
        public Task<List<GetToDoItemDTO>> GetAllToDOsAsync(); //mobile vegett,androidon menjen,legyen async ne blokkolja az ui-t
        public Task<GetToDoItemDTO> GetToDoItemDTOAsync(Guid id);

        public Task<GetToDoItemDTO> AddToDoToDB(CreateToDoItemDTO dto);

        public Task<DeleteResponseDTO> DeleteToDoItemAsync(Guid id);
        public Task<UpdateResponseDTO> UpdateToDoItemAsync(Guid id,UpdateToDoItemDTO dto);

    }
}
