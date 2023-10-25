import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IconName, IconPrefix } from '@fortawesome/fontawesome-svg-core';
import { debounceTime, Subject } from 'rxjs';
import { EventService } from 'src/app/core/services/event.service';

import { DebounceTime } from '../../utils/debounce-time';
import { newMessageMaxLength } from '../../utils/validation/constants';
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

  @Output() MessageSent = new EventEmitter<string>();

  @Output() NewChatButtonClicked = new EventEmitter<void>();

  inputValue: string = '';

  passwordIcon: [IconPrefix, IconName] = ['fas', 'eye'];

  searchIcon: [IconPrefix, IconName] = ['fas', 'plus-circle'];

  private valueChanged = new Subject<string>();

  constructor(private eventService: EventService) {}

  ngOnInit(): void {
    this.valueChanged
      .pipe(debounceTime(DebounceTime))
      .subscribe((value: string) => {
        this.InputValueChanged.emit(value);
      });

    this.eventService.inputClearedEvent$.subscribe(() => {
      this.inputValue = '';
    });
  }

  sendMessage() {
    if (this.inputValue && this.inputValue.length < newMessageMaxLength) {
      this.MessageSent.emit(this.inputValue);
      this.inputValue = '';
    }
  }

  changeInputValue(value: string) {
    this.valueChanged.next(value);

    if (this.canShowCloseSearchButton()) {
      this.searchIcon = value ? ['fas', 'xmark'] : ['fas', 'plus-circle'];
    }
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

  canClickEnterToSendMessage() {
    return this.InputId === 'send-message' && this.inputValue !== '';
  }

  canShowPasswordIcon() {
    return (
      this.InputType === 'password' || this.passwordIcon.includes('eye-slash')
    );
  }

  canShowMessageIcon() {
    return this.InputId.includes('send') && this.inputValue;
  }

  canShowCloseSearchButton() {
    return this.InputId.includes('find');
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

  onSearchIconClicked() {
    if (this.searchIcon[1] === 'xmark') {
      this.inputValue = '';
      this.changeInputValue(this.inputValue);
    } else {
      this.NewChatButtonClicked.emit();
    }
  }
}
