import { Component } from '@angular/core';

@Component({
  selector: 'app-new-milestone',
  templateUrl: './new-milestone.component.html',
  styleUrl: './new-milestone.component.css'
})
export class NewMilestoneComponent {
  role: string = 'Responsibility';
  internalExternal: string = 'Internal';
  employeeNumber: string = '';
  department: string = '';
  location: string = '';
  contactInfo: string = '';
  vendorName: string = '';
  vendorContact: string = '';
  vendorEmail: string = '';
  raciRows: any[] = [];

  onSubmit() {
    let details = '';
    if (this.internalExternal === 'Internal') {
      details = `Employee Number: ${this.employeeNumber}, Department: ${this.department}, Location: ${this.location}, Contact Info: ${this.contactInfo}`;
    } else {
      details = `Vendor Name: ${this.vendorName}, Contact Number: ${this.vendorContact}, Email ID: ${this.vendorEmail}`;
    }

    this.raciRows.push({
      role: this.role,
      internalExternal: this.internalExternal,
      details: details
    });

    this.clearForm();
  }

  clearForm() {
    this.employeeNumber = '';
    this.department = '';
    this.location = '';
    this.contactInfo = '';
    this.vendorName = '';
    this.vendorContact = '';
    this.vendorEmail = '';
  }

  employeeDetailsVisible:boolean = false;
  vendorDetailsVisible:boolean = false;
  toggleDetails() {
    if (this.internalExternal === 'Internal') {
      this.employeeDetailsVisible = true;
      this.vendorDetailsVisible = false;
    } else {
      this.employeeDetailsVisible = false;
      this.vendorDetailsVisible = true;
    }
  }
}
