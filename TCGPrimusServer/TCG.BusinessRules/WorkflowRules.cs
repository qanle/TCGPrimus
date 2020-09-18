using System.Collections.Generic;
using System.Linq;
using TCG.BusinessRules.ExtendedModels;

namespace TCG.BusinessRules
{
    public class WorkflowRules : RulesBase
    {
        public IEnumerable<WorkflowExtended> GetAll()
        {
            var folders = _dbContext.Workflows.ToList();
            return folders.Select(f => new WorkflowExtended(f));
        }

        public WorkflowExtended GetById(int id)
        {
            return new WorkflowExtended(_dbContext.Workflows.Find(id));
        }        
    }
}
