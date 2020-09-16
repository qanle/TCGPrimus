import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule } from '@angular/common/http';

import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';


import { HomeComponent } from './home/home.component';
import { MenuComponent } from './menu/menu.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { InternalServerComponent } from './error-pages/internal-server/internal-server.component';
//import { ErrorModalComponent } from './shared/modals/error-modal/error-modal.component';
//import { SuccessModalComponent } from './shared/modals/success-modal/success-modal.component';
import { DatepickerDirective } from './shared/directives/datepicker.directive';
import { DatePipe } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MenuComponent,
    NotFoundComponent,
    InternalServerComponent,
    //ErrorModalComponent,
    //uccessModalComponent,
    DatepickerDirective,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent },
      {
        path: 'owner',
        loadChildren: () =>
          import('./owner/owner.module').then((m) => m.OwnerModule),
      },
      { path: '404', component: NotFoundComponent },
      { path: '500', component: InternalServerComponent },
      { path: '500', component: InternalServerComponent },
      { path: '', redirectTo: '/home', pathMatch: 'full' },
      { path: '**', redirectTo: '/404', pathMatch: 'full' },
    ]),
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent],
})
export class AppModule {}
