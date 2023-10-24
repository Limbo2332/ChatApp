import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { Subject } from 'rxjs';
import { ChatsService } from 'src/app/core/services/chats.service';

import { IChatPreview } from '../../models/chats/chat-preview';
import { INewChat } from '../../models/chats/new-chat';
import { newMessageMaxLength, userNameMaxLength, userNameMinLength } from '../../utils/validation/constants';
import { noSpacesRegex } from '../../utils/validation/regex-patterns';
import { getValidationErrors } from '../../utils/validation/validation-helper';

@Component({
  selector: 'app-new-chat-modal',
  templateUrl: './new-chat-modal.component.html',
  styleUrls: ['../../../../styles/modal.sass'],
})
export class NewChatModalComponent {
  @Output() NewChatAdded = new EventEmitter<IChatPreview>();

  clearSubject = new Subject<void>();

  newChatIdentifier: string = 'newChat';

  newChatForm = new FormGroup({
    userName: new FormControl('', [
      Validators.required,
      Validators.pattern(noSpacesRegex),
      Validators.minLength(userNameMinLength),
      Validators.maxLength(userNameMaxLength),
    ]),
    message: new FormControl('', [
      Validators.required,
      Validators.maxLength(newMessageMaxLength),
    ]),
  });

  private validationErrorsFromBackend: string[] = [];

  constructor(
    private chatsService: ChatsService,
    private modalService: NgxSmartModalService,
  ) {}

  changeInputValue(formControlName: 'userName' | 'message', value: string) {
    this.newChatForm.controls[formControlName].setValue(value);
    this.newChatForm.controls[formControlName].markAsTouched();
  }

  getValidationErrors() {
    return [
      ...getValidationErrors(this.newChatForm),
      ...this.validationErrorsFromBackend,
    ].slice(0, 2);
  }

  addNewChat() {
    const newChat: INewChat = {
      userName: this.newChatForm.controls.userName.value!,
      newMessage: this.newChatForm.controls.message.value!,
    };

    this.clearForm();

    this.chatsService.addChat(newChat).subscribe(
      (chat: IChatPreview) => {
        this.NewChatAdded.emit(chat);
      },
      (errors: string[]) => {
        this.validationErrorsFromBackend = errors;
      },
    );
  }

  clearForm() {
    this.modalService
      .get(this.newChatIdentifier)
      .onCloseFinished.subscribe(() => {
        this.clearSubject.next();
      });
  }
}
