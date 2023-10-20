import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { AuthService } from 'src/app/core/services/auth.service';
import { IUserLogin } from 'src/app/shared/models/user/user-login';
import {
  emailRegex,
  noSpacesRegex,
  passwordRegex,
} from 'src/app/shared/utils/validation/regex-patterns';
import { getValidationErrors } from 'src/app/shared/utils/validation/validation-helper';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['../sign-styles.sass'],
})
export class SignInComponent {
  resetModalIdentifier = 'resetModal';

  signInForm = new FormGroup({
    emailOrUsername: new FormControl('', [
      Validators.required,
      Validators.pattern(noSpacesRegex),
    ]),
    password: new FormControl('', [
      Validators.required,
      Validators.pattern(passwordRegex),
    ]),
  });

  resetPasswordForm = new FormGroup({
    email: new FormControl('', [
      Validators.required,
      Validators.pattern(emailRegex),
    ]),
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

  changeEmailValue(value: string) {
    this.resetPasswordForm.controls.email.setValue(value);
    this.resetPasswordForm.controls.email.markAsTouched();
  }

  openResetPasswordModal() {
    this.modalService.getModal(this.resetModalIdentifier).open();
  }

  getSignInValidationError() {
    return getValidationErrors(this.signInForm).length > 0
      ? 'Invalid username of password'
      : undefined;
  }

  getResetPasswordValidationErrors() {
    return getValidationErrors(this.resetPasswordForm);
  }

  login() {
    if (this.signInForm.valid) {
      const userLogin: IUserLogin = {
        emailOrUserName: this.signInForm.controls.emailOrUsername.value!,
        password: this.signInForm.controls.password.value!,
      };

      this.authService.login(userLogin).subscribe(() => {
        this.router.navigate(['/chats']);
      });
    }
  }
}
