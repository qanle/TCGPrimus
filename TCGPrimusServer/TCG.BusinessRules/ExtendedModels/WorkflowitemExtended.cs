﻿using System.Collections.Generic;
using TCG.BusinessRules.Helper;
using TCG.Models;

namespace TCG.BusinessRules.ExtendedModels
{
    public class WorkflowitemExtended
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string ActivitySettings { get; set; }

        public Dictionary<string, object> ActivitySettings { get; set; }

        public virtual WorkflowExtended Workflow { get; set; }
        public virtual FolderExtended Folder { get; set; }
        public virtual ActivityExtended Activity { get; set; }

        public WorkflowitemExtended()
        {
        }

        public WorkflowitemExtended(WorkflowItem workflow)
        {
            if (workflow == null) return ;
            Id = workflow.Id;
            Name = workflow.Name;
            ActivitySettings = workflow.ActivitySettings.ParseAs<Dictionary<string, object>>();
            Workflow = new WorkflowExtended { Id = workflow.Workflow.Id, Name = workflow.Workflow.Name };
            Folder = new FolderExtended { Id = workflow.Folder.Id, Name = workflow.Folder.Name };
            Activity = new ActivityExtended { Id = workflow.Activity.Id, Name = workflow.Activity.Name };
        }
    }
}
