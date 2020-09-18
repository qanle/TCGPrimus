using TCG.Models;

namespace TCG.BusinessRules.ExtendedModels
{
    public class WorkflowExtended
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public WorkflowExtended()
        {
        }
        public WorkflowExtended(Workflow workflow)
        {
            Id = workflow.Id;
            Name = workflow.Name;
        }
    }
}
