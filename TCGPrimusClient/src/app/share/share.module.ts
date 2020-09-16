import { SuccessModalComponent } from './../shared/modals/success-modal/success-modal.component';
import { ErrorModalComponent } from './../shared/modals/error-modal/error-modal.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  imports: [CommonModule],
  exports: [ErrorModalComponent,SuccessModalComponent],
  declarations: [ErrorModalComponent, SuccessModalComponent]
})
export class ShareModule {}
