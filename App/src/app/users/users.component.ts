import { Component, OnInit } from '@angular/core';
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

  constructor(private _api: ApiService) { }

  ngOnInit(): void {
    this._api.getUsers()
      .subscribe(res => {
        this.dataSource = res;
        console.log(this.dataSource);
        this.isLoadingResults = false;
      }, err => {
        console.log(err);
        this.isLoadingResults = false;
      });
  }

}
