﻿using TCG.Models;

namespace TCG.BusinessRules.ExtendedModels
{
    public class ContentExtended
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FolderExtended Folder { get; set; }

        public ContentExtended()
        {
        }

        public ContentExtended(Content content)
        {
            Id = content.Id;
            Name = content.Name;
            Folder = new FolderExtended
            {
                Id = content.Folder.Id,
                Name = content.Folder.Name
            };
        }
    }
}