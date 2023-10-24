import { FormGroup } from '@angular/forms';

import { ValidationErrorsMessages } from './validation-error';
import {
  emailOrUsernameValidationErrors,
  emailValidationErrors,
  newMessageValidationErrors,
  passwordValidationErrors,
  userNameValidationErrors,
} from './validation-error-messages';

const controlErrorMessagesMap: { [key: string]: ValidationErrorsMessages } = {
  email: emailValidationErrors,
  userName: userNameValidationErrors,
  emailOrUserName: emailOrUsernameValidationErrors,
  password: passwordValidationErrors,
  message: newMessageValidationErrors,
};

export function getValidationErrors(form: FormGroup): string[] {
  return Object.entries(form.controls)
    .filter(([, control]) => control.touched)
    .flatMap(([key, control]) =>
      Object.keys(control.errors || [])
        .filter((errorKey) => controlErrorMessagesMap[key]?.[errorKey])
        .map((errorKey) => controlErrorMessagesMap[key][errorKey]));
}
