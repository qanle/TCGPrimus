import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {LoginComponent} from './login.component';
import {LoginRoutingModule} from './login-routing.module';
import {AppCodeModule} from '../../app.code.component';
import {ButtonModule} from 'primeng/button';

@NgModule({
  declarations: [LoginComponent],
  imports: [
    CommonModule,
    AppCodeModule,
    ButtonModule,
    LoginRoutingModule,
    
  ]
})
export class LoginModule { }
