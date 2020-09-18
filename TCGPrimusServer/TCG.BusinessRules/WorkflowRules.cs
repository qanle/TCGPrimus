using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TCG.BusinessRules.ExtendedModels;
using TCG.Models;

namespace TCG.BusinessRules
{
    public class WorkflowRules : RulesBase
    {
        public IEnumerable<WorkflowExtended> GetAll()
        {
            var wfs= _dbContext.Workflows;
            return wfs.Select(w => new WorkflowExtended(w));
        }

        public WorkflowExtended GetById(int id)
        {
            return new WorkflowExtended(_dbContext.Workflows.Find(id));
        }


        public void CreateWorkflow(Workflow workflow)
        {

            _dbContext.Workflows.Add(workflow);
            _dbContext.Entry(workflow).State = EntityState.Added;
            _dbContext.SaveChanges();
        }


        public void UpdateWorkflow(Workflow workflow)
        {
            var dbOwner = _dbContext.Workflows.Find(workflow.Id);
            

            if (_dbContext.Entry(dbOwner).State == EntityState.Detached)
                _dbContext.Workflows.Attach(dbOwner);
            _dbContext.Entry(dbOwner).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }

        public void DeleteWorkflow(int id)
        {
            var workflow = _dbContext.Workflows.Find(id);
            _dbContext.Workflows.Remove(workflow);
            _dbContext.SaveChanges();
        }
    }
}
