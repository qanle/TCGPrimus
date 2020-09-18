using TCG.Models;

namespace TCG.BusinessRules.ExtendedModels
{
    public class WorkflowExtended
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ActivitySettings { get; set; }

        public virtual FolderExtended Folder { get; set; }
        public virtual ContentExtended Content { get; set; }
        public virtual ActivityExtended Activity { get; set; }

        public WorkflowExtended()
        {
        }

        public WorkflowExtended(Workflow workflow)
        {
            Id = workflow.Id;
            Name = workflow.Name;
            ActivitySettings = workflow.ActivitySettings;
            Folder = new FolderExtended { Id = workflow.Folder.Id, Name = workflow.Folder.Name };
            Content = new ContentExtended { Id = workflow.Content.Id, Name = workflow.Content.Name };
            Activity = new ActivityExtended { Id = workflow.Activity.Id, Name = workflow.Activity.Name };
        }
    }
}
