using System;
using System.Collections.Generic;
using TCGPrimus.Entities.ExtendedModels;
using TCGPrimus.Entities.Models;

namespace TCGPrimus.Contracts
{
    public interface IContentRepository : IRepositoryBase<Content>
    {
        IEnumerable<Content> GetContentsByFolder(int folderId);
        Content GetContentById(int contentId);
    }
}
