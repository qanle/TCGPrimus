import { Component, OnInit, ViewChild } from "@angular/core";


import { Table } from "primeng/table";

import { MessageService } from "primeng/api";
import { ConfigListDemo } from "./designtimetlistdemo";
import { DesignTime } from "./designtimes";

import { DialogService } from "primeng/dynamicdialog";
import { DynamicDialogRef } from "primeng/dynamicdialog";

import {Extractor} from './extractors'
 import { ExtractorsService } from "./extractorsservice";

// import { Customer, Representative } from "../../domain/customer";
// import { CustomerService } from "../../service/customerservice";


@Component({
    //selector: 'tcg',
    templateUrl: "./tcg.component.html",
    styleUrls: ["./tcg.component.scss"],
    providers: [DialogService, MessageService],
})
export class TcgComponent implements OnInit {
    extractors: Extractor[];

    //representatives: Representative[];

    //statuses: any[];

    loading: boolean = true;

    @ViewChild("dt") table: Table;

    constructor(
        private extractorService: ExtractorsService,
        public dialogService: DialogService,
        public messageService: MessageService
    ) {}

    ref: DynamicDialogRef;
    show() {
        this.ref = this.dialogService.open(ConfigListDemo, {
            header: "Choose a Config",
            width: "70%",
            contentStyle: { "max-height": "500px", overflow: "auto" },
            baseZIndex: 10000,
        });

        this.ref.onClose.subscribe((designtime: DesignTime) => {
            if (designtime) {
                this.messageService.add({
                    severity: "info",
                    summary: "Config Selected",
                    detail: designtime.name,
                });
                this.showExtractors();
            }
        });
    }

    ngOnInit() {}

    ngOnDestroy() {
        if (this.ref) {
            this.ref.close();
        }
    }
    showExtractors() {
        this.extractorService.getExtractor().then((extractors) => {
            this.extractors = extractors;
            console.log(this.extractors);
            this.loading = false;
        });
        // this.representatives = [
        //     { name: "Amy Elsner", image: "amyelsner.png" },
        //     { name: "Anna Fali", image: "annafali.png" },
        //     { name: "Asiya Javayant", image: "asiyajavayant.png" },
        //     { name: "Bernardo Dominic", image: "bernardodominic.png" },
        //     { name: "Elwin Sharvill", image: "elwinsharvill.png" },
        //     { name: "Ioni Bowcher", image: "ionibowcher.png" },
        //     { name: "Ivan Magalhaes", image: "ivanmagalhaes.png" },
        //     { name: "Onyama Limba", image: "onyamalimba.png" },
        //     { name: "Stephen Shaw", image: "stephenshaw.png" },
        //     { name: "XuXue Feng", image: "xuxuefeng.png" },
        // ];

        // this.statuses = [
        //     { label: "Unqualified", value: "unqualified" },
        //     { label: "Qualified", value: "qualified" },
        //     { label: "New", value: "new" },
        //     { label: "Negotiation", value: "negotiation" },
        //     { label: "Renewal", value: "renewal" },
        //     { label: "Proposal", value: "proposal" },
        // ];
    }

    onActivityChange(event) {
        const value = event.target.value;
        if (value && value.trim().length) {
            const activity = parseInt(value);

            if (!isNaN(activity)) {
                this.table.filter(activity, "activity", "gte");
            }
        }
    }

    onDateSelect(value) {
        this.table.filter(this.formatDate(value), "date", "equals");
    }

    formatDate(date) {
        let month = date.getMonth() + 1;
        let day = date.getDate();

        if (month < 10) {
            month = "0" + month;
        }

        if (day < 10) {
            day = "0" + day;
        }

        return date.getFullYear() + "-" + month + "-" + day;
    }

    onRepresentativeChange(event) {
        this.table.filter(event.value, "representative", "in");
    }
}
