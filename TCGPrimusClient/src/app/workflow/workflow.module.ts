
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from './../shared/shared.module';


import { WorkflowItemListComponent } from './workflow-item-list/workflow-item-list.component';



@NgModule({
  declarations: [
    WorkflowItemListComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: 'list', component: WorkflowItemListComponent },
    ]),
  ],
})
export class WorkflowModule {}
