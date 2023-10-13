import { Component } from '@angular/core';
import { NgxSmartModalService } from 'ngx-smart-modal';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['../sign-styles.sass'],
})
export class SignInComponent {
  public resetModalIdentifier = 'resetModal';

  constructor(private modalService: NgxSmartModalService) {}

  openResetPasswordModal() {
    this.modalService.getModal(this.resetModalIdentifier).open();
  }
}
