import { ReactiveFormsModule } from '@angular/forms';
import { Account } from './account.model';
export interface Owner {
  Id: string;
  Name: string;
  DateOfBirth: Date;
  Address: string;
  Accounts?: Account[];
}