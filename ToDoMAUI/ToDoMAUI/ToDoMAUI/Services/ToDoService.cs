using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using ToDoMAUI.Models.DTOs;
using ToDoMAUI.Services.Interfaces;

namespace ToDoMAUI.Services
{
    public class ToDoService : IService
    {
        private readonly HttpClient _httpClient;
        private string BaseUrl => DeviceInfo.Platform == DevicePlatform.Android ? "http://localhost:7295" : "http://localhost:7295";
        public ToDoService(HttpClient client) {
            _httpClient = client;
        }

        public async Task<GetToDoItemDTO> AddToDoToDB(CreateToDoItemDTO dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/api/todos",dto);
            var result = new GetToDoItemDTO();
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<GetToDoItemDTO>();
                if (result == null)
                {
                    return new GetToDoItemDTO();
                }
                return result;
            }
            return result;
        }

        public async Task<DeleteResponseDTO> DeleteToDoItemAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/api/todos/{id}");
            var result = new DeleteResponseDTO(false);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<DeleteResponseDTO>();
                if (result == null)
                {
                    return new DeleteResponseDTO(false);
                }
                return result;
            }
            return result;
        }

        public async Task<List<GetToDoItemDTO>> GetAllToDOsAsync()
        {
            var response = await _httpClient.GetAsync($"{ BaseUrl}/api/todos");
            var result = new List<GetToDoItemDTO>();
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<List<GetToDoItemDTO>>();
                if (result == null)
                {
                    return new List<GetToDoItemDTO>();
                }
                return result;
            }
            return result;
        }

        public async Task<GetToDoItemDTO> GetToDoItemDTOAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/api/todos/{id}");
            var result = new GetToDoItemDTO();
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<GetToDoItemDTO>();
                if (result == null)
                {
                    return new GetToDoItemDTO();
                }
                return result;
            }
            return result;
        }

        public async Task<UpdateResponseDTO> UpdateToDoItemAsync(Guid id, UpdateToDoItemDTO dto)
        {
            var response = await _httpClient.PatchAsJsonAsync($"{BaseUrl}/api/todos/{id}", dto);
            var result = new UpdateResponseDTO(false);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<UpdateResponseDTO>();
                if (result == null)
                {
                    return new UpdateResponseDTO(false);
                }
                return result;
            }
            return result;
        }
    }
}
