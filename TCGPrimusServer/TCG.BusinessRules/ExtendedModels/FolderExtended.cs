using TCG.Models;

namespace TCG.BusinessRules.ExtendedModels
{
    public class FolderExtended
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public WorkflowExtended Workflow { get; set; }

        public FolderExtended()
        {
        }

        public FolderExtended(Folder folder)
        {
            Id = folder.Id;
            Name = folder.Name;
            Workflow = new WorkflowExtended
            {
                Id = folder.Workflow.Id,
                Name = folder.Workflow.Name
            };
        }
    }
}
