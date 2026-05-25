import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from '@environments/environment';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {

  basicInformationForm!: FormGroup;
  submitted = false;

  constructor(private router: Router, private fb: FormBuilder, public httpSer: HttpServiceService, private http: HttpClient) { }



  ngOnInit(): void {
    this.basicInformationForm = this.fb.group({


      employeeId: [0],
      firstName: ['', Validators.required],
      middleName: [''],
      lastName: ['', Validators.required], phoneNumber: ['', [Validators.required, Validators.pattern('^[0-9]{10}$'), Validators.maxLength(10)]],
      emailAddress: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required],
      designation: ['', [Validators.required]],
      dateOfBirth: ['', [Validators.required]],
      gender: ['', [Validators.required]],
      addressLine: ['', [Validators.required]],
      isSameAsBusinessAddress: [false],
    }, {
      validators: this.passwordMatchValidator
    }
    );

  }

  passwordMatchValidator(form: AbstractControl): ValidationErrors | null {

    const password = form.get('password')?.value;
    const confirmPassword = form.get('confirmPassword');

    if (!confirmPassword) return null;

    if (password !== confirmPassword.value) {
      confirmPassword.setErrors({ passwordMismatch: true });
    } else {
      if (confirmPassword.hasError('passwordMismatch')) {
        confirmPassword.setErrors(null);
      }
    }

    return null;
  }

  showPassword = false;
  showConfirmPassword = false;

  togglePassword() {

    this.showPassword = !this.showPassword;

  }

  toggleConfirmPassword() {
    this.showConfirmPassword = !this.showConfirmPassword;

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

  EmpList: any[] = [];

  empList() {
    const apiUrl = environment.apiurls + '/HREmployee';
    return this.http.get(apiUrl).toPromise()
      .then((response: any) => {
        this.EmpList = response;
      })
      .catch((error: any) => {
        throw error;
      });
  }

  async goToWorkDetails() {

    this.submitted = true;

    if (this.basicInformationForm.invalid) {
      this.basicInformationForm.markAllAsTouched();
      return;
    }

    const formValue = this.basicInformationForm.value;

    // ✅ Optional: get employee list
    await this.empList();

    const selectedEmp = this.EmpList.find(
      (x: any) => x.employeeId == formValue.employeeId
    );

    const empId = selectedEmp ? String(selectedEmp.employeeId) : '';

    const nameParts = formValue.employeeName
      ? formValue.employeeName.trim().split(' ')
      : [];

    const requestBody = {
      flag: 'I',   // ✅ IMPORTANT (no wrapper)

      userId: 0,

      firstName: nameParts[0] || '',
      middleName: nameParts.length > 2 ? nameParts[1] : null,
      lastName: nameParts.length > 1 ? nameParts[nameParts.length - 1] : '',

      phoneNumber: formValue.phoneNumber,
      emailAddress: formValue.emailAddress,
      password: formValue.password,

      empID: empId,   // ✅ must be string

      designation: formValue.designation,
      dateOfBirth: formValue.dateOfBirth,
      gender: formValue.gender,
      addressLine: formValue.addressLine,

      isSameAsBusinessAddress: formValue.isSameAsBusinessAddress,

      isActive: true,
      isDeleted: false,

      createdBy: 1,
      modifiedBy: 1
    };

    console.log("Final Request:", requestBody);

    this.httpSer.httpPost('/BasicInformation/SaveBasicInformation', requestBody)
      .subscribe({

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
          console.error(error);
          alert('API Error');
        }

      });
  }
}
