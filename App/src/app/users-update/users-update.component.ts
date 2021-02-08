import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormControl, FormGroupDirective, FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ApiService } from 'src/service/api.service';

@Component({
  selector: 'app-users-update',
  templateUrl: './users-update.component.html',
  styleUrls: ['./users-update.component.scss']
})
export class UsersUpdateComponent implements OnInit {
  id: String = '';
  userForm: FormGroup = new FormGroup({});
  name: String = '';
  email: String = '';
  cpf: String = '';
  password: String = '';
  isLoadingResults = false;

  constructor(private router: Router, private route: ActivatedRoute, private api: ApiService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.getUser(this.route.snapshot.params['id']);
    this.userForm = this.formBuilder.group({
      'name': [null, Validators.required],
      'email': [null, Validators.required],
      'cpf': [null, Validators.required],
      'password': [null, Validators.required]
    });
  }

  getUser(id: any) {
    this.api.getUser(id).subscribe(data => {
      this.id = data.id;
      this.userForm.setValue({
        name: data.name,
        email: data.email,
        cpf: data.cpf,
        password: ''
      });
    });
  }

  updateUser(form: NgForm) {
    this.isLoadingResults = true;
    this.api.updateUser(this.id, form)
      .subscribe(res => {
        this.isLoadingResults = false;
        this.router.navigate(['/users-detail/' + this.id]);
      }, (err) => {
        console.log(err);
        this.isLoadingResults = false;
      });
  }
}
