import { Injectable } from '@angular/core';
import { AbstractControl, FormGroup, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class FormValidationService {
  todaysDate = new Date().toISOString().slice(0, 10);
  todaysDateWithTime = new Date().toISOString().slice(0,16)
  maxDate = new Date('9999-11-23T10:20:10.868Z').toISOString().slice(0, 10)
  maxDateandTime =  new Date('9999-11-23T10:20:10.868Z').toISOString().slice(0, 16)
  projectDetails:any
  currentDate:any
  projectSponsor: any;
  constructor(){
    const date=new Date()
    let year=date.getFullYear()
    let month=(date.getMonth()+1).toString().padStart(2,'0')
    let day=(date.getDate().toString().padStart(2,'0'))
    let hours=(date.getHours()).toString().padStart(2,'0')
    let minutes=date.getMinutes().toString().padStart(2,'0')

    this.currentDate=`${year}-${month}-${day}-${hours}-${minutes}`
  }
  public validateForm(form: any) {
    if (!form) {
      // return;
    }
    if (form.invalid) {
      const firstInvalidControl = this.findFirstInvalidControl(form);
      if (firstInvalidControl) {
        this.scrollToControl(firstInvalidControl);
        const label = this.getLabel(firstInvalidControl);
        alert(label.trim().replace(/\s+/g, ' '));
        return false;
      }
    }
    return true;
  }

  private findFirstInvalidControl(form: FormGroup): string | null {
    const controlNames = this.getControlNamesInOrder(form);

    for (const controlName of controlNames) {
      const control = form.get(controlName);
      if (control?.invalid && this.isControlVisible(controlName)) {
        return controlName;
      }
    }
    return null;
  }

  private getControlNamesInOrder(form: FormGroup): string[] {
    const controls = Array.from(document.querySelectorAll('[formControlName]')) as HTMLElement[];
    return controls
      .map(control => control.getAttribute('formControlName'))
      .filter(name => name !== null && form.get(name)?.invalid && this.isControlVisible(name))
      .map(name => name as string);
  }

  private isControlVisible(controlName: string): boolean {
    const element = document.querySelector(`[formControlName="${controlName}"]`);
    if (element) {
      const displayStyle = getComputedStyle(element.closest('.row') as HTMLElement).display;
      return displayStyle !== 'none';
    }
    return false;
  }

  private getLabel(controlName: string): string {
    const labelElement = document.querySelector(`label[for="${controlName}"]`);
    if (labelElement) {
      const customMessage = labelElement.getAttribute('customLabelAlert');
      return customMessage ? customMessage : `${labelElement.textContent?.trim() || controlName} is Required.`;
    }
    return `${controlName} is Required.`;
  }

  private scrollToControl(controlName: string): void {
    const element = document.getElementsByName(controlName)[0] as HTMLElement;
    if (element) {
      element.scrollIntoView({ behavior: 'smooth', block: 'center' });
    }
  }

  validateDate(date: any,controlName:any) {
    return !(this.isControlVisible(controlName)&&date < this.todaysDate)
  }

  validateStartAndEndDate ( startDate: any, endDate : any,formControl1:any,fromControl2:any){
      return !(this.isControlVisible(formControl1)&&endDate < startDate)
  }


  updateValidators(formGroup: any, controlNames: string[], condition: boolean) {
    controlNames.forEach(controlName => {
      const getFormControl = formGroup.get(controlName);
      const typeOfGetFormControl = typeof getFormControl?.value;

      if (condition) {
        if (typeOfGetFormControl == 'string') {
          getFormControl?.setValidators([Validators.required]);
        }
        else if (typeOfGetFormControl == 'number') {
          getFormControl?.setValidators([Validators.required, Validators.min(1)]);
        }
        else if (getFormControl?.value === null) {
          getFormControl?.setValidators([Validators.required, Validators.min(1)]);
        }
      }
      else {
        getFormControl?.clearValidators();
      }
      getFormControl?.updateValueAndValidity();
    });
  }

  clearOpenedInputFields(selectedValue: string, ...inputFields: (AbstractControl | null)[]) {
    if (selectedValue == "No") {
      inputFields.forEach((control) => {
        const value = control?.value;
        const typeOfValue = typeof value;

        if (value == null || typeOfValue == 'number') {
          control?.patchValue(null);
        }
        else if (typeOfValue == 'string') {
          control?.patchValue('');
        }
      });
    }
  }

  setProjectDetails(data:any){
    this.projectDetails = data
  }

  get todaysDateWithTime1(): string {
    const now = new Date();
    return this.formatDate(now);
  }

  get maxDateandTime1(): string {
    const maxDate = new Date();
    maxDate.setFullYear(maxDate.getFullYear() + 1);
    return this.formatDate(maxDate);
  }
  public formatDate(date: Date): string {
    const year = date.getFullYear();
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const day = date.getDate().toString().padStart(2, '0');
    const hours = date.getHours().toString().padStart(2, '0');
    const minutes = date.getMinutes().toString().padStart(2, '0');
    
    return `${year}-${month}-${day}T${hours}:${minutes}`;
  
  }
  // updateDateFormat(date: any, inputType: 'date' | 'datetime-local'): any {
  //   if (date) {
  //     const formattedDate = new Date(date);
  //     formattedDate.setHours(formattedDate.getHours() - 1);

  //     // For 'date'
  //     if (inputType === 'date') {
  //       return formattedDate.toISOString().split('T')[0];
  //     }

  //     // For 'datetime-local'
  //     if (inputType === 'datetime-local') {
  //       const datePart = formattedDate.toISOString().split('T')[0];
  //       const timePart = formattedDate.toISOString().split('T')[1].slice(0, 5);
  //       return `${datePart}T${timePart}`;
  //     }
  //   }

  //   return null;
  // }

}
