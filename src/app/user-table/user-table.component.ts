import { Component, OnInit } from '@angular/core';
import { UserDetailsService } from 'src/app/shared/user-detail-services';

@Component({
  selector: 'app-user-table',
  templateUrl: './user-table.component.html',
  styleUrls: ['./user-table.component.css'],
  providers: [UserDetailsService]
})

export class UserTableComponent implements OnInit {

  constructor(public service: UserDetailsService) {}

  ngOnInit(): void {
      this.service.getUsers();
  }

  OrderBy(value:string){

    this.service.totalUsers.sort((a,b) => (a[value] > b[value] ? 1 : -1));

  }

}
