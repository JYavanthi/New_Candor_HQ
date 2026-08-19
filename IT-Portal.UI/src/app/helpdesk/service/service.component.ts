import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-service',
  templateUrl: './service.component.html',
  styleUrl: './service.component.css'
})
export class ServiceComponent {

  showFilter=false;
  constructor(private route: Router) {
   
  }
  navigaetView(){
    this.route.navigate(['/software'])
  }
}