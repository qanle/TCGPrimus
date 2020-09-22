using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TCG.BusinessRules.ExtendedModels;
using TCG.Models;
using TCG.BusinessRules.Helper;

namespace TCG.BusinessRules
{
    public class WorkflowItemRules : RulesBase
    {
        public IEnumerable<WorkflowitemExtended> GetAll()
        {
            var wfs= _dbContext.WorkflowItems;
            return wfs.Select(w => new WorkflowitemExtended(w));
        }

        public WorkflowitemExtended GetById(int id)
        {
            return new WorkflowitemExtended(_dbContext.WorkflowItems.Find(id));
        }


        public void CreateWorkflowItem(WorkflowitemExtended workflowItem)
        {
            var wfItem = new WorkflowItem
            {
                Name = workflowItem.Name,
                Activity = _dbContext.Activities.Find(workflowItem.Activity.Id),
                Workflow = _dbContext.Workflows.Find(workflowItem.Workflow.Id),
                Folder = _dbContext.Folders.Find(workflowItem.Folder.Id),
                ActivitySettings = workflowItem.ActivitySettings.ToJson()
            };

            _dbContext.WorkflowItems.Add(wfItem);
            _dbContext.Entry(wfItem).State = EntityState.Added;
            _dbContext.SaveChanges();
        }


        public void UpdateWorkflowItem(WorkflowitemExtended workflowItem)
        {
            var dbWorkflowItem = _dbContext.WorkflowItems.Find(workflowItem.Id);

            dbWorkflowItem.Activity = _dbContext.Activities.Find(workflowItem.Activity.Id);
            dbWorkflowItem.Workflow = _dbContext.Workflows.Find(workflowItem.Workflow.Id);
            dbWorkflowItem.Folder = _dbContext.Folders.Find(workflowItem.Folder.Id);
            dbWorkflowItem.Name = workflowItem.Name;
            dbWorkflowItem.ActivitySettings = workflowItem.ActivitySettings.ToJson();

            if (_dbContext.Entry(dbWorkflowItem).State == EntityState.Detached)
                _dbContext.WorkflowItems.Attach(dbWorkflowItem);
            _dbContext.Entry(dbWorkflowItem).State = EntityState.Modified;

            _dbContext.SaveChanges();

           
        }

        public void DeleteWorkflowItem(int id)
        {
            var workflowItem = _dbContext.WorkflowItems.Find(id);
            _dbContext.WorkflowItems.Remove(workflowItem);
            _dbContext.SaveChanges();
        }


        private void GetSetting(string settings, string keyName)
        {
            var setting = settings.ParseAs<Dictionary<string, object>>();
            if (!setting.ContainsKey(keyName))
            {
                setting.Add(keyName, "abc");
            }
            else if (string.IsNullOrEmpty(setting[keyName]?.ToString()))
                setting[keyName] = "DefaultValue";
        }
    }
}
