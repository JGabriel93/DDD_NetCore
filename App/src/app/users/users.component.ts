import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ApiService } from 'src/service/api.service';
import { User } from 'src/model/user';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})

export class UsersComponent implements OnInit {
  displayedColumns: string[] = ['balance', 'historic', 'name', 'email', 'cpf', 'detail'];
  dataSource: User[] = [];
  isLoadingResults = false;

  constructor(private router: Router, private route: ActivatedRoute, private api: ApiService) { }

  ngOnInit(): void {
    this.api.getUsers()
      .subscribe(res => {
        this.dataSource = res;
        console.log(this.dataSource);
        this.isLoadingResults = false;
      }, err => {
        console.log(err);
        this.isLoadingResults = false;
      });
  }

  addApplyIncome() {
    this.isLoadingResults = true;
    this.api.addApplyIncome()
      .subscribe(res => {
        this.isLoadingResults = false;
        this.router.navigate(['/users']);
      }, (err) => {
        console.log(err);
        this.isLoadingResults = false;
      });
  }

}
