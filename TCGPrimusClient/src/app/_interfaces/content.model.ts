import { Folder } from './folder.model';
export interface Content {
  Id: number;
  Name: string;
  Folder: Folder;
}