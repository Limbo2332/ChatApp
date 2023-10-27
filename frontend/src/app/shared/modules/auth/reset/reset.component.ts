import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { UserService } from 'src/app/core/services/user.service';
import { IResetPassword } from 'src/app/shared/models/user/reset-password';
import { comparePasswordsValidator } from 'src/app/shared/utils/validation/confirm-password';
import { passwordMaxLength, passwordMinLength } from 'src/app/shared/utils/validation/constants';
import { passwordRegex } from 'src/app/shared/utils/validation/regex-patterns';
import { getValidationErrors } from 'src/app/shared/utils/validation/validation-helper';

@Component({
  selector: 'app-reset',
  templateUrl: './reset.component.html',
  styleUrls: ['../sign-styles.sass', '../../../../../styles/modal.sass'],
})
export class ResetComponent implements OnInit {
  resetForm = new FormGroup({
    password: new FormControl('', [
      Validators.required,
      Validators.pattern(passwordRegex),
      Validators.minLength(passwordMinLength),
      Validators.maxLength(passwordMaxLength),
    ]),
    confirmPassword: new FormControl('', [
      Validators.required,
      Validators.pattern(passwordRegex),
      Validators.minLength(passwordMinLength),
      Validators.maxLength(passwordMaxLength),
      comparePasswordsValidator(),
    ]),
  });

  private emailToReset: string;

  private emailToken: string;

  private validationErrorsFromBackend: string[] = [];

  constructor(
    private activatedRoute: ActivatedRoute,
    private userService: UserService,
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe((val: Params) => {
      this.emailToReset = val['email'];
      this.emailToken = val['code'];
    });
  }

  changeInputValue(controlName: 'password' | 'confirmPassword', value: string) {
    this.resetForm.controls[controlName].setValue(value);
    this.resetForm.controls[controlName].markAsTouched();
  }

  getValidationErrors() {
    return [
      ...getValidationErrors(this.resetForm),
      ...this.validationErrorsFromBackend,
    ].slice(0, 2);
  }

  resetPassword() {
    if (this.resetForm.valid) {
      const resetPassword: IResetPassword = {
        email: this.emailToReset,
        emailToken: this.emailToken,
        newPassword: this.resetForm.controls.password.value!,
        confirmPassword: this.resetForm.controls.confirmPassword.value!,
      };

      this.userService.resetPassword(resetPassword).subscribe(
        () => {
          this.router.navigate(['auth', 'login']);
        },
        (errors: string[]) => {
          this.validationErrorsFromBackend = errors;
        },
      );
    }
  }
}
