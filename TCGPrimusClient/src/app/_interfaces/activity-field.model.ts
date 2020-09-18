import { Activity } from './activity.model';
export interface ActivityField {
  Id: number;
  Name: string; 
  Label : string;
  DataType : string;
  Maxlength? : number;
  Minlength? : number;
  Required? : boolean;
  Activity: Activity
}