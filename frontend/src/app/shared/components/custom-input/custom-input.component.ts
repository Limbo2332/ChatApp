import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IconName, IconPrefix } from '@fortawesome/fontawesome-svg-core';
import { debounceTime, Subject } from 'rxjs';

import { DebounceTime } from '../../utils/debounce-time';
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
export class CustomInputComponent implements OnInit {
  @Input() InputId: string = 'text';

  @Input() InputText?: string;

  @Input() InputType: string = 'text';

  @Input() InputPlaceholder?: string;

  @Input() InputValue?: string;

  @Input() Width: string = '100%';

  @Input() customInputClass: string = 'custom-input';

  @Output() InputValueChanged = new EventEmitter<string>();

  inputValue: string = '';

  passwordIcon: [IconPrefix, IconName] = ['fas', 'eye'];

  private valueChanged = new Subject<string>();

  ngOnInit(): void {
    this.valueChanged
      .pipe(debounceTime(DebounceTime))
      .subscribe((value: string) => {
        this.InputValueChanged.emit(value);
      });
  }

  changeInputValue(value: string) {
    this.valueChanged.next(value);
  }

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
