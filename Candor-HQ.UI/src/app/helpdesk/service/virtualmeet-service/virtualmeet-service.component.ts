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
  selector: 'app-virtualmeet-service',
  templateUrl: './virtualmeet-service.component.html',
  styleUrl: './virtualmeet-service.component.css'
})
export class VirtualmeetServiceComponent {

  constructor(private http: HttpClient) {
    this.fetchDropdownDepartment();
  }

  RequestFor: string = '';
  showNewID: boolean = false;
  showRequestforMeetingLink: boolean = false;
  today!: Date;
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


  RequestForFunc() {
    if (this.RequestFor === "New ID") {
      this.showNewID = true;
      this.showRequestforMeetingLink = false;

    }
    else if (this.RequestFor === "Request for Meeting Link") {
      this.showNewID = false;
      this.showRequestforMeetingLink = true;

    }
  }














}
