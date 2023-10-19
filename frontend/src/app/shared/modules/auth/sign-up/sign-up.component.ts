import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';
import { IUserRegister } from 'src/app/shared/models/user/user-register';
import { emailRegex, noSpacesRegex, passwordRegex } from 'src/app/shared/utils/validation/regex-patterns';
import { getValidationErrors } from 'src/app/shared/utils/validation/validation-helper';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['../sign-styles.sass'],
})
export class SignUpComponent {
  signUpForm = new FormGroup({
    email: new FormControl('', [
      Validators.required,
      Validators.pattern(emailRegex),
    ]),
    username: new FormControl('', [
      Validators.required,
      Validators.pattern(noSpacesRegex),
    ]),
    password: new FormControl('', [
      Validators.required,
      Validators.pattern(passwordRegex),
    ]),
  });

  constructor(
    private authService: AuthService,
    private router: Router,
  ) {}

  changeInputValue(
    formControlName: 'email' | 'username' | 'password',
    value: string,
  ) {
    this.signUpForm.controls[formControlName].setValue(value);
    this.signUpForm.controls[formControlName].markAsTouched();
  }

  getValidationErrors() {
    return getValidationErrors(this.signUpForm);
  }

  register() {
    const registerUser: IUserRegister = {
      email: this.signUpForm.controls.email.value!,
      userName: this.signUpForm.controls.username.value!,
      password: this.signUpForm.controls.password.value!,
    };

    this.authService.register(registerUser).subscribe(() => {
      this.router.navigateByUrl('/chats');
    });
  }
}
