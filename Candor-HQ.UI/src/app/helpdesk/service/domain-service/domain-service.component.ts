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
  selector: 'app-domain-service',
  templateUrl: './domain-service.component.html',
  styleUrl: './domain-service.component.css'
})
export class DomainServiceComponent {



  constructor(private http: HttpClient) {
    this.fetchDropdownDepartment();
  }
  today!: Date;
  RequestFor: string = '';
  showNewDomain: boolean = false;
  showRenewalofDomain: boolean = false;
  showNewSSLCertificate: boolean = false;
  showRenewalofSSLCaertificate:boolean = false;
  showDiscontinuationofDomain:boolean = false;





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
    if (this.RequestFor === "New Domain") {
      this.showNewDomain = true;
      this.showRenewalofDomain = false;
      this. showNewSSLCertificate = false;
      this.showRenewalofSSLCaertificate = false;
      this.showDiscontinuationofDomain = false;
    }

     else if (this.RequestFor === "Renewal of Domain") {
      this.showNewDomain = false;
      this.showRenewalofDomain = true;
      this. showNewSSLCertificate = false;
      this.showRenewalofSSLCaertificate = false;
      this.showDiscontinuationofDomain = false;
    }

    else if (this.RequestFor === "New SSL Certificate") {
      this.showNewDomain = false;
      this.showRenewalofDomain = false;
      this. showNewSSLCertificate = true;
      this.showRenewalofSSLCaertificate = false;
      this.showDiscontinuationofDomain = false;
  
    }

    else if (this.RequestFor === "Renewal of SSL Caertificate") {
      this.showNewDomain = false;
      this.showRenewalofDomain = false;
      this. showNewSSLCertificate = false;
      this.showRenewalofSSLCaertificate = true;
      this.showDiscontinuationofDomain = false;
    }

    else if (this.RequestFor === "Discontinuation of Domain") {
      this.showNewDomain = false;
      this.showRenewalofDomain = false;
      this. showNewSSLCertificate = false;
      this.showRenewalofSSLCaertificate = false;
      this.showDiscontinuationofDomain = true;
    }


  }

}
