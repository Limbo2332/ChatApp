import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/core/services/auth.service';
import { UserService } from 'src/app/core/services/user.service';
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

  avatarPreview = defaultImagePath;

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
    avatar: new FormControl<File>(null!),
  });

  private validationErrorsFromBackend: string[] = [];

  constructor(
    private authService: AuthService,
    private userService: UserService,
  ) {}

  ngOnInit(): void {
    this.authService.getUser().subscribe((user: IUser) => {
      this.currentUser = user;
      this.avatarPreview = this.currentUser.imagePath ?? this.avatarPreview;
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

  imageUploaded(event: Event) {
    this.updateAvatarInForm(event);

    this.updateAvatarPreview();

    const formData = new FormData();

    formData.append('newAvatar', this.editProfileForm.value.avatar!);

    // this.userService.updateAvatar(formData).subscribe();
  }

  private updateAvatarInForm(event: Event) {
    const input = event.target as HTMLInputElement;

    if (!input.files || !input.files.length || !input.files.item(0)) {
      return;
    }

    const fileValue = input.files.item(0);

    this.editProfileForm.patchValue({ avatar: fileValue });
  }

  private updateAvatarPreview() {
    const reader = new FileReader();
    const fileValue = this.editProfileForm.value.avatar;

    if (!fileValue) {
      return;
    }

    reader.onload = () => {
      this.avatarPreview = reader.result as string;
    };

    reader.readAsDataURL(fileValue);
  }
}
