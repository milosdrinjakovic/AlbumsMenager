using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedelja9_2021_1.BusinessLogic
{
    public abstract class DTO
    {
        [Browsable(false)]
        public int Id { get; set; }
    }
}
