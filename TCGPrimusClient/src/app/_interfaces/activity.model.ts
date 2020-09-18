import { ActivityField } from './activity-field.model';
export interface Activity {
  Id: number;
  Name: string;
  ActivityFields?: ActivityField[];
}