import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { AuthService } from 'src/app/core/services/auth.service';
import { IUserLogin } from 'src/app/shared/models/user/user-login';
import { passwordMaxLength, passwordMinLength } from 'src/app/shared/utils/validation/constants';
import { noSpacesRegex, passwordRegex } from 'src/app/shared/utils/validation/regex-patterns';
import { getValidationErrors } from 'src/app/shared/utils/validation/validation-helper';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['../sign-styles.sass', '../../../../../styles/modal.sass'],
})
export class SignInComponent {
  signInForm = new FormGroup({
    emailOrUserName: new FormControl('', [
      Validators.required,
      Validators.pattern(noSpacesRegex),
    ]),
    password: new FormControl('', [
      Validators.required,
      Validators.pattern(passwordRegex),
      Validators.minLength(passwordMinLength),
      Validators.maxLength(passwordMaxLength),
    ]),
  });

  private resetModalIdentifier = 'resetModal';

  private validationErrorsFromBackend: string[] = [];

  constructor(
    private modalService: NgxSmartModalService,
    private authService: AuthService,
    private router: Router,
  ) {}

  changeInputValue(
    formControlName: 'emailOrUserName' | 'password',
    value: string,
  ) {
    this.signInForm.controls[formControlName].setValue(value);
    this.signInForm.controls[formControlName].markAsTouched();
  }

  openResetPasswordModal() {
    this.modalService.open(this.resetModalIdentifier);
  }

  getSignInValidationError() {
    return [
      ...getValidationErrors(this.signInForm),
      ...this.validationErrorsFromBackend,
    ].length > 0
      ? 'Invalid username of password'
      : undefined;
  }

  login() {
    if (this.signInForm.valid) {
      const userLogin: IUserLogin = {
        emailOrUserName: this.signInForm.controls.emailOrUserName.value!,
        password: this.signInForm.controls.password.value!,
      };

      this.authService.login(userLogin).subscribe(
        () => {
          this.router.navigate(['/chats']);
        },
        (errors: string[]) => {
          this.validationErrorsFromBackend = errors;
        },
      );
    }
  }
}
