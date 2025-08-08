using ToDoMAUI.Models.Enums;

namespace ToDoMAUI.Models
{
    public class ToDoItem
    {
        public Guid Id { get; set; } 
        public String Title { get; set; } = String.Empty;
        public String? Description { get; set; }
        public Importance Importance { get; set; }
        public ToDoStatus Status { get; set; }
        public DateTime? DeadLine { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
