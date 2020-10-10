import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {TcgComponent} from './tcg.component';
import {TcgRoutingModule} from './tcg-routing.module';
import {AppCodeModule} from '../../app.code.component';
import {ButtonModule} from 'primeng/button';
import { TableModule } from 'primeng/table';
import { MultiSelectModule } from 'primeng/multiselect';
import { CalendarModule } from 'primeng/calendar';
import { DropdownModule } from 'primeng/dropdown';

import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { ProgressBarModule } from 'primeng/progressbar';

@NgModule({
  declarations: [TcgComponent],
  imports: [
    CommonModule,
    AppCodeModule,
    ButtonModule,
    TableModule,
    MultiSelectModule,
    CalendarModule,
    DropdownModule,
    ProgressBarModule,
    InputTextModule,
    InputNumberModule,
    TcgRoutingModule
  ]
})
export class TcgModule { }
