import { Folder } from './folder.model';
import {Content} from './content.model';
import {Activity} from './activity.model'
export interface workflow {
  Id: number;
  Name: string;
  ActivitySettings: string;
  Folder: Folder;
  Content: Content;
  Activity: Activity;
}