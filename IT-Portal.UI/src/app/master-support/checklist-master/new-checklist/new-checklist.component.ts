import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';import { environment } from '@environments/environment';
import { PasscrdataService } from '../../../change-request/passcrdata.service';

interface DropdownItem {
  item_id: number;
  item_text: string;
}

@Component({
  selector: 'app-new-checklist',
  templateUrl: './new-checklist.component.html',
  styleUrl: './new-checklist.component.css'
})
export class NewChecklistComponent {

  dropdownList: DropdownItem[] = [];
  dropdownSettings = {
    idField: 'item_id',
    textField: 'item_text',
  };

  supportid: any[] = [];
  constructor(private http: HttpClient, private routeservice: PasscrdataService, private router: Router) {
    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);

    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
  }
  ngOnInit() {
    this.getCategory();
    this.getsupport();
    this.getPlantid();
    this.getClasification();
    this.fetchDropdownData();
  }
  private apiurl = environment.apiurls;

  fetchDropdownData(): void {
    const apiUrl = this.apiurl + '/Plantid'; // Replace with your API endpoint
    this.http.get<any[]>(apiUrl).subscribe(
      (data) => {
        this.dropdownList = data.map(item => ({
          item_id: item.id,
          item_text: item.code // Assuming your API response has 'id' and 'name' fields
        }));
      },
      (error) => {
        console.error('Error fetching dropdown data:', error);
      }
    );
  }

  selectedlocationNames: DropdownItem[] = [];
  checklistLocation: any = '';

  onSelectedItemsChange(): void {
    this.checklistLocation = this.selectedlocationNames.map((item: any) => item.item_id);
  }

  today: any = '';
  mandatoryFlags: boolean = true;
  checklistTitle: any[] = [];
  checklistDesc: any[] = [];
  categoryID: any[] = [];
  classificationID: any[] = [];
  plantID: any[] = [];
  supportID: any[] = [];
  messagesuccess: boolean = false;
  errormessage: boolean = false;
  messageerror: boolean = false;

  postCheckList() {
    const apiUrl = this.apiurl + '/CheckList/ChecklistPost';
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.checklistLocation.forEach((plantId: any) => {
        const requestBody = {
          "flag": "I",
          "itChecklistID": 0,
          "plantID": plantId,
          "supportID": this.supportID,
          "categoryID": this.categoryID,
          "classificationID": this.classificationID,
          "checklistTitle": this.checklistTitle,
          "checklistDesc": this.checklistDesc,
          "mandatoryFlag": this.mandatoryFlags,
          "createdBy": this.supportid,
          "createdDt": this.today,
          "modifiedBy": this.supportid,
          "modifiedDt": this.today
        };
        setTimeout(() => {
          this.http.post(apiUrl, requestBody, httpOptions).subscribe(
            (response: any) => {
              console.log(response);
              this.messagesuccess = true;
            },
            (error: any) => {
              console.log('Post request failed', error);
              this.messageerror = true;
              this.errormessage = error;
            }
          );
        }, 500);
    });
  }

  navigatesuccess() {
    this.router.navigate(['/viewcheklist']);
  }

  closeNotification() {
    this.messageerror = false;
  }


  categoryName: any[] = [];
  getCategory() {

    const apiUrls = this.apiurl + '/Category'
    const requestBody = {

    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls, requestBody).subscribe(
      (response: any) => {
        console.log(response);
        this.categoryName = response
        console.log(this.categoryName)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  caclasification: any[] = [];
  getClasification() {

    const apiUrls = this.apiurl + '/Classification'
    const requestBody = {

    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls, requestBody).subscribe(
      (response: any) => {
        console.log(response);
        this.caclasification = response
        console.log(this.categoryName)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  support: any[] = [];
  getsupport() {

    const apiUrls = this.apiurl + '/ITSupport/GetSupport'
    const requestBody = {

    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls, requestBody).subscribe(
      (response: any) => {
        console.log(response);
        this.support = response;
        console.log(this.support)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  plantcode: any[] = [];
  getPlantid() {

    const apiUrls = this.apiurl + '/Plantid'
    const requestBody = {

    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls, requestBody).subscribe(
      (response: any) => {
        console.log(response);
        this.plantcode = response;
        console.log(this.plantcode)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }
}
