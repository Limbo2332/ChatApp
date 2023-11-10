import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { FaIconLibrary, FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { fab } from '@fortawesome/free-brands-svg-icons';
import { far } from '@fortawesome/free-regular-svg-icons';
import { fas } from '@fortawesome/free-solid-svg-icons';
import { ResizableModule } from 'angular-resizable-element';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { NgxSmartModalModule } from 'ngx-smart-modal';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ToastrModule } from 'ngx-toastr';

import { CustomInputComponent } from './components/custom-input/custom-input.component';
import { HeaderComponent } from './components/header/header.component';
import { NewChatModalComponent } from './components/new-chat-modal/new-chat-modal.component';
import { ResetPasswordModalComponent } from './components/reset-password-modal/reset-password-modal.component';

@NgModule({
  declarations: [
    HeaderComponent,
    CustomInputComponent,
    NewChatModalComponent,
    ResetPasswordModalComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    FontAwesomeModule,
    RouterModule,
    ResizableModule,
    NgxSmartModalModule.forChild(),
    ToastrModule.forRoot(),
    NgxSpinnerModule,
    InfiniteScrollModule,
  ],
  exports: [
    HeaderComponent,
    CustomInputComponent,
    NewChatModalComponent,
    ResetPasswordModalComponent,
    CommonModule,
    FontAwesomeModule,
    ResizableModule,
    NgxSmartModalModule,
    ToastrModule,
    NgxSpinnerModule,
    InfiniteScrollModule,
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class SharedModule {
  constructor(library: FaIconLibrary) {
    library.addIconPacks(fas, fab, far);
  }
}
