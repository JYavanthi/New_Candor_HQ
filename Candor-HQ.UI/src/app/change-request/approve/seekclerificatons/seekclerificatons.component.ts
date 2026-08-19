import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';import { environment } from '@environments/environment';

@Component({
  selector: 'app-seekclerificatons',
  templateUrl: './seekclerificatons.component.html',
  styleUrl: './seekclerificatons.component.css'
})
export class SeekclerificatonsComponent {

  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) { }

  private apiurl = environment.apiurls

/*
  ngOnInit(): void {
    this.getupdatyevalue(this.itcrid);
    this.getclassification();
    this.getcategory();
    this.getnature();
    this.getplant();
    this.getcrdata();
    this.getcategorytype();
    this.getreference();

    this.getidupdate();

    
  }
  
  showInitiator: boolean = false;
  showRiskQ: boolean = false;
  tabs: any[] = [];
  numberOfTabs: number = 1;
  plantData: any[] = [];
  
  approver: any = '';
  appdate: any = '';
  attach: any = '';
  remark: any = '';
  comment: any = '';
  //
  itcrid: any = '';
  supportId: any = '';
  classificationId: any = '';
  categoryId: any = '';
  categorytypeid: any = '';
  crowner: any = '';
  crdate: any = '';
  changerequestedby: any = '';
  referenceid: any = '';
  referencetype: any = '';
  crinitiatedFor: any = '';
  changeType: any = '';
  natureOfChange: any = '';
  priorityType: any = '';
  plantId: any = '';
  gxpclassification: any = '';
  changeControlNo: any = '';
  changeControlDt: any = '';
  changeControlAttach: any = '';
  changeDesc: any = '';
  reasonForChange: any = '';
  alternateConsidetation: any = '';
  impactNotDoing: any = '';
  triggeredBy: any = '';
  benefits: any = '';
  estimatedCost: any = '';
  estimatedCostCurr: any = '';
  estimatedEffort: any = '';
  estimatedEffortUnit: any = '';
  estimatedDateCompletion: any = '';
  rollbackPlan: any = '';
  backoutPlan: any = '';
  downTimeRequired: any = '';
  downTimeFromDate: any = '';
  downTimeToDate: any = '';
  approvedBy: any = '';
  approvedDt: any = '';
  createdBy: any = '';
  createdDt: any = '';
  modifiedBy: any = '';
  modifiedDt: any = '';
  selectedCategory: any = '';
  changecntroldt: any = '';
  status: string = "Submitted";
  toggleInitiatorFields() {
    this.showInitiator = !this.showInitiator;
  }

  toggleField() {
    this.showRiskQ = !this.showRiskQ;
  }

  toggleCollapsible(content: HTMLDivElement): void {
    content.style.display = (content.style.display === 'block') ? 'none' : 'block';
  }

  addMore() {
    this.plantData.push({
      selectPlant: '',
      controlNumber: '',
      controlDate: '',
      attachment: null
    });
  }

  toggleInitiatorField(index: number) {
    this.tabs[index].showInitiator = !this.tabs[index].showInitiator;
  }

  removeTab() {
    if (this.tabs.length > 0) {
      this.tabs.pop();
    }
  }

  update(index: number) {
    // Implement the update logic here
  }

  delete(index: number) {
    this.plantData.splice(index, 1);
  }

  handleFileInput(event: any, index: number) {
    const file = event.target.files[0];
    this.plantData[index].attachment = file;
  }
  getidupdate() {
    this.itcrid = this.route.snapshot.paramMap.get('id');
  }

  categorydata: any[] = [];

  getcategory() {
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
        this.categorydata = response;
        console.log(this.categorydata)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  Natureofchange: any[] = [];

  getnature() {

    const apiUrls = this.apiurl + '/NatureofChange'
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
        this.Natureofchange = response;
        console.log(this.Natureofchange)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  classifications: any[] = [];

  getclassification() {

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
        this.classifications = response;
        console.log(this.classifications)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  plantcode: any[] = [];
  plant: any;
  getplant() {

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

  changerequest: any[] = [];

  getcrdata() {

    const apiUrls = this.apiurl + '/ChangeRequest/Getrequest'
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
        this.changerequest = response;
        console.log(this.changerequest)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  systemlandscape: any[] = [];

  getsystemlandscape() {

    const apiUrls = this.apiurl + '/SystemLandscape'
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
        this.systemlandscape = response;
        console.log(this.systemlandscape)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  categorytype: any[] = [];

  getcategorytype() {

    const apiUrls = this.apiurl + '/CategoryTyp'
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
        this.categorytype = response;
        console.log(this.categorytype)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  referenceapi: any[] = [];
  updatevalue: any[] = [];
  getreference() {

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
        this.referenceapi = response;
        console.log(this.classifications)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }
  getupdatyevalue(itcrid: any) {
    
    const apiUrls: any = this.apiurl + '/ChangeRequest/Getrequest';
    const requestBody = {

    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };

    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.updatevalue = response.filter((item: any) => item.itcrid.toString() === itcrid.toString());

        console.log("Update_value", this.updatevalue)

      },
      (error: any) => {
        console.log('Post request failed', error);
      }
    );
  }

  Updatecr() {

    const apiUrl = "https://localhost:7236/api/ChangeRequest/PassingModel/";
    const requestBody = {
      "type": "U",
      "itcrid": this.itcrid,
      "supportId": 1,
      "classificationId": this.classificationId,
      "categoryId": this.categoryId,
      "crowner": this.updatevalue[0].crowner,
      "crrequestedBy": this.updatevalue[0].changerequestedby,
      "referenceId": this.updatevalue[0].referenceid,
      "referenceTyp": this.updatevalue[0].referenceTyp,
      "crdate": this.crdate,
      "crinitiatedFor": this.updatevalue[0].crinitiatedFor,
      "status": "New",
      "categoryTypeId": 3,
      "natureOfChange": this.natureOfChange,
      "priorityType": this.priorityType,
      "plantId": this.plantId,
      "gxpclassification": true,
      "changeControlNo": this.updatevalue[0].changeControlNo,
      "changeControlDt": this.updatevalue[0].changeControlDt,
      "changeControlAttach": true,
      "changeDesc": this.updatevalue[0].changeDesc,
      "reasonForChange": this.updatevalue[0].reasonForChange,
      "alternateConsidetation": this.updatevalue[0].alternateConsidetation,
      "impactNotDoing": this.updatevalue[0].impactNotDoing,
      "triggeredBy": this.updatevalue[0].triggeredBy,
      "benefits": this.updatevalue[0].benefits,
      "estimatedCost": this.updatevalue[0].estimatedCost,
      "estimatedCostCurr": this.updatevalue[0].estimatedCostCurr,
      "estimatedEffort": this.updatevalue[0].estimatedEffort,
      "estimatedEffortUnit": this.updatevalue[0].estimatedEffortUnit,
      "estimatedDateCompletion": this.updatevalue[0].estimatedDateCompletion,
      "rollbackPlan": this.updatevalue[0].rollbackPlan,
      "backoutPlan": this.updatevalue[0].backoutPlan,
      "downTimeRequired": true,
      "downTimeFromDate": "2024-02-10T09:21:40.357Z",
      "downTimeToDate": "2024-02-10T09:21:40.357Z",
      "approvedBy": "string",
      "approvedDt": "string",
      "createdBy": "string",
      "createdDt": "2024-02-10T09:21:40.357Z",
      "modifiedBy": "string",
      "modifiedDt": "2024-02-10T09:21:40.357Z"
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.http.post(apiUrl, requestBody, httpOptions).subscribe(
      (response: any) => {
        
      },
      (error: any) => {
        console.log('Post request failed', error);
      }
    );
    this.router.navigate(['/change-request']);
  }

  
  submitApprove() {

    const apiUrl = "https://localhost:7236/api/ChangeRequest/PassingModel/";
    const requestBody = {
      "type": "U",
      "itcrid": this.itcrid,
      "supportId": 1,
      "classificationId": this.updatevalue[0].classificationId,
      "categoryId": this.updatevalue[0].categoryId,
      "crowner": this.updatevalue[0].crowner,
      "crrequestedBy": this.updatevalue[0].changerequestedby,
      "referenceId": this.updatevalue[0].referenceid,
      "referenceTyp": this.updatevalue[0].referenceTyp,
      "crdate": this.crdate,
      "crinitiatedFor": this.updatevalue[0].crinitiatedFor,
      "status": this.status,
      "categoryTypeId": 3,
      "natureOfChange": this.updatevalue[0].natureOfChange,
      "priorityType": this.updatevalue[0].priorityType,
      "plantId": this.updatevalue[0].plantId,
      "gxpclassification": true,
      "changeControlNo": this.updatevalue[0].changeControlNo,
      "changeControlDt": this.updatevalue[0].changeControlDt,
      "changeControlAttach": true,
      "changeDesc": this.updatevalue[0].changeDesc,
      "reasonForChange": this.updatevalue[0].reasonForChange,
      "alternateConsidetation": this.updatevalue[0].alternateConsidetation,
      "impactNotDoing": this.updatevalue[0].impactNotDoing,
      "triggeredBy": this.updatevalue[0].triggeredBy,
      "benefits": this.updatevalue[0].benefits,
      "estimatedCost": this.updatevalue[0].estimatedCost,
      "estimatedCostCurr": this.updatevalue[0].estimatedCostCurr,
      "estimatedEffort": this.updatevalue[0].estimatedEffort,
      "estimatedEffortUnit": this.updatevalue[0].estimatedEffortUnit,
      "estimatedDateCompletion": this.updatevalue[0].estimatedDateCompletion,
      "rollbackPlan": this.updatevalue[0].rollbackPlan,
      "backoutPlan": this.updatevalue[0].backoutPlan,
      "downTimeRequired": true,
      "downTimeFromDate": "2024-02-10T09:21:40.357Z",
      "downTimeToDate": "2024-02-10T09:21:40.357Z",
      "approvedBy": "string",
      "approvedDt": "string",
      "createdBy": "string",
      "createdDt": "2024-02-10T09:21:40.357Z",
      "modifiedBy": "string",
      "modifiedDt": "2024-02-10T09:21:40.357Z"
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.http.post(apiUrl, requestBody, httpOptions).subscribe(
      (response: any) => {
        console.log(response);
      },
      (error: any) => {
        console.log('Post request failed', error);
      }
    );
    this.router.navigate(['/change-request']);
  }
*/
}
