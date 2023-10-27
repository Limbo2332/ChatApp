import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function comparePasswordsValidator(): ValidatorFn {
  return (formGroup: AbstractControl): ValidationErrors | null => {
    const password = formGroup.get('password')?.value;

    const confirmPassword = formGroup.get('confirmPassword')?.value;

    if (password && confirmPassword) {
      return { confirmPassword: password === confirmPassword };
    }

    return null;
  };
}
