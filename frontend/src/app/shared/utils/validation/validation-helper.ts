import { FormGroup } from '@angular/forms';

import { ValidationErrorsMessages } from './validation-error';
import {
  emailOrUsernameValidationErrors,
  emailValidationErrors,
  passwordValidationErrors,
  usernameValidationErrors,
} from './validation-error-messages';

const controlErrorMessagesMap: { [key: string]: ValidationErrorsMessages } = {
  email: emailValidationErrors,
  username: usernameValidationErrors,
  emailOrUsername: emailOrUsernameValidationErrors,
  password: passwordValidationErrors,
};

export function getValidationErrors(form: FormGroup): string[] {
  return Object.entries(form.controls)
    .filter(([, control]) => control.touched)
    .flatMap(([key, control]) =>
      Object.keys(control.errors || [])
        .filter((errorKey) => controlErrorMessagesMap[key]?.[errorKey])
        .map((errorKey) => controlErrorMessagesMap[key][errorKey]),
    );
}
