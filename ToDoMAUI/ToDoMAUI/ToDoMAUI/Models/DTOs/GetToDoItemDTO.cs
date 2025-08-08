
using ToDoMAUI.Models.Enums;

namespace ToDoMAUI.Models.DTOs
{
    public class GetToDoItemDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Importance Importance { get; set; }
        public ToDoStatus Status { get; set; }
        public DateTime? DeadLine { get; set; }
    }
}
