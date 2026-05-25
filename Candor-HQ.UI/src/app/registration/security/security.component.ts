import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-security',
  templateUrl: './security.component.html',
  styleUrl: './security.component.css'
})
export class SecurityComponent {

  securityForm!: FormGroup;

  submitted = false;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private httpSer: HttpServiceService
  ) { }

  ngOnInit(): void {

    this.securityForm = this.fb.group({

      securityQuestion1: ['', Validators.required],
      securityAnswer1: ['', Validators.required],
      securityQuestion2: ['', Validators.required],
      securityAnswer2: ['', Validators.required],
      emailOtp: ['', [Validators.required, Validators.pattern(/^\d{6}$/)]],
      mobileOtp: ['', [Validators.required, Validators.pattern(/^\d{6}$/)]],
      fullName: ['', Validators.required],
      userName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      mobileNumber: ['', [Validators.required, Validators.pattern('^[0-9]{10}$'), Validators.maxLength(10)]],
      gstNumber: [''],
      preferredLanguage: ['', Validators.required],
      timeZone: ['', Validators.required],
      acceptTerms: [false, Validators.requiredTrue]

    },
    );

  }

  onlyNumbers(event: any) {
    let value = event.target.value;

    value = value.replace(/[^0-9]/g, '');

    if (value.length > 10) {
      value = value.substring(0, 10);
    }

    event.target.value = value;
    this.securityForm.controls['businessNumber'].setValue(value, { emitEvent: false });
  }

  get f() {
    return this.securityForm.controls;
  }



  sendEmailOtp() {
    alert('Email OTP Sent Successfully');
  }

  sendMobileOtp() {

    alert('Mobile OTP Sent Successfully');

  }

  onBack() {

    this.router.navigate(['/registration']);

  }


  onLogin() {
    console.log('Button Clicked');

    this.submitted = true;

    if (this.securityForm.invalid) {


      Object.keys(this.securityForm.controls).forEach(key => {
        const control = this.securityForm.get(key);
        if (control?.invalid) {
        }
      });

      this.securityForm.markAllAsTouched();
      return;
    }

    const requestBody = {
      flag: 'I',
      securityPreferenceId: 0,
      userId: 0,
      securityQuestion1: this.securityForm.value.securityQuestion1,
      securityAnswer1: this.securityForm.value.securityAnswer1,
      securityQuestion2: this.securityForm.value.securityQuestion2,
      securityAnswer2: this.securityForm.value.securityAnswer2,
      emailOTP: this.securityForm.value.emailOtp,
      mobileOTP: this.securityForm.value.mobileOtp,
      userName: this.securityForm.value.userName,
      emailAddress: this.securityForm.value.email,
      mobileNumber: this.securityForm.value.mobileNumber,
      createdBy: 1,
      modifiedBy: 1
    };

    this.httpSer.httpPost(
      '/UserSecurityAndPreferences/SaveUserSecurityAndPreferences',
      requestBody
    ).subscribe({
      next: (response: any) => {

        console.log(response);

        if (response.type === 'S') {
          alert('Account Created Successfully');
          this.securityForm.reset();
          this.router.navigate(['/dashboard']);
        } else {
          alert(response.message);
        }

      },
      error: (error: any) => {
        console.log(error);
        alert('API Error');
      }
    });

  }
}
