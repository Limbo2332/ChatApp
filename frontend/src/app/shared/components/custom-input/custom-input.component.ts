import { Component, Input } from '@angular/core';
import { IconName, IconPrefix } from '@fortawesome/fontawesome-svg-core';

import {
  paddingRightWhenDefaultIcon,
  paddingRightWhenLgIcon,
  paddingRightWhenNoIcon,
} from './custom-input.utils';

@Component({
  selector: 'app-custom-input[InputId]',
  templateUrl: './custom-input.component.html',
  styleUrls: ['./custom-input.component.sass'],
})
export class CustomInputComponent {
  @Input() InputId: string = 'text';

  @Input() InputText?: string;

  @Input() InputType: string = 'text';

  @Input() InputPlaceholder?: string;

  @Input() StartValue?: string;

  @Input() Width: string = '100%';

  @Input() customInputClass: string = 'custom-input';

  inputValue: string = '';

  passwordIcon: [IconPrefix, IconName] = ['fas', 'eye'];

  changePasswordView() {
    if (this.InputType.toLowerCase() === 'password') {
      this.passwordIcon = ['fas', 'eye-slash'];
      this.InputType = 'text';
    } else {
      this.passwordIcon = ['fas', 'eye'];
      this.InputType = 'password';
    }
  }

  canShowPasswordIcon() {
    return (
      this.InputType === 'password' || this.passwordIcon.includes('eye-slash')
    );
  }

  canShowMessageIcon() {
    return this.InputId.includes('message') && this.inputValue;
  }

  canShowCloseSearchButton() {
    return this.InputId.includes('find');
  }

  showSearchButton(): [IconPrefix, IconName] {
    return this.inputValue ? ['fas', 'xmark'] : ['fas', 'plus-circle'];
  }

  getPaddingRightForInput(): number {
    if (this.canShowPasswordIcon()) {
      return paddingRightWhenDefaultIcon;
    }

    if (this.canShowMessageIcon()) {
      return paddingRightWhenLgIcon;
    }

    return paddingRightWhenNoIcon;
  }

  clearSearch() {
    this.inputValue = '';
  }
}
