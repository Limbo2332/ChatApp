/* eslint-disable function-paren-newline */
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { finalize, forkJoin, map, of, switchMap } from 'rxjs';
import { AuthService } from 'src/app/core/services/auth.service';
import { UserService } from 'src/app/core/services/user.service';
import { IUser } from 'src/app/shared/models/user/user';
import { IUserAvatar } from 'src/app/shared/models/user/user-avatar';
import { IUserEdit } from 'src/app/shared/models/user/user-edit';
import {
  emailMaxLength,
  emailMinLength,
  userNameMaxLength,
  userNameMinLength,
} from 'src/app/shared/utils/validation/constants';
import {
  emailRegex,
  noSpacesRegex,
} from 'src/app/shared/utils/validation/regex-patterns';
import { getValidationErrors } from 'src/app/shared/utils/validation/validation-helper';

import { defaultImagePath } from '../../chat/chat-utils';
import { IBlobImage } from 'src/app/shared/models/user/blob-image';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.sass'],
})
export class UserProfileComponent implements OnInit {
  currentUser: IUser;

  avatarPreview = defaultImagePath;

  blobAvatarPreviewUrl: SafeUrl = defaultImagePath;

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
    sqlAvatar: new FormControl<File>(null!),
  });

  private validationErrorsFromBackend: string[] = [];

  constructor(
    private authService: AuthService,
    private userService: UserService,
    private toastrService: ToastrService,
    private router: Router,
    private spinner: NgxSpinnerService,
    private sanitizer: DomSanitizer,
  ) {}

  ngOnInit(): void {
    this.authService.getUser().subscribe((user: IUser) => {
      this.currentUser = user;
      this.avatarPreview = this.currentUser.imagePath ?? this.avatarPreview;

      if (this.currentUser.sqlImage) {
        const objectURL = `data:${this.currentUser.sqlImage.contentType};base64,${this.currentUser.sqlImage.data}`;

        this.blobAvatarPreviewUrl =
          this.sanitizer.bypassSecurityTrustUrl(objectURL);
      } else {
        this.blobAvatarPreviewUrl = defaultImagePath;
      }
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
    const input = event.target as HTMLInputElement;

    if (!input.files || !input.files.length || !input.files.item(0)) {
      return;
    }

    const fileValue = input.files.item(0);

    if (!this.validateImageFormat(fileValue!.type)) {
      return;
    }

    this.editProfileForm.patchValue({ avatar: fileValue });

    this.updateAvatarPreview();
  }

  blobImageUploaded(event: Event) {
    const input = event.target as HTMLInputElement;

    if (!input.files || !input.files.length || !input.files.item(0)) {
      return;
    }

    const fileValue = input.files.item(0);

    if (!this.validateImageFormat(fileValue!.type)) {
      return;
    }

    this.editProfileForm.patchValue({ sqlAvatar: fileValue });

    this.updateSqlAvatarPreview();
  }

  updateInfo() {
    if (this.editProfileForm.valid) {
      this.spinner.show();
      const userEdit: IUserEdit = {
        email: this.editProfileForm.controls.email.value!,
        userName: this.editProfileForm.controls.userName.value!,
      };

      this.userService
        .update(userEdit)
        .pipe(
          // eslint-disable-next-line no-confusing-arrow
          switchMap((user: IUser) => {
            const shouldUpdateAvatar = !!this.editProfileForm.value.avatar;
            const shouldUpdateSqlAvatar =
              !!this.editProfileForm.value.sqlAvatar;

            if (shouldUpdateAvatar && shouldUpdateSqlAvatar) {
              return forkJoin({
                userAvatar: this.updateUserAvatar(user),
                userSqlAvatar: this.updateSqlUserAvatar(user),
              }).pipe(map((result) => result.userAvatar));
            }

            if (shouldUpdateAvatar) {
              return this.updateUserAvatar(user);
            }

            if (shouldUpdateSqlAvatar) {
              return this.updateSqlUserAvatar(user);
            }

            return of(user);
          }),
          finalize(() => {
            this.spinner.hide();
          }),
        )
        .subscribe(
          (user: IUser) => {
            this.authService.setUserInfo(user);
            this.toastrService.success('Your data was successfully updated');
            this.router.navigate(['chats']);
          },
          (errors: string[]) => {
            this.validationErrorsFromBackend = errors;
          },
        );
    }
  }

  updateUserAvatar(user: IUser) {
    const formData = new FormData();

    formData.append('newAvatar', this.editProfileForm.value.avatar!);

    return this.userService.updateAvatar(formData).pipe(
      map((newAvatar: IUserAvatar) => {
        user.imagePath = newAvatar.imagePath;

        return user;
      }),
    );
  }

  updateSqlUserAvatar(user: IUser) {
    const formData = new FormData();

    formData.append('newAvatar', this.editProfileForm.value.sqlAvatar!);

    return this.userService.updateSqlAvatar(formData).pipe(
      map((blobImage: IBlobImage) => {
        user.sqlImage = blobImage;

        return user;
      }),
    );
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

  private updateSqlAvatarPreview() {
    const reader = new FileReader();
    const fileValue = this.editProfileForm.value.sqlAvatar;

    if (!fileValue) {
      return;
    }

    reader.onload = () => {
      this.blobAvatarPreviewUrl = reader.result as string;
    };

    reader.readAsDataURL(fileValue);
  }

  private validateImageFormat(type: string): boolean {
    const idxDot = type.lastIndexOf('/') + 1;
    const extFile = type.substr(idxDot, type.length).toLowerCase();

    return extFile === 'jpg' || extFile === 'jpeg' || extFile === 'png';
  }
}
