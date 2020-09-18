using System.Collections.Generic;
using System.Linq;
using TCG.BusinessRules.ExtendedModels;

namespace TCG.BusinessRules
{
    public class ContentRules : RulesBase
    {
        public IEnumerable<ContentExtended> GetAll()
        {
            var contents = _dbContext.Contents.ToList();
            return contents.Select(c => new ContentExtended(c));
        }

        public IEnumerable<ContentExtended> GetByFolderId(int folderId)
        {
            var contents = _dbContext.Contents.Where(f => f.Folder.Id == folderId);
            return contents.Select(c => new ContentExtended(c));
        }

        public ContentExtended GetById(int id)
        {
            return new ContentExtended(_dbContext.Contents.Find(id));
        }

    }
}
