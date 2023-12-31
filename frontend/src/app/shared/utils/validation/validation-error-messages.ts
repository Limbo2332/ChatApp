import {
  emailMaxLength,
  emailMinLength,
  passwordMaxLength,
  passwordMinLength,
  userNameMaxLength,
  userNameMinLength,
} from './constants';
import { ValidationErrorsMessages } from './validation-error';

export const emailValidationErrors: ValidationErrorsMessages = {
  required: 'Email is required',
  pattern: 'Email is in incorrect format',
  minlength: `Email must have at least ${emailMinLength} symbols`,
  maxlength: `Email must not exceed ${emailMaxLength} symbols`,
};

export const userNameValidationErrors: ValidationErrorsMessages = {
  required: 'Username is required',
  pattern: 'Username must not start or end with spaces',
  minlength: `Username must have at least ${userNameMinLength} symbols`,
  maxlength: `Username must not exceed ${userNameMaxLength} symbols`,
};

export const emailOrUsernameValidationErrors: ValidationErrorsMessages = {
  required: 'Email or username is required',
  pattern: 'Email or username must not start or end with spaces',
  minlength: `Email or username must have at least ${Math.min(
    emailMinLength,
    userNameMinLength,
  )} symbols`,
  maxlength: `Email or username must not exceed ${Math.min(
    emailMaxLength,
    userNameMaxLength,
  )} symbols`,
};

export const passwordValidationErrors: ValidationErrorsMessages = {
  required: 'Password is required',
  pattern:
    'Password must have at least 1 number, 1 lowercase, 1 uppercase and 1 special character',
  minlength: `Password must have at least ${passwordMinLength} symbols`,
  maxlength: `Password must not exceed ${passwordMaxLength} symbols`,
};

export const confirmPasswordValidationErrors: ValidationErrorsMessages = {
  required: 'Confirm password is required',
  pattern:
    'Confirm password must have at least 1 number, 1 lowercase, 1 uppercase and 1 special character',
  minlength: `Confirm password must have at least ${passwordMinLength} symbols`,
  maxlength: `Confirm password must not exceed ${passwordMaxLength} symbols`,
  confirmPassword: 'Passwords must be the same',
};

export const newMessageValidationErrors: ValidationErrorsMessages = {
  required: 'Message cannot be empty',
  maxlength: 'Message is too long',
};
