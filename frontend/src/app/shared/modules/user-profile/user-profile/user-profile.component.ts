import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/core/services/auth.service';
import { IUser } from 'src/app/shared/models/user/user';
import {
  emailMaxLength,
  emailMinLength,
  userNameMaxLength,
  userNameMinLength,
} from 'src/app/shared/utils/validation/constants';
import { emailRegex, noSpacesRegex } from 'src/app/shared/utils/validation/regex-patterns';
import { getValidationErrors } from 'src/app/shared/utils/validation/validation-helper';

import { defaultImagePath } from '../../chat/chat-utils';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.sass'],
})
export class UserProfileComponent implements OnInit {
  currentUser: IUser;

  defaultImagePath = defaultImagePath;

  editProfileForm = new FormGroup({
    email: new FormControl('', [
      Validators.required,
      Validators.pattern(emailRegex),
      Validators.minLength(emailMinLength),
      Validators.maxLength(emailMaxLength),
    ]),
    userName: new FormControl('', [
      Validators.required,
      Validators.pattern(noSpacesRegex),
      Validators.minLength(userNameMinLength),
      Validators.maxLength(userNameMaxLength),
    ]),
  });

  private validationErrorsFromBackend: string[] = [];

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.authService.getUser().subscribe((user: IUser) => {
      this.currentUser = user;
    });
  }

  changeInputValue(formControlName: 'email' | 'userName', value: string) {
    this.editProfileForm.controls[formControlName].setValue(value);
    this.editProfileForm.controls[formControlName].markAsTouched();
  }

  getValidationErrors() {
    return [
      ...getValidationErrors(this.editProfileForm),
      ...this.validationErrorsFromBackend,
    ].slice(0, 2);
  }
}
