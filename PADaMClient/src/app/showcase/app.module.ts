
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { LocationStrategy, HashLocationStrategy } from "@angular/common";
import { AppRoutingModule } from "./app-routing.module";
import { AuthGuard } from "src/app/core/gaurds/auth.gaurd";
import { MessageService } from "primeng/api";

import { AppComponent } from "./app.component";
import { HomeComponent } from "./components/home/home.component";
import { ButtonModule } from "primeng/button";
import { TooltipModule } from "primeng/tooltip";
import { RadioButtonModule } from "primeng/radiobutton";
import { InputSwitchModule } from "primeng/inputswitch";

import { CarService } from "./service/carservice";
import { CountryService } from "./service/countryservice";
import { EventService } from "./service/eventservice";
import { NodeService } from "./service/nodeservice";

import { IconService } from "./service/iconservice";
import { CustomerService } from "./service/customerservice";
import { PhotoService } from "./service/photoservice";
import { VersionService } from "./service/versionservice";
import { AppConfigService } from "./service/appconfigservice";
import { ProductService } from "./service/productservice";

import { CustomMinDirective } from './../core/validators/custom-min-validator.directive';
import { CustomMaxDirective } from './../core/validators/custom-max-validator.directive';
import { AppNewsComponent } from './app.news.component';
import { AppTopBarComponent } from "./app.topbar.component";
import { AppMenuComponent } from "./app.menu.component";
import { AppConfigComponent } from "./app.config.component";
import { AppFooterComponent } from "./app.footer.component";
import { AppInputStyleSwitchModule } from "./app.inputstyleswitch.component";
//import { LoginComponent } from './components/login/login.component';
import { TranslateModule, TranslateLoader } from "@ngx-translate/core";
import { TranslateHttpLoader } from "@ngx-translate/http-loader";
import { HttpClientModule, HttpClient } from "@angular/common/http";

//import { UserIdleModule } from "angular-user-idle";
import { BrowserModule } from "@angular/platform-browser";
//import { AppCommonModule } from 'src/app/app.common.module';

export function HttpLoaderFactory(http: HttpClient) {
    return new TranslateHttpLoader(http);
}
@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        AppNewsComponent,
        AppTopBarComponent,
        AppMenuComponent,
        AppConfigComponent,
        AppFooterComponent,
        CustomMaxDirective,
        CustomMinDirective
        //LoginComponent
    ],
    imports: [
        FormsModule,
        ReactiveFormsModule,
        AppRoutingModule,
        HttpClientModule,
        BrowserAnimationsModule,
        ButtonModule,
        RadioButtonModule,
        InputSwitchModule,
        TooltipModule,
        AppInputStyleSwitchModule,
        BrowserModule,
        BrowserAnimationsModule,
        AppRoutingModule,
        //UserIdleModule.forRoot({ idle: 300, timeout: 1, ping: null }),
        HttpClientModule,
        //AppCommonModule,
        TranslateModule.forRoot({
            loader: {
                provide: TranslateLoader,
                useFactory: HttpLoaderFactory,
                deps: [HttpClient],
            },
        }),
    ],
    providers: [
        MessageService,
        AuthGuard,
        { provide: LocationStrategy, useClass: HashLocationStrategy },
        CarService,
        CountryService,
        EventService,
        NodeService,
        IconService,
        CustomerService,
        PhotoService,
        VersionService,
        AppConfigService,
        ProductService,
    ],
    bootstrap: [AppComponent],
})
export class AppModule {}
