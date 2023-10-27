import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { UserService } from 'src/app/core/services/user.service';
import { IResetPassword } from 'src/app/shared/models/user/reset-password';
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
  });

  private emailToReset: string;

  private validationErrorsFromBackend: string[] = [];

  constructor(
    private activatedRoute: ActivatedRoute,
    private userService: UserService,
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe((val: Params) => {
      this.emailToReset = val['email'];
    });
  }

  changePasswordValue(value: string) {
    this.resetForm.controls.password.setValue(value);
    this.resetForm.controls.password.markAsTouched();
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
        newPassword: this.resetForm.controls.password.value!,
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
