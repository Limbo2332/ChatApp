import { ValidationErrorsMessages } from './validation-error';

export const emailValidationErrors: ValidationErrorsMessages = {
  required: 'Email is required',
  pattern: 'Email is incorrect format',
};

export const usernameValidationErrors: ValidationErrorsMessages = {
  required: 'Username is required',
  pattern: 'Username must not start or end with spaces',
};

export const emailOrUsernameValidationErrors: ValidationErrorsMessages = {
  required: 'Email or username is required',
  pattern: 'Email or username must not start or end with spaces',
};

export const passwordValidationErrors: ValidationErrorsMessages = {
  required: 'Password is required',
  pattern: 'Password must have at least 1 number and 1 special character',
};
