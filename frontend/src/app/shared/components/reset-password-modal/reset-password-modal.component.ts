import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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

  constructor(private userService: UserService) {}

  changeEmailValue(value: string) {
    this.resetPasswordForm.controls.email.setValue(value);
    this.resetPasswordForm.controls.email.markAsTouched();
  }

  getResetPasswordValidationErrors() {
    return getValidationErrors(this.resetPasswordForm);
  }

  sendResetPasswordEmail() {
    if (this.resetPasswordForm.valid) {
      const resetEmail: IResetEmail = {
        email: this.resetPasswordForm.controls.email.value!,
      };

      this.userService.sendResetPasswordEmail(resetEmail).subscribe();
    }
  }
}
