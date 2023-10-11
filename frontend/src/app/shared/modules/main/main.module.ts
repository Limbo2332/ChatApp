import { NgModule } from '@angular/core';

import { SharedModule } from '../../shared.module';
import { MainRoutingModule } from './main-routing.module';
import { MainComponent } from './main/main.component';

@NgModule({
  declarations: [MainComponent],
  imports: [SharedModule, MainRoutingModule],
})
export class MainModule {}
