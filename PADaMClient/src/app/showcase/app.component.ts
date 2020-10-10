import { Component, OnInit, OnDestroy } from "@angular/core";
import { Router, NavigationEnd } from "@angular/router";
import { AppConfigService } from "./service/appconfigservice";
import { AppConfig } from "./domain/appconfig";
import { Subscription } from "rxjs";
import { PrimeNGConfig } from "primeng/api";

import { LoaderService } from "src/app/core/services/loader.service";
import { SessionService } from "src/app/core/services/session.service";
import { TranslateService } from "@ngx-translate/core";
import { ThemeService } from "src/app/core/services/theme.service";

declare let gtag: Function;

@Component({
    selector: "app-root",
    templateUrl: "./app.component.html",
    styleUrls: ["./app.component.css"],
})
export class AppComponent implements OnInit, OnDestroy {
    menuActive: boolean;

    newsActive: boolean = true;

    config: AppConfig;

    title = "TCG-Prime PADaM";
    showLoader: boolean;
    theme: string;

    public subscription: Subscription;

    constructor(
        private router: Router,
        private configService: AppConfigService,
        private primengConfig: PrimeNGConfig,
        private loaderService: LoaderService,
        private themeService: ThemeService,
        private sessionService: SessionService,
        translate: TranslateService
    ) {
        var theme = this.sessionService.getItem("selected-theme");
        if (theme != null && theme.length > 0) {
            this.theme = theme;
            this.themeService.selectTheme(theme);
        } else {
            this.theme = "theme-teal";
        }

        // this language will be used as a fallback when a translation isn't found in the current language
        translate.setDefaultLang("en");
        var language = this.sessionService.getItem("ng-prime-language");
        if (language != null && language.length > 0) {
            // the lang to use, if the lang isn't available, it will use the current loader to get them
            translate.use(language);
        } else {
            this.sessionService.setItem("ng-prime-language", "en");
        }
    }

    ngOnInit() {
        this.primengConfig.ripple = true;
        this.config = this.configService.config;
        this.subscription = this.configService.configUpdate$.subscribe(
            (config) => (this.config = config)
        );

        this.router.events.subscribe((event) => {
            if (event instanceof NavigationEnd) {
                gtag("config", "UA-93461466-1", {
                    page_path: "/primeng" + event.urlAfterRedirects,
                });

                this.hideMenu();
            }
        });

        this.newsActive =
            this.newsActive &&
            sessionStorage.getItem("primenews-hidden") == null;

        this.loaderService.status.subscribe((val: boolean) => {
            this.showLoader = val;
        });

        this.themeService.theme.subscribe((val: string) => {
            this.theme = val;
        });
    }

    onMenuButtonClick() {
        this.menuActive = true;
        this.addClass(document.body, "blocked-scroll");
    }

    onMaskClick() {
        this.hideMenu();
    }

    hideMenu() {
        this.menuActive = false;
        this.removeClass(document.body, "blocked-scroll");
    }

    addClass(element: any, className: string) {
        if (element.classList) element.classList.add(className);
        else element.className += " " + className;
    }

    removeClass(element: any, className: string) {
        if (element.classList) element.classList.remove(className);
        else
            element.className = element.className.replace(
                new RegExp(
                    "(^|\\b)" + className.split(" ").join("|") + "(\\b|$)",
                    "gi"
                ),
                " "
            );
    }

    hideNews() {
        this.newsActive = false;
        sessionStorage.setItem("primenews-hidden", "true");
    }

    ngOnDestroy() {
        if (this.subscription) {
            this.subscription.unsubscribe();
        }
        this.themeService.theme.observers.forEach(function (element) {
            element.complete();
        });
        this.loaderService.status.observers.forEach(function (element) {
            element.complete();
        });
    }
}
