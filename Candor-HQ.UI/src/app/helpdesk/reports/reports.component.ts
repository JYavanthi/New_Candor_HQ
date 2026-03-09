import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrl: './reports.component.css'
})
export class ReportsComponent {
  selectedOption: string = '';

  constructor(private router: Router) {

  }

  onOptionSelected(option: string): void {
    if (this.selectedOption == "Issue Report") {
      this.router.navigate(['/issue_report'])
    }
    else if (this.selectedOption == "Issue Resolution") {
      this.router.navigate(['/slaresolution'])
    }
    else {
      this.router.navigate(['/slasummary'])
    }
  }


}
