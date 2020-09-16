
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms'


import { ShareModule } from './../share/share.module';

import { OwnerListComponent } from './owner-list/owner-list.component';
import { OwnerDetailsComponent } from './owner-details/owner-details.component';
import { OwnerCreateComponent } from './owner-create/owner-create.component';
import { OwnerUpdateComponent } from './owner-update/owner-update.component';
import { OwnerDeleteComponent } from './owner-delete/owner-delete.component';

@NgModule({
  imports: [
    CommonModule,
    ShareModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: 'list', component: OwnerListComponent },
      { path: 'details/:id', component: OwnerDetailsComponent },
      { path: 'create', component: OwnerCreateComponent },
      { path: 'update/:id', component: OwnerUpdateComponent },
      { path: 'delete/:id', component: OwnerDeleteComponent }
    ]),
  ],
  declarations: [
    OwnerListComponent,
    OwnerDetailsComponent,
    OwnerCreateComponent,
    OwnerUpdateComponent,
    OwnerDeleteComponent,
  ],
})
export class OwnerModule {}