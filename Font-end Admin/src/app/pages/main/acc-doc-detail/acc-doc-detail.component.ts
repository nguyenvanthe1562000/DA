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
  }
}
