import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ApiService } from 'src/service/api.service';
import { CurrentAccount } from 'src/model/currentaccount';
import { User } from 'src/model/user';

@Component({
  selector: 'app-currentaccount',
  templateUrl: './currentaccount.component.html',
  styleUrls: ['./currentaccount.component.scss']
})
export class CurrentaccountComponent implements OnInit {
  currentAccount: CurrentAccount = { id: '', balance: 0, createAt: new Date, updateAt: new Date, userId: '' };
  user: User = { id: '', name: '', email: '', cpf: '' };
  isLoadingResults = true;

  constructor(private router: Router, private route: ActivatedRoute, private api: ApiService) { }

  ngOnInit(): void {
    this.getUser(this.route.snapshot.params['id']);
    this.getCurrentAccount(this.route.snapshot.params['id']);
  }

  getUser(id: any) {
    this.api.getUser(id)
      .subscribe(data => {
        this.user = data;
        console.log(this.user);
        this.isLoadingResults = false;
      });
  }

  getCurrentAccount(id: any) {
    this.api.getCurrentAccount(id)
      .subscribe(data => {
        this.currentAccount = data;
        console.log(this.currentAccount);
        this.isLoadingResults = false;
      });
  }
}
