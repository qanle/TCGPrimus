import { Component, OnInit } from '@angular/core';
import * as _ from 'lodash';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public homeText: string;


  constructor() { }

  ngOnInit() {
    this.homeText="WELCOM TO TCG PRIMUS";
    console.log(_.isEmpty({})); // returns true
  }

}
