using ToDo.Core.Entity.Enums;

namespace ToDo.Application.DTOs
{
    public class CreateToDoItemDTO 
    {
        //uj toDot-t hozunk letre,csak az kell amit a felhasznalo bekuld
        // id,status ... a rendszer generalja
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DeadLine { get; set; }
        public Importance Importance { get; set; }
    }
}
