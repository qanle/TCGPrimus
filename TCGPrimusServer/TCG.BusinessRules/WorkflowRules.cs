using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TCG.BusinessRules.ExtendedModels;
using TCG.Models;
using TCG.BusinessRules.Helper;

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
            workflow.Activity = _dbContext.Activities.Find(workflow.Activity.Id);
            workflow.Folder = _dbContext.Folders.Find(workflow.Folder.Id);
            workflow.Content = _dbContext.Contents.Find(workflow.Content.Id);
            workflow.ActivitySettings = workflow.ActivitySettings.ToJson();


            _dbContext.Workflows.Add(workflow);
            _dbContext.Entry(workflow).State = EntityState.Added;
            _dbContext.SaveChanges();
        }


        public void UpdateWorkflow(Workflow workflow)
        {
            var dbworkflow = _dbContext.Workflows.Find(workflow.Id);

            dbworkflow.Activity = _dbContext.Activities.Find(workflow.Activity.Id);
            dbworkflow.Folder = _dbContext.Folders.Find(workflow.Folder.Id);
            dbworkflow.Content = _dbContext.Contents.Find(workflow.Content.Id);

            dbworkflow.ActivitySettings = workflow.ActivitySettings.ToJson();

            if (_dbContext.Entry(dbworkflow).State == EntityState.Detached)
                _dbContext.Workflows.Attach(dbworkflow);
            _dbContext.Entry(dbworkflow).State = EntityState.Modified;

            _dbContext.SaveChanges();

           
        }

        public void DeleteWorkflow(int id)
        {
            var workflow = _dbContext.Workflows.Find(id);
            _dbContext.Workflows.Remove(workflow);
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
