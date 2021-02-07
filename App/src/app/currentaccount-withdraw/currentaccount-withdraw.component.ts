import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormControl, FormGroupDirective, FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ApiService } from 'src/service/api.service';

@Component({
  selector: 'app-currentaccount-withdraw',
  templateUrl: './currentaccount-withdraw.component.html',
  styleUrls: ['./currentaccount-withdraw.component.scss']
})
export class CurrentaccountWithdrawComponent implements OnInit {
  userId: string = '';
  value: number = 0;
  withDrawForm: FormGroup = new FormGroup({});
  isLoadingResults = false;

  constructor(private router: Router, private route: ActivatedRoute, private api: ApiService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.userId = this.route.snapshot.params['id'];
    this.withDrawForm = this.formBuilder.group({
      'value': [null, [Validators.required, Validators.maxLength(8)]]
    });
  }

  addWithdraw(form: NgForm) {
    this.isLoadingResults = true;
    this.api.addWithdraw(this.userId, form)
      .subscribe(res => {
        this.isLoadingResults = false;
        this.router.navigate(['/currentaccount/', this.userId]);
      }, (err) => {
        console.log(err);
        this.isLoadingResults = false;
      });
  }

}
