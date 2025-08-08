using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.DTOs
{
    
    public class DeleteResponseDTO
    {
        public bool IsdeleteSuccesful;
        public DeleteResponseDTO(bool isdeleteSuccesful) {
        IsdeleteSuccesful= isdeleteSuccesful;
        }

    }
}
