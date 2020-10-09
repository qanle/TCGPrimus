import { Component, OnInit } from '@angular/core';

@Component({
  //selector: 'tcg',
  templateUrl: './tcg.component.html',
  styleUrls: ['./tcg.component.scss']
})
export class TcgComponent implements OnInit {

  public homeText: string;
  constructor() { }

  ngOnInit() {
    this.homeText="WELCOM TO TCG PRIMUS";
  }

}
