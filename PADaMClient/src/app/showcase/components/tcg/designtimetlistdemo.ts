import {Component} from '@angular/core';
import {DesignTime} from './designtimes';
import {DesingTimesService} from './designtimesservice';
import {DynamicDialogRef} from 'primeng/dynamicdialog';
import {DynamicDialogConfig} from 'primeng/dynamicdialog';

@Component({
    template: `
        <p-table [value]="designtimes" [paginator]="true" [rows]="5" [responsive]="true">
            <ng-template pTemplate="header">
                <tr>
                    <th pSortableColumn="name">Name <p-sortIcon field="vin"></p-sortIcon></th>
                    <th style="width:4em"></th>
                </tr>
            </ng-template>
            <ng-template pTemplate="body" let-config>
                <tr>
                    <td>{{config.name}}</td>
                    <td>
                        <button type="button" pButton icon="pi pi-search" (click)="selectConfig(config)"></button>
                    </td>
                </tr>
            </ng-template>
        </p-table>
    `
})
export class ConfigListDemo {

    designtimes: DesignTime[];
            
    constructor(private desingTimesService: DesingTimesService, public ref: DynamicDialogRef, public config: DynamicDialogConfig) { }

    ngOnInit() {
        this.desingTimesService.getDesignTime().then(designtimes => this.designtimes = designtimes);
    }

    selectConfig(designtime: DesignTime) {
        this.ref.close(designtime);
    }
}