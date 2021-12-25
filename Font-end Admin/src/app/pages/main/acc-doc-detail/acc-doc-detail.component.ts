import { Component, Injector, OnInit } from '@angular/core';
import { FormBuilder, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseComponent } from 'src/app/core/base-component';
import { Permision } from 'src/app/shared/models/Permision';

@Component({
  selector: 'app-acc-doc-detail',
  templateUrl: './acc-doc-detail.component.html',
  styleUrls: ['./acc-doc-detail.component.css']
})
export class AccDocDetailComponent extends BaseComponent implements OnInit {
  AccDocDetais: any;
  constructor(private fb: FormBuilder, injector: Injector, private route: ActivatedRoute, private router: Router) {
    super(injector);
  }
  IsFormAdd: boolean = false;
  Products:any;
  product: any;
  countries: any[];
  selectedCountry: any;

  ngOnInit(): void {
  
  
    if (this.route.snapshot.params.id) {  
      this.route.params.subscribe(params => {
        let id = params['id'];
        this._api.get(`/api/AccDoc/GetById/${id}`).takeUntil(this.unsubscribe).subscribe(res => {
          this.AccDocDetais = res;          
          setTimeout(() => {
            this.loadScripts();
          });
        });
      });
    
    }
    else  
    {
      this._api.get(`/api/SanPham/search-name`).takeUntil(this.unsubscribe).subscribe(res => {
        debugger;
        this.Products = res;          
      });
      this.IsFormAdd = true;
      this.AccDocDetais={};
      setTimeout(() => {
        this.loadScripts();
      });
    }
  }
   fieldArray: Array<any> = [];
   newAttribute: any = {};

  addFieldValue() {
    this.newAttribute.productId = this.product.maSanPham;
    this.newAttribute.quantity ;
      this.fieldArray.push(this.newAttribute)
      this.newAttribute = {};
      debugger;
  }

  deleteFieldValue(index) {
      this.fieldArray.splice(index, 1);
  }
  UpdateAmount()
  {
    this.newAttribute.amount = this.newAttribute.quantity * this.newAttribute.unitCost;
    debugger;
  }
  AddAccDoc(form)
  {
    console.log(form.value);
    console.log( JSON.stringify(this.fieldArray));
    
  }
  Add(form: NgForm)
  {
    console.log(form.value);
    console.log( JSON.stringify(this.fieldArray));
  }
}
