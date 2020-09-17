using System;
using System.Collections.Generic;
using TCGPrimus.Entities.ExtendedModels;
using TCGPrimus.Entities.Models;

namespace TCGPrimus.Contracts
{
    public interface IWorkFlowRepository : IRepositoryBase<WorkFlow>
    {
        IEnumerable<WorkFlow> GetAllWorkFlows();
        WorkFlow GetWorkFlowById(int workflowId);
        void CreateWorkFlow(WorkFlow workflow);
        void UpdateWorkFlow(WorkFlow dbWorkflow, WorkFlow workflow);
        void DeleteWorkFlow(WorkFlow workflow);
    }
}
