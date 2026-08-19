import { Directive, ElementRef, HostBinding, Input, OnChanges, SimpleChanges } from '@angular/core';
import { NgForm, NgControl } from '@angular/forms';

@Directive({
  selector: '[appInvalidField]'
})
export class InvalidFieldDirective {

  @Input('appHighlightInvalidFields') form: NgForm | null = null;

  @HostBinding('class.invalid-field') get isInvalid() {
    if (!this.form) return false;
    return this.form.submitted;
  }

  constructor(private el: ElementRef) {}

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['form']) {
      this.updateStyles();
    }
  }

  private updateStyles(): void {
    if (!this.form) return;
    const formControls = Object.values(this.form.controls);
    for (const control of formControls) {
      const nativeControl = (control as any).nativeElement;
      if (control.invalid && (control.dirty || control.touched || this.form.submitted)) {
        nativeControl.classList.add('invalid-field');
      } else {
        nativeControl.classList.remove('invalid-field');
      }
    }
  }


}
