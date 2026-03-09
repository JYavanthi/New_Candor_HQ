import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { response } from 'express';
import { ActivatedRoute, Router } from '@angular/router';

import { environment } from '@environments/environment'

   @Component({
  selector: 'app-project-management',
  templateUrl: './project-management.component.html',
  styleUrl: './project-management.component.css'
})
   export class ProjectManagementComponent 
   {

   constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute) {
    
  }


  ngOnInit(): void {
    
  }
 

}

