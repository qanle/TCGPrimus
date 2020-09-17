using System;
using System.Collections.Generic;
using System.Linq;
using TCG.Models;

namespace TCG.BusinessRules
{
    public class OwnerRules : RulesBase
    {
        public List<Owner> GetAll()
        {
            return _dbContext.Owners.ToList();
        }

        public Owner GetById(Guid id)
        {
            return _dbContext.Owners.Find(id);
        }
    }
}
