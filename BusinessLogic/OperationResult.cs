using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedelja9_2021_1.BusinessLogic
{
    public class OperationResult
    {
        public bool IsSuccessfull => !Errors.Any();
        public List<string> Errors { get; set; } = new List<string>();
        public IEnumerable<DTO> Data { get; set; } = new List<DTO>();
    }
}
