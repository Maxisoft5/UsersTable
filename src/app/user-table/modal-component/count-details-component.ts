import { Component } from '@angular/core';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { UserDetailsService } from 'src/app/shared/user-detail-services';

@Component({
  selector: 'user-count-content',
  template: `
    <div class="modal-header">
      <h4 class="modal-title">Popuv header</h4>
    </div>
    <div class="modal-body">
      <p>Total count: {{usersCount}}</p>
      <p>Active count: {{activeUsers}}</p>
    </div>
    <div class="modal-footer">
      <button type="button" class="btn btn-outline-dark" (click)="activeModal.close('Close click')">Close</button>
    </div>
  `,
  styleUrls: ['./count-details-component.css']
})

export class NgbdModalContent {
  activeUsers: number;
  usersCount: number;
  constructor(public activeModal: NgbActiveModal, public service: UserDetailsService) {
    this.activeUsers = 0;
    this.usersCount = 0;
    this.service.getUsers().then(res => this.usersCount = res.length);
    this.service.getActiveUsers().then(res => this.activeUsers = Number(res));
  }
}

@Component({
  selector: 'user-count-component',
  templateUrl: './count-details-component.html',
  styleUrls: ['./count-details-component.css']
})

export class NgbdModalComponent {

  activeUsers: number;
  usersCount: number;

    constructor(private modalService: NgbModal, public service: UserDetailsService) {
      this.activeUsers = 0;
      this.usersCount = 0;
      this.service.getActiveUsers().then(res => this.activeUsers = Number(res));
      this.service.getUsers().then(res => this.usersCount = res.length);
    }
    
    open() {
      const modalRef = this.modalService.open(NgbdModalContent);
      modalRef.componentInstance.totalCount = this.usersCount;
      modalRef.componentInstance.activeCount = this.activeUsers;
    }
}
