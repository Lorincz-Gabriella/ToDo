using ToDo.Core.Entity.Enums;

namespace ToDo.Application.DTOs
{
    public class GetToDoItemDTO
    {
        //ToDo-t lekerunk s visszadunk kiensnek
        public Guid Id { get; set; }
        public string Name{ get; set; } = string.Empty;
        public string? Description { get; set; }
        public Importance Importance { get; set; }
        public ToDoStatus Status { get; set; }
        public DateTime? DeadLine { get; set; }
    }
}
