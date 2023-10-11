import { Component, Input } from '@angular/core';

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
}
