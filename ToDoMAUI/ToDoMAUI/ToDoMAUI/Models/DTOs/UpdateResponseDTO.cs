using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMAUI.Models.DTOs
{
    public class UpdateResponseDTO
    {
        public bool IsUpdateSuccesful { get; set; }
        public UpdateResponseDTO(bool isUpdateSuccesful)
        {
            IsUpdateSuccesful = isUpdateSuccesful;
        }
    }
}
