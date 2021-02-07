import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ApiService } from 'src/service/api.service';
import { User } from 'src/model/user';

@Component({
  selector: 'app-users-detail',
  templateUrl: './users-detail.component.html',
  styleUrls: ['./users-detail.component.scss']
})
export class UsersDetailComponent implements OnInit {
  user: User = { id: '', name: '', email: '', cpf: '' };
  isLoadingResults = true;

  constructor(private router: Router, private route: ActivatedRoute, private api: ApiService) { }

  ngOnInit() {
    this.getUser(this.route.snapshot.params['id']);
  }

  getUser(id: any) {
    this.api.getUser(id)
      .subscribe(data => {
        this.user = data;
        console.log(this.user);
        this.isLoadingResults = false;
      });
  }

  deleteUser(id: any) {
    this.isLoadingResults = true;
    this.api.deleteUser(id)
      .subscribe(res => {
        this.isLoadingResults = false;
        this.router.navigate(['/users']);
      }, (err) => {
        console.log(err);
        this.isLoadingResults = false;
      }
      );
  }
}
