using System.Collections.Generic;
using TCGPrimus.Contracts;
using TCGPrimus.Entities;
using TCGPrimus.Entities.Models;
using System.Linq;

namespace TCGPrimus.Repository
{
    internal class ContentRepository : RepositoryBase<Content>, IContentRepository
    {

        public ContentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public Content GetContentById(int contentId)
        {
            return FindByCondition(a => a.Id.Equals(contentId))
                  .DefaultIfEmpty(new Content())
                  .FirstOrDefault(); throw new System.NotImplementedException();
        }

        public IEnumerable<Content> GetContentsByFolder(int folderId)
        {
            return FindByCondition(a => a.FolderId.Equals(folderId));
        }
    }
}