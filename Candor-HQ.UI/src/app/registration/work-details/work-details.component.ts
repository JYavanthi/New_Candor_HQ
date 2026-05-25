import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { State, StateServiceService } from 'app/services/state.service.service';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-work-details',
  templateUrl: './work-details.component.html',
  styleUrl: './work-details.component.css'
})
export class WorkDetailsComponent {

  workDetailsForm!: FormGroup;
  submitted = false;
  selectedFile: any;

  constructor(private router: Router, private fb: FormBuilder, private httpSer: HttpServiceService, private stateService: StateServiceService) {

  }

  // ngOnInit(): void {

  //   this.workDetailsForm = this.fb.group({

  //     companyName: ['', [Validators.required]],
  //     businessNumber: ['', [Validators.required, Validators.pattern('^[0-9]{10}$'), Validators.maxLength(10)]],
  //     workEmail: ['', [Validators.required, Validators.email]],
  //     address: ['', [Validators.required, Validators.minLength(5)]],
  //     // country: ['', [Validators.required]],
  //     // state: ['', [Validators.required]],
  //     // city: ['', [Validators.required]],
  //     country: [''],
  //     state: [''],
  //     city: [''],
  //     zipCode: ['', [Validators.required, Validators.pattern('^[0-9]{6}$')]],
  //     profilePhoto: ['']

  //   });

  //   this.loadStates();
  //   this.loadCountries();
  //   this.loadCities();
  //   this.loadPincodes();

  // }

  ngOnInit(): void {

    this.workDetailsForm = this.fb.group({
      companyName: ['', [Validators.required]],
      businessNumber: ['', [Validators.required, Validators.pattern('^[0-9]{10}$'), Validators.maxLength(10)]],
      workEmail: ['', [Validators.required, Validators.email]],
      address: ['', [Validators.required, Validators.minLength(5)]],

      country: ['', [Validators.required]],
      state: ['', [Validators.required]],
      city: ['', [Validators.required]],

      zipCode: ['', [Validators.required, Validators.pattern('^[0-9]{6}$')]],
      profilePhoto: ['']
    });

    // ✅ Load only countries initially
    this.loadCountries();

    // 🔥 Country → State
    this.workDetailsForm.get('country')?.valueChanges.subscribe(countryId => {

      this.states = [];
      this.cities = [];
      this.pincodes = [];

      this.workDetailsForm.patchValue({
        state: '',
        city: '',
        zipCode: ''
      });

      if (countryId) {
        this.loadStatesByCountry(countryId);
      }
    });

    // 🔥 State → City
    this.workDetailsForm.get('state')?.valueChanges.subscribe(stateId => {

      this.cities = [];
      this.pincodes = [];

      this.workDetailsForm.patchValue({
        city: '',
        zipCode: ''
      });

      if (stateId) {
        this.loadCitiesByState(stateId);
      }
    });

    // 🔥 City → Pincode
    this.workDetailsForm.get('city')?.valueChanges.subscribe(cityId => {

      this.pincodes = [];

      this.workDetailsForm.patchValue({
        zipCode: ''
      });

      if (cityId) {
        this.loadPincodesByCity(cityId);
      }
    });
  }

  countries: any[] = [];
  states: any[] = [];
  cities: any[] = [];
  pincodes: any[] = [];

  loadCountries() {
    this.stateService.getCountries().subscribe(res => {
      this.countries = res;
    });
  }

  loadStatesByCountry(countryId: number) {
    this.stateService.getStatesByCountry(countryId).subscribe(res => {
      this.states = res;
    });
  }

  loadCitiesByState(stateId: number) {
    this.stateService.getCitiesByState(stateId).subscribe(res => {
      this.cities = res;
    });
  }

  loadPincodesByCity(cityId: number) {
    this.stateService.getPincodesByCity(cityId).subscribe(res => {
      this.pincodes = res;
    });
  }

  onlyNumbers(event: any) {
    let value = event.target.value;

    value = value.replace(/[^0-9]/g, '');

    if (value.length > 10) {
      value = value.substring(0, 10);
    }

    event.target.value = value;
    this.workDetailsForm.controls['businessNumber'].setValue(value, { emitEvent: false });
  }

  get f() {
    return this.workDetailsForm.controls;
  }

  onFileChange(event: any) {

    if (event.target.files.length > 0) {

      this.selectedFile = event.target.files[0];

    }

  }

  nextStep() {

    this.submitted = true;

    if (this.workDetailsForm.invalid) {

      this.workDetailsForm.markAllAsTouched();

      return;

    }

    const requestBody = {

      "flag": 'I',
      "workDetailId": 0,
      "companyName": this.workDetailsForm.value.companyName,
      "businessNumber": this.workDetailsForm.value.businessNumber,
      "workEmail": this.workDetailsForm.value.workEmail,
      "address": this.workDetailsForm.value.address,
      "country": this.workDetailsForm.value.country,
      "state": this.workDetailsForm.value.state,
      "city": this.workDetailsForm.value.city,
      "zipCode": this.workDetailsForm.value.zipCode,
      "profilePhoto": this.workDetailsForm.value.profilePhoto

    };

    console.log(requestBody);

    this.httpSer
      .httpPost('/UserWorkDetails/SaveUserWorkDetails', requestBody)
      .subscribe({

        next: (response: any) => {

          if (response.type === 'S') {

            alert('Work Details Saved Successfully');
            this.router.navigate(['/registration'])

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
