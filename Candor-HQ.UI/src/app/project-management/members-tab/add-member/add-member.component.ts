import { Component } from '@angular/core';

@Component({
  selector: 'app-add-member',
  templateUrl: './add-member.component.html',
  styleUrl: './add-member.component.css'
})
export class AddMemberComponent {

  participantType: string = ''; // Default to internal
  employeeID: string = '';
  department: string = '';
  designation: string = '';
  plant: string = '';
  name: string = '';
  company: string = '';
  email: string = '';
  mobile: string = '';
  participant: boolean = false;
  external: boolean = false;
  followerType: string = 'internal'; // Default to internal
  followerEmployeeID: string = '';
  followerDepartment: string = '';
  followerDesignation: string = '';
  followerPlant: string = '';
  followerName: string = '';
  followerCompany: string = '';
  followerEmail: string = '';
  followerMobile: string = '';
  d: any = '';
  onParticipantTypeChange() {
    
    if (this.participantType == 'internal') {
      this.participant = true;
      this.external = false;
    }
    else if (this.participantType == 'external') {
      this.participant = false;
      this.external = true;
    }
  }

}
