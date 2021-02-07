import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormControl, FormGroupDirective, FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ApiService } from 'src/service/api.service';

@Component({
  selector: 'app-currentaccount-payment',
  templateUrl: './currentaccount-payment.component.html',
  styleUrls: ['./currentaccount-payment.component.scss']
})
export class CurrentaccountPaymentComponent implements OnInit {
  userId: string = '';
  value: number = 0;
  barCode: string = '';
  paymentForm: FormGroup = new FormGroup({});
  isLoadingResults = false;

  constructor(private router: Router, private route: ActivatedRoute, private api: ApiService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.userId = this.route.snapshot.params['id'];
    this.paymentForm = this.formBuilder.group({
      'value': [null, [Validators.required, Validators.maxLength(8)]],
      'barCode': [null, [Validators.required, Validators.minLength(44), Validators.maxLength(47)]]
    });
  }

  addPayment(form: NgForm) {
    this.isLoadingResults = true;
    this.api.addPayment(this.userId, form)
      .subscribe(res => {
        this.isLoadingResults = false;
        this.router.navigate(['/currentaccount/', this.userId]);
      }, (err) => {
        console.log(err);
        this.isLoadingResults = false;
      });
  }
}
