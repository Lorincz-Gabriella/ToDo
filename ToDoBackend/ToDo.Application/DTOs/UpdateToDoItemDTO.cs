using ToDo.Core.Entity.Enums;

namespace ToDo.Application.DTOs
{
    public class UpdateToDoItemDTO
    {
        //meglevo ToDo frissitese,klienstol jon
        //
        public string Title { get; set; }
        public string Description { get; set; }
        public  DateTime DeadLine { get; set; }
        public Importance Importance { get; set; }
        public ToDoStatus Status { get; set; }

    }
}
