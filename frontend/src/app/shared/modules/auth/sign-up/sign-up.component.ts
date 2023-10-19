import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';
import { IUserRegister } from 'src/app/shared/models/user/user-register';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['../sign-styles.sass'],
})
export class SignUpComponent {
  signUpForm = new FormGroup({
    email: new FormControl(''),
    username: new FormControl(''),
    password: new FormControl(''),
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
