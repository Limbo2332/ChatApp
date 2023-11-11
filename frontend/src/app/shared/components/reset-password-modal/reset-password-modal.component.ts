import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { finalize } from 'rxjs';
import { UserService } from 'src/app/core/services/user.service';

import { IResetEmail } from '../../models/mail/reset-email';
import { emailMaxLength, emailMinLength } from '../../utils/validation/constants';
import { emailRegex } from '../../utils/validation/regex-patterns';
import { getValidationErrors } from '../../utils/validation/validation-helper';

@Component({
  selector: 'app-reset-password-modal',
  templateUrl: './reset-password-modal.component.html',
  styleUrls: ['../../../../styles/modal.sass'],
})
export class ResetPasswordModalComponent {
  resetModalIdentifier = 'resetModal';

  resetPasswordForm = new FormGroup({
    email: new FormControl('', [
      Validators.required,
      Validators.pattern(emailRegex),
      Validators.minLength(emailMinLength),
      Validators.maxLength(emailMaxLength),
    ]),
  });

  constructor(
    private userService: UserService,
    private toastrService: ToastrService,
    private modalService: NgxSmartModalService,
    private spinner: NgxSpinnerService,
  ) {}

  changeEmailValue(value: string) {
    this.resetPasswordForm.controls.email.setValue(value);
    this.resetPasswordForm.controls.email.markAsTouched();
  }

  getResetPasswordValidationErrors() {
    return getValidationErrors(this.resetPasswordForm);
  }

  sendResetPasswordEmail() {
    if (this.resetPasswordForm.valid) {
      this.spinner.show();

      const resetEmail: IResetEmail = {
        email: this.resetPasswordForm.controls.email.value!,
      };

      this.userService
        .sendResetPasswordEmail(resetEmail)
        .pipe(
          finalize(() => {
            this.spinner.hide();
          }),
        )
        .subscribe(
          () => {
            this.toastrService.success(
              'Email to reset password was successfully sent!',
            );
            this.modalService.get(this.resetModalIdentifier).close();
          },
          () => {
            this.toastrService.error('Something went wrong. Try again later');
          },
        );
    }
  }
}
