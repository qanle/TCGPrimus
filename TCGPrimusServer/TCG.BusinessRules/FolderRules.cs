using System.Collections.Generic;
using System.Linq;
using TCG.BusinessRules.ExtendedModels;

namespace TCG.BusinessRules
{
    public class FolderRules : RulesBase
    {
        public IEnumerable<FolderExtended> GetAll()
        {
            var folders = _dbContext.Folders.ToList();
            return folders.Select(c => new FolderExtended(c));
        }

        public IEnumerable<FolderExtended> GetByWorkflowId(int workflowId)
        {
            var folders = _dbContext.Folders.Where(f => f.Workflow.Id == workflowId);
            return folders.Select(c => new FolderExtended(c));
        }

        public FolderExtended GetById(int id)
        {
            return new FolderExtended(_dbContext.Folders.Find(id));
        }

    }
}
