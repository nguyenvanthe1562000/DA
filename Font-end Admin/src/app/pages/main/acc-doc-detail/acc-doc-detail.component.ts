import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-acc-doc-detail',
  templateUrl: './acc-doc-detail.component.html',
  styleUrls: ['./acc-doc-detail.component.css']
})
export class AccDocDetailComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  private fieldArray: Array<any> = [];
  private newAttribute: any = {};

  addFieldValue() {
      this.fieldArray.push(this.newAttribute)
      this.newAttribute = {};
  }

  deleteFieldValue(index) {
      this.fieldArray.splice(index, 1);
  }
}
