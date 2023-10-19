import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { AuthService } from 'src/app/core/services/auth.service';
import { IUserLogin } from 'src/app/shared/models/user/user-login';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['../sign-styles.sass'],
})
export class SignInComponent {
  resetModalIdentifier = 'resetModal';

  signInForm = new FormGroup({
    emailOrUsername: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(
    private modalService: NgxSmartModalService,
    private authService: AuthService,
    private router: Router,
  ) {}

  changeInputValue(
    formControlName: 'emailOrUsername' | 'password',
    value: string,
  ) {
    this.signInForm.controls[formControlName].setValue(value);
    this.signInForm.controls[formControlName].markAsTouched();
  }

  openResetPasswordModal() {
    this.modalService.getModal(this.resetModalIdentifier).open();
  }

  login() {
    const userLogin: IUserLogin = {
      emailOrUserName: this.signInForm.controls.emailOrUsername.value!,
      password: this.signInForm.controls.password.value!,
    };

    this.authService.login(userLogin).subscribe(() => {
      this.router.navigate(['/chats']);
    });
  }
}
