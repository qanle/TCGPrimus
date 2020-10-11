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
import {ToastModule} from 'primeng/toast';

import { DynamicDialogModule } from 'primeng/dynamicdialog';
import { ConfigListDemo } from './designtimetlistdemo';
import { DesingTimesService } from './designtimesservice';

@NgModule({
  declarations: [TcgComponent, ConfigListDemo],
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
    ToastModule,
    DynamicDialogModule,
    TcgRoutingModule
  ],
	entryComponents: [
		ConfigListDemo
	],
  providers: [DesingTimesService]
})
export class TcgModule { }
