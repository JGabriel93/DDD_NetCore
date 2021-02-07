import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ApiService } from 'src/service/api.service';
import { HistoricCurrentAccount } from 'src/model/historiccurrentaccount';

@Component({
  selector: 'app-historiccurrentaccount',
  templateUrl: './historiccurrentaccount.component.html',
  styleUrls: ['./historiccurrentaccount.component.scss']
})
export class HistoriccurrentaccountComponent implements OnInit {

  displayedColumns: string[] = ['movement', 'amountMoved', 'createAt'];
  dataSource: HistoricCurrentAccount[] = [];
  isLoadingResults = false;

  constructor(private router: Router, private route: ActivatedRoute, private api: ApiService) { }

  ngOnInit() {
    this.getHistoric(this.route.snapshot.params['id']);
  }

  getHistoric(id: any) {
    this.api.getHistoric(id)
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
