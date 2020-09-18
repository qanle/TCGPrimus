import { Workflow } from './workflow.model';
import {Folder} from './folder.model';
import {Activity} from './activity.model'
export interface WorkflowItem {
  Id: number;
  Name: string;
  ActivitySettings: string;
  Workflow: Workflow;
  Folder: Folder;
  Activity: Activity;
}