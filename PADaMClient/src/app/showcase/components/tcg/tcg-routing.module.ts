import { NgModule } from '@angular/core';
import {RouterModule} from '@angular/router'
import {TcgComponent} from './tcg.component'

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild([
      {path:'',component: TcgComponent}
  ])
  ],
  exports: [
      RouterModule
  ]
})
export class TcgRoutingModule { }
