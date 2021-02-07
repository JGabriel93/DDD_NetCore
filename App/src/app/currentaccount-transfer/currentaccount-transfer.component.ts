import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormControl, FormGroupDirective, FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ApiService } from 'src/service/api.service';

@Component({
  selector: 'app-currentaccount-transfer',
  templateUrl: './currentaccount-transfer.component.html',
  styleUrls: ['./currentaccount-transfer.component.scss']
})
export class CurrentaccountTransferComponent implements OnInit {
  userId: string = '';
  value: number = 0;
  cpfRecipient: string = '';
  transferForm: FormGroup = new FormGroup({});
  isLoadingResults = false;

  constructor(private router: Router, private route: ActivatedRoute, private api: ApiService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.userId = this.route.snapshot.params['id'];
    this.transferForm = this.formBuilder.group({
      'value': [null, [Validators.required, Validators.maxLength(8)]],
      'cpfRecipient': [null, [Validators.required]]
    });
  }

  addTransfer(form: NgForm) {
    this.isLoadingResults = true;
    this.api.addTransfer(this.userId, form)
      .subscribe(res => {
        this.isLoadingResults = false;
        this.router.navigate(['/currentaccount/', this.userId]);
      }, (err) => {
        console.log(err);
        this.isLoadingResults = false;
      });
  }
}
