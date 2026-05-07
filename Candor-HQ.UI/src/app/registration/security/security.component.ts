import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-security',
  templateUrl: './security.component.html',
  styleUrl: './security.component.css'
})
export class SecurityComponent {

  constructor(private router: Router) {

  }

  onBack() {
    this.router.navigate(['/work-details'])
  }

}
