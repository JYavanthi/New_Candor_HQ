import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {

  basicInformationForm!: FormGroup;
  submitted = false;

  constructor(private router: Router, private fb: FormBuilder, public httpSer: HttpServiceService) { }



  ngOnInit(): void {
    this.basicInformationForm = this.fb.group({


      employeeId: [0],
      employeeName: ['', [Validators.required]],
      phoneNumber: ['', [Validators.required, Validators.pattern('^[0-9]{10}$'), Validators.maxLength(10)]],
      emailAddress: ['', [Validators.required, Validators.email]],
      designation: ['', [Validators.required]],
      dateOfBirth: ['', [Validators.required]],
      gender: ['', [Validators.required]],
      addressLine: ['', [Validators.required]],
      isSameAsBusinessAddress: [false],
    });

  }

  get f() {
    return this.basicInformationForm.controls;
  }

  previousStep() {
    this.router.navigate(['/work-details']);
  }

  onlyNumbers(event: any) {
    let value = event.target.value;

    value = value.replace(/[^0-9]/g, '');

    if (value.length > 10) {
      value = value.substring(0, 10);
    }

    event.target.value = value;
    this.basicInformationForm.controls['businessNumber'].setValue(value, { emitEvent: false });
  }

  goToWorkDetails() {

    this.submitted = true;

    if (this.basicInformationForm.invalid) {
      this.basicInformationForm.markAllAsTouched();
      return;
    }

    const requestBody = {

      "flag": 'I',
      "employeeId": this.basicInformationForm.value.employeeId || 0,
      "employeeName": this.basicInformationForm.value.employeeName,
      "phoneNumber": this.basicInformationForm.value.phoneNumber,
      "emailAddress": this.basicInformationForm.value.emailAddress,
      "designation": this.basicInformationForm.value.designation,
      "dateOfBirth": this.basicInformationForm.value.dateOfBirth,
      "gender": this.basicInformationForm.value.gender,
      "addressLine": this.basicInformationForm.value.addressLine,
      "isSameAsBusinessAddress": this.basicInformationForm.value.isSameAsBusinessAddress,
      "createdDate": new Date().toISOString(),
      "ModifiedDate": new Date().toISOString()

    };

    console.log(requestBody);
    this.httpSer.httpPost('/BasicInformation/SaveBasicInformation', requestBody).subscribe({

      next: (response: any) => {
        console.log(response);
        if (response.type === 'S') {

          alert('Basic Information Saved Successfully');
          this.router.navigate(['/security']);
        } else {
          alert(response.message || 'Save Failed');
        }

      },

      error: (error) => {
        console.log(error);
        alert('API Error');

      }

    });

  }


}
