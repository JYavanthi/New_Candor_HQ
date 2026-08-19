import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-validation',
  templateUrl: './validation.component.html',
  styleUrl: './validation.component.css'
})
export class ValidationComponent {
  @Input() message: string = '';
  @Output() closed = new EventEmitter<void>();

  closePopup() {
    this.closed.emit();
  }
}
