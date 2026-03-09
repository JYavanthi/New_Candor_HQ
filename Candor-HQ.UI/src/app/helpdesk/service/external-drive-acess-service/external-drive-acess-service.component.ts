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
  selector: 'app-external-drive-acess-service',
  templateUrl: './external-drive-acess-service.component.html',
  styleUrl: './external-drive-acess-service.component.css'
})
export class ExternalDriveAcessServiceComponent {

  constructor(private http: HttpClient) {
    this.fetchDropdownDepartment();
  }

  RequestFor: string = '';
  showProvideNewAccess: boolean = false;
  showRemoveAccess: boolean = false;
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
    if (this.RequestFor === "Provide New Access") {
      this.showProvideNewAccess = true;
      this.showRemoveAccess = false;

    }
    else if (this.RequestFor === "Remove Access") {
      this.showProvideNewAccess = false;
      this.showRemoveAccess = true;

    }
  }



}
