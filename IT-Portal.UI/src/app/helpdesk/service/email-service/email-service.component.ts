import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';import { environment } from '@environments/environment';



interface DropdownDepartmentItem {
  itemdepartment_id: number;
  itemdepartment_text: string;
}

interface DropdownCatItem {
  itemcat_id: number;
  itemcat_text: string;
}

@Component({
  selector: 'app-email-service',
  templateUrl: './email-service.component.html',
  styleUrl: './email-service.component.css'
})



export class EmailServiceComponent {

  constructor(private http: HttpClient) {
    this.fetchDropdownDepartment();
  }
  today!: Date;
  RequestFor: string = '';
  showNewEmailID: boolean = false;
  showRenameEmailID: boolean = false;
  showIncreaseStorage: boolean = false;
  showDisableEmailID: boolean = false;
  showCreateNewMailGroup: boolean = false;
  showMobileAccess: boolean = false;
  showExternalAccess: boolean = false;
  showCommunicatetoExternalDomains: boolean = false;
  showTraining: boolean = false;
  SelectPlant: string = '';
  dropdownListDepartment: DropdownDepartmentItem[] = [];
  impactedPlant: any = '';




  
  private apiurl = environment.apiurls;

  dropdownDepartmentSettings = {
    idField: 'itemdepartment_id',
    textField: 'itemdepartment_text',
  };

  dropdownListCat: DropdownCatItem[] = [];
  dropdownCatSettings = {
    idField: 'itemcat_id',
    textField: 'itemcat_text',
  };

  selecteddepartmentNames: DropdownDepartmentItem[] = [];

  onSelecteddepartmentItemsChange(): void {
    console.log("this is the plant ids will come", this.impactedPlant)
    this.impactedPlant = this.selecteddepartmentNames.map((item: any) => item.itemdepartment_id);
  }

  fetchDropdownDepartment(): void {
    const apiUrl = this.apiurl + '/Plantid';
    this.http.get<any[]>(apiUrl).subscribe(
      (data) => {
        this.dropdownListDepartment = data.map(item => ({
          itemdepartment_id: item.id,
          itemdepartment_text: item.code
        }));
      },
      (error) => {
        console.error('Error fetching dropdown data:', error);
      }
    );
  }



  RequestForFunc(){
    if (this.RequestFor === "New Email ID") {
      this.showNewEmailID = true;
      this.showRenameEmailID = false;
      this.showIncreaseStorage = false;
      this.showDisableEmailID = false;
      this.showCreateNewMailGroup = false;
      this.showMobileAccess = false;
      this.showExternalAccess= false;
      this.showCommunicatetoExternalDomains= false;
      this.showTraining= false;
    }

    else if (this.RequestFor === "Rename Email ID") {
      this.showNewEmailID = false;
      this.showRenameEmailID = true;
      this.showIncreaseStorage = false;
      this.showDisableEmailID = false;
      this.showCreateNewMailGroup = false;
      this.showMobileAccess = false;
      this.showExternalAccess= false;
      this.showCommunicatetoExternalDomains= false;
      this.showTraining= false;
    }

    else if (this.RequestFor === "Increase Storage") {
      this.showNewEmailID = false;
      this.showRenameEmailID = false;
      this.showIncreaseStorage = true;
      this.showDisableEmailID = false;
      this.showCreateNewMailGroup = false;
      this.showMobileAccess = false;
      this.showExternalAccess= false;
      this.showCommunicatetoExternalDomains= false;
      this.showTraining= false;
    }

    else if (this.RequestFor === "Disable Email ID") {
      this.showNewEmailID = false;
      this.showRenameEmailID = false;
      this.showIncreaseStorage = false;
      this.showDisableEmailID = true;
      this.showCreateNewMailGroup = false;
      this.showMobileAccess = false;
      this.showExternalAccess= false;
      this.showCommunicatetoExternalDomains= false;
      this.showTraining= false;
    }

    else if (this.RequestFor === "Create New Mail Group") {
      this.showNewEmailID = false;
      this.showRenameEmailID = false;
      this.showIncreaseStorage = false;
      this.showDisableEmailID = false;
      this.showCreateNewMailGroup = true;
      this.showMobileAccess = false;
      this.showExternalAccess= false;
      this.showCommunicatetoExternalDomains= false;
      this.showTraining= false;
    }

    else if (this.RequestFor === "Mobile Access") {
      this.showNewEmailID = false;
      this.showRenameEmailID = false;
      this.showIncreaseStorage = false;
      this.showDisableEmailID = false;
      this.showCreateNewMailGroup = false;
      this.showMobileAccess = true;
      this.showExternalAccess= false;
      this.showCommunicatetoExternalDomains= false;
      this.showTraining= false;
    }

    else if (this.RequestFor === "External Access") {
      this.showNewEmailID = false;
      this.showRenameEmailID = false;
      this.showIncreaseStorage = false;
      this.showDisableEmailID = false;
      this.showCreateNewMailGroup = false;
      this.showMobileAccess = false;
      this.showExternalAccess= true;
      this.showCommunicatetoExternalDomains= false;
      this.showTraining= false;
    }
    else if (this.RequestFor === "Communicate to External Domains") {
      this.showNewEmailID = false;
      this.showRenameEmailID = false;
      this.showIncreaseStorage = false;
      this.showDisableEmailID = false;
      this.showCreateNewMailGroup = false;
      this.showMobileAccess = false;
      this.showExternalAccess= false;
      this.showCommunicatetoExternalDomains= true;
      this.showTraining= false;
    }

    else if (this.RequestFor === "Training") {
      this.showNewEmailID = false;
      this.showRenameEmailID = false;
      this.showIncreaseStorage = false;
      this.showDisableEmailID = false;
      this.showCreateNewMailGroup = false;
      this.showMobileAccess = false;
      this.showExternalAccess= false;
      this.showCommunicatetoExternalDomains= false;
      this.showTraining= true;
    }


  }






}
