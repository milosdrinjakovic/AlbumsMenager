using Nedelja9_2021_1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedelja9_2021_1.BusinessLogic
{
    public abstract class EntitiesOperation : Operation
    {
        private readonly ChinookEntities _entities;
        protected ChinookEntities Entities => _entities;
        
        protected EntitiesOperation()
        {
            _entities = new ChinookEntities();
        }
    }
}
