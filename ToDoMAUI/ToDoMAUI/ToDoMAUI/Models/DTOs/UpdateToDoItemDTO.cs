using ToDoMAUI.Models.Enums;

namespace ToDoMAUI.Models.DTOs
{
    public class UpdateToDoItemDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public Importance Importance { get; set; }
        public ToDoStatus Status { get; set; }
    }
}
