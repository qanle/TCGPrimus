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
            return folders.Select(f => new FolderExtended(f));
        }

        public FolderExtended GetById(int id)
        {
            return new FolderExtended(_dbContext.Folders.Find(id));
        }        
    }
}
