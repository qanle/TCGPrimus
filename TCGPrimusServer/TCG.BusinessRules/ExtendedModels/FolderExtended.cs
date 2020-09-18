using System.Collections.Generic;
using TCG.Models;

namespace TCG.BusinessRules.ExtendedModels
{
    public class FolderExtended
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public FolderExtended()
        {
        }
        public FolderExtended(Folder folder)
        {
            Id = folder.Id;
            Name = folder.Name;
        }
    }
}
