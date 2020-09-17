using System.Collections.Generic;
using TCGPrimus.Contracts;
using TCGPrimus.Entities;
using TCGPrimus.Entities.Models;
using System.Linq;

namespace TCGPrimus.Repository
{
    internal class FolderRepository :  RepositoryBase<Folder>, IFolderRepository
    {

        public FolderRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Folder> GetAllFolders()
        {
            return FindAll()
                .OrderBy(ow => ow.Name);
        }

        public Folder GetFolderById(int folderId)
        {
            return FindByCondition(f => f.Id.Equals(folderId))
                .DefaultIfEmpty(new Folder())
                .FirstOrDefault();
        }
    }
}