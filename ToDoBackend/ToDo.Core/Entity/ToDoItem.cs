using ToDo.Core.Entity.Enums;

namespace ToDo.Core.Entity
{
    public class ToDoItem 
    {
        public Guid Id { get; set; }  //public mert id property nem field
        public  String Title { get; set; } =String.Empty;
        public String? Description { get; set; }
        public Importance Importance { get; set; }
        public ToDoStatus Status { get; set; }
        public DateTime? DeadLine { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
