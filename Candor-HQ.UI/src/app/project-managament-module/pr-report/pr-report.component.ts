import { Component, ElementRef, ViewChild } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';

import { Router } from '@angular/router';
@Component({
  selector: 'app-pr-report',
  templateUrl: './pr-report.component.html',
  styleUrl: './pr-report.component.css',
  animations: [
      trigger('expandCollapseAnimation', [
        state('void', style({
          height: '0',
          opacity: '0'
        })),
        state('*', style({
          height: '*',
          opacity: '1'
        })),
        transition('void <=> *', animate('300ms ease-out')),
      ])
    ]
})
export class PrReportComponent {
  selectedOption: string = '';

  constructor(private router: Router) {

  }
  onOptionSelected(option: string): void {
    
    this.router.navigate([this.selectedOption])
  }
  
}
