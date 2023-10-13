import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import {
  FaIconLibrary,
  FontAwesomeModule,
} from '@fortawesome/angular-fontawesome';
import { fab } from '@fortawesome/free-brands-svg-icons';
import { far } from '@fortawesome/free-regular-svg-icons';
import { fas } from '@fortawesome/free-solid-svg-icons';
import { ResizableModule } from 'angular-resizable-element';
import { NgxSmartModalModule } from 'ngx-smart-modal';

import { CustomInputComponent } from './components/custom-input/custom-input.component';
import { HeaderComponent } from './components/header/header.component';

@NgModule({
  declarations: [HeaderComponent, CustomInputComponent],
  imports: [
    CommonModule,
    FormsModule,
    FontAwesomeModule,
    RouterModule,
    ResizableModule,
    NgxSmartModalModule.forChild(),
  ],
  exports: [
    HeaderComponent,
    CustomInputComponent,
    CommonModule,
    FontAwesomeModule,
    ResizableModule,
    NgxSmartModalModule,
  ],
})
export class SharedModule {
  constructor(library: FaIconLibrary) {
    library.addIconPacks(fas, fab, far);
  }
}
