import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {TcgComponent} from './tcg.component';
import {TcgRoutingModule} from './tcg-routing.module';
import {AppCodeModule} from '../../app.code.component';
import {ButtonModule} from 'primeng/button';


@NgModule({
  declarations: [TcgComponent],
  imports: [
    CommonModule,
    AppCodeModule,
    ButtonModule,
    TcgRoutingModule
  ]
})
export class TcgModule { }
