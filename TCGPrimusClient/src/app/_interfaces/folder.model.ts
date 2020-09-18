import { Workflow } from './workflow.model';
export interface Folder {
  Id: number;
  Name: string;
  Workflow: Workflow;
}