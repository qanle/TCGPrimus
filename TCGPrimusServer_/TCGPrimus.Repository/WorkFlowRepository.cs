using System.Collections.Generic;
using TCGPrimus.Contracts;
using TCGPrimus.Entities;
using TCGPrimus.Entities.ExtendedModels;
using TCGPrimus.Entities.Models;
using System.Linq;
using TCGPrimus.Entities.Extensions;

namespace TCGPrimus.Repository
{
    internal class WorkFlowRepository :RepositoryBase<WorkFlow>, IWorkFlowRepository
    {

        public WorkFlowRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
    {
    }

        public void CreateWorkFlow(WorkFlow workflow)
        {
            Create(workflow);
            Save();
        }

        public void DeleteWorkFlow(WorkFlow workflow)
        {

            Delete(workflow);
            Save();
        }

        public IEnumerable<WorkFlow> GetAllWorkFlows()
        {
            return FindAll()
                .OrderBy(ow => ow.Name);
        }


        public WorkFlow GetWorkFlowById(int workflowId)
        {
            return FindByCondition(w => w.Id.Equals(workflowId))
                .DefaultIfEmpty(new WorkFlow())
                .FirstOrDefault();
        }

        public void UpdateWorkFlow(WorkFlow dbWorkflow, WorkFlow workflow)
        {
            dbWorkflow.Map(workflow);
            Update(dbWorkflow);
            Save();
        }
    }
}
