import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  showPassword: boolean = false;
  loginForm!: FormGroup;
  submitted = false;

  constructor(private fb: FormBuilder, private router : Router, public httpSer : HttpServiceService ) { }


  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      remember: [true]
    });
  }

  get f() {
    return this.loginForm.controls;
  }

  togglePassword() {
    this.showPassword = !this.showPassword;
  }

  onLogin() {

    this.submitted = true;

    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }

    const requestBody = {

      "flag": 'L', 
      "userId": 0, 
      "email": this.loginForm.value.email,
      "password": this.loginForm.value.password,
      "isActive": true,
      "createdBy": 1,   
      "modifiedBy": 1   

    };

    console.log(requestBody);

    this.httpSer.httpPost('/UserLogin/SaveUserLogin', requestBody).subscribe({

      next: (response: any) => {

        console.log(response);

        if (response.type === 'S') {

          alert('Login Successfully');

          this.router.navigate(['/dashboard']);

        } else {

          alert(response.message || 'Login Failed');

        }

      },

      error: (error) => {

        console.log(error);

        alert('API Error');

      }

    });

  }

}
