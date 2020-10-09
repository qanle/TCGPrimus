import {Component} from '@angular/core';

@Component({
    selector: 'app-footer',
    template: `
        <div class="layout-footer">
            <div class="layout-footer-left">
                <span>TCG Primus 2020.1 by </span>
                <a href="https://www.tcgprocess.com/">tcgprocess</a>
            </div>
        </div>
    `
})
export class AppFooterComponent {
}