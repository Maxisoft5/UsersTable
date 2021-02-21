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
    switch(value){
      case "id": {
          this.service.totalUsers.sort((a,b) => (a.id > b.id) ? 1 : -1);
          break;
      }
      case "colName": {
          this.service.totalUsers.sort((a,b) => (a.name > b.name) ? 1 : -1 );
          break;
      }
      case "colActive": {
          this.service.totalUsers.sort((a,b) => (a.isActive, b.isActive) ? 1 : -1);
          break;
      }
    }
  }

}
