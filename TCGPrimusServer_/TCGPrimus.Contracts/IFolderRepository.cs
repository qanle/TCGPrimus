using System;
using System.Collections.Generic;
using TCGPrimus.Entities.ExtendedModels;
using TCGPrimus.Entities.Models;

namespace TCGPrimus.Contracts
{
    public interface IFolderRepository : IRepositoryBase<Folder>
    {
        IEnumerable<Folder> GetAllFolders();
        Folder GetFolderById(int folderId);
    }
}
