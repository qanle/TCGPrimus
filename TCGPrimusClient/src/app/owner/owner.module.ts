
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { OwnerListComponent } from './owner-list/owner-list.component';
import { OwnerDetailsComponent } from './owner-details/owner-details.component';

import { ShareModule } from './../share/share.module';

@NgModule({
  imports: [
    CommonModule,
    ShareModule,
    RouterModule.forChild([
      { path: 'list', component: OwnerListComponent },
      { path: 'details/:id', component: OwnerDetailsComponent }
    ]),
  ],
  declarations: [
    OwnerListComponent, 
    OwnerDetailsComponent
  ],
})
export class OwnerModule {}