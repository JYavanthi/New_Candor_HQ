import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-work-details',
  templateUrl: './work-details.component.html',
  styleUrl: './work-details.component.css'
})
export class WorkDetailsComponent {

  constructor(private router: Router) {

  }

  previousStep() {
    this.router.navigate(['/registration']);
  }

  nextStep() {
    this.router.navigate(['/security']);
  }

}
