import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PasscrdataService } from '../../change-request/passcrdata.service';import { environment } from '@environments/environment';
import { Item } from '@syncfusion/ej2-navigations';
import { HttpServiceService } from 'shared/services/http-service.service';
import { AnyNsRecord } from 'dns';
import { UserInfoSerService } from 'app/services/user-info-ser.service';

interface DropdownDepartmentItem {
  itemdepartment_id: number;
  itemdepartment_text: string;
}
@Component({
  selector: 'app-view-supportteam',
  templateUrl: './view-supportteam.component.html',
  styleUrl: './view-supportteam.component.css'
})
export class ViewSupportteamComponent {
  user:any
  constructor(private http: HttpClient,private userInfo : UserInfoSerService,
    public httpser: HttpServiceService, private router: Router, private route: ActivatedRoute, private routeservice: PasscrdataService) {
      this.user = userInfo.getUser()
     }

  ngOnInit(): void {
    this.getidupdate();
    this.getupdatyevalue();

  }

  private apiurl = environment.apiurls;

  supportteamId: any;
  formFields: any[] = [];
  getidupdate() {
    this.supportteamId = this.route.snapshot.paramMap.get('id');
  }

  updatevalue: any[] = [];
  varofresponse: any[] = [];
  value: any= '';
  getupdatyevalue() {
    const apiUrls: any ='/SupportTeam/supportteam';
    const requestBody = {
      supportId:parseInt(this.supportteamId)
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.httpser.httpGet(apiUrls,requestBody).subscribe(
      (response: any) => {
        this.updatevalue = response
        this.updatevalue = this.updatevalue.sort((a, b) => (a.level < b.level ? -1 : 1));

        this.updatevalue = this.updatevalue.filter((item: any) => {
          return item.categoryId === item.categoryId;
        });

        this.updatevalue = this.updatevalue.filter((item: any) => {
          return item.classificationId === item.classificationId;
        });

        const uniqueLevels = [...new Set(this.updatevalue.map(item => item.level))];
        this.updatevalue = uniqueLevels.map(level => {
          const itemsForLevel = this.updatevalue.filter(item => item.level === level);
          return {
            ...itemsForLevel[0],
            approverstage: itemsForLevel.map(item => item.approverstage)
          };

        });
        this.value = this.updatevalue[0]
        this.approverLevelSelect()
        setTimeout(() => {
          if (this.value.supportName == "Helpdesk") {
            this.Helpdeskbutton = true;
            this.ApproverButton = false;
          }
          else {
            this.Helpdeskbutton = false;
            this.ApproverButton = true;
          }
        }, 1000);

      },
      (error: any) => {
      }
    );
  }

  isActive: boolean = false;
  approvername: any = '';
  approverstage: string = '';
  IsAdmin: boolean = false;
  IsSuperAdmin: boolean = false;
  IsApprove: boolean = false;
  IsEngineer: boolean = false;
  IsAnalyst: boolean = false;
  plantId: any = '';
  ApproverN: any = '';
  ApproverC: any = '';
  ApproverR: any = '';
  approverstagen: any = '';
  approverstagec: any = '';
  approverstager: any = '';
  ApproverN2: any = '';
  ApproverC2: any = '';
  ApproverR2: any = '';
  approverstagen2: any = '';
  approverstagec2: any = '';
  approverstager2: any = '';
  ApproverN3: any = '';
  ApproverC3: any = '';
  ApproverR3: any = '';
  approverstagen3: any = '';
  approverstagec3: any = '';
  approverstager3: any = '';
  systemlandscape: any[] = [];
  categorytype: any[] = [];
  checkcatid: any = '';
  catidfilter: any = '';
  categorydata: any = '';
  supportTeamId: any = '';
  supportid: any = '';
  supportname: any = '';
  approverlevel: boolean = false;
  approverlevel2: boolean = false;
  approverlevel3: boolean = false;
  approverstage1: any = '';
  approverstage2: any = '';
  approverstage3: any = '';
  messagesuccess: boolean = false;
  messageerror: boolean = false;
  errormessage: any;
  impactedPlant: any = '';
  showMiniForm: boolean = true;
  superadminaccess: any;
  supportId: any = '';
  selecteddepartmentNames: DropdownDepartmentItem[] = [];
  today: any = '';

  approverLevelSelect(){
    let apprLevelArray = this.updatevalue.map((m:any)=>m.level)
    this.approverlevel=apprLevelArray?.includes(1)
    this.approverlevel2=apprLevelArray?.includes(2)
    this.approverlevel3=apprLevelArray?.includes(3)

    this.setApproveStage()

  }

  setApproveStage(){
   let  apprvStageArray = this.updatevalue.filter((m:any)=>m.level == 1).map((m:any)=>m.approverstage)[0]

    this.ApproverN=apprvStageArray?.includes("N")
    this.ApproverR=apprvStageArray?.includes("R")
    this.ApproverC=apprvStageArray?.includes("C")

    let  apprvStageArray1= this.updatevalue.filter((m:any)=>m.level == 2).map((m:any)=>m.approverstage)[0]
    // let apprvStageArray1 = this.updatevalue.map((m:any)=>m.approverstage)
    this.ApproverN2=apprvStageArray1?.includes("N")
    this.ApproverR2=apprvStageArray1?.includes("R")
    this.ApproverC2=apprvStageArray1?.includes("C")

    let  apprvStageArray2 = this.updatevalue.filter((m:any)=>m.level == 3).map((m:any)=>m.approverstage)[0]
    // let apprvStageArray2 = this.updatevalue.map((m:any)=>m.approverstage)
    this.ApproverN3=apprvStageArray2?.includes("N")
    this.ApproverR3=apprvStageArray2?.includes("R")
    this.ApproverC3=apprvStageArray2?.includes("C")

  }
  onSelecteddepartmentItemsChange(): void {
    this.impactedPlant = this.selecteddepartmentNames.map((item: any) => item.itemdepartment_id);
  }

  toggleMiniForm() {
    this.showMiniForm = !this.showMiniForm;
    if (this.updatevalue)
    console.log("ShowMini",this.showMiniForm)
  }
  addFormField() {
    this.formFields.push({});
  }

  removeFormField() {
    this.formFields.pop();
  }

  removesupportTeam(approverstage:any,level:any,event:any){
    if(!event?.target?.checked){
      return
    }
    let apiUrl = '/ApproverRemoved/UpdateSupportTeam'
    let param = {
      "supportTeamID": this.supportTeamId,
      "plantID": Number(this.updatevalue[0].code),
      "supportID": this.supportTeamId,
      "categoryID": Number(this.updatevalue[0].categoryName),
      "classificationID": Number(this.updatevalue[0].classificationName),
      "approverstage": approverstage,
      "level": level,
      "createdBy": this.user?.empData?.employeeNo
    }
  }
  postSupportTeam() {
    if (this.ApproverN) {
      this.approverstagen = 'N'
    }
    if (this.ApproverR) {
      this.approverstager = 'R'
    }
    if (this.ApproverC) {
      this.approverstagec = 'C'
    }
    if (this.ApproverN2) {
      this.approverstagen2 = 'N'
    }
    if (this.ApproverR2) {
      this.approverstager2 = 'R'
    }
    if (this.ApproverC2) {
      this.approverstagec2 = 'C'
    }
    if (this.ApproverN3) {
      this.approverstagen3 = 'N'
    }
    if (this.ApproverR3) {
      this.approverstager3 = 'R'
    }
    if (this.ApproverC3) {
      this.approverstagec3 = 'C'
    }
    if (this.approverlevel) {
      this.approverstage1 = 1
    }
    if (this.approverlevel2) {
      this.approverstage2 = 2
    }
    if (this.approverlevel3) {
      this.approverstage3 = 3
    }

    ;
    const apiUrl = this.apiurl + '/SupportTeam/PostSupportTeam';
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    const requestBody = {
      "flag": "U",
      "supportTeamId": 0,
      "email": this.updatevalue[0].email ? this.updatevalue[0].email : "",
      "firstName": this.updatevalue[0].firstName ? this.updatevalue[0].firstName : "",
      "middleName": this.updatevalue[0].middleName ? this.updatevalue[0].middleName : "",
      "lastName": this.updatevalue[0].lastName ? this.updatevalue[0].lastName : "",
      "imgUrl": this.updatevalue[0].imgUrl ? this.updatevalue[0].imgUrl : "",
      "designation": this.updatevalue[0].designation ? this.updatevalue[0].designation : "",
      "role": 'null',
      "empId": this.updatevalue[0].empId,
      "isActive": this.updatevalue[0].isActive,
      "dol": this.updatevalue[0].dol ?  new Date(this.updatevalue[0].dol).toISOString(): null,
      "dob": this.updatevalue[0].dob ? new Date(this.updatevalue[0].dob).toISOString() : null,
      "isAdmin": this.IsAdmin,
      "isSuperAdmin": this.IsSuperAdmin,
      "isApprover": this.IsApprove,
      "isChangeAnalyst": this.IsAnalyst,
      "isSupportEngineer": this.IsEngineer,
      "plantId": this.value?.plantId,
      "supportId": Number(this.value?.supportId),
      "categoryId": this.value?.categoryId,
      "classificationId": this.value.classificationId,
      "approverstageCR": this.approverstagen,
      "approverstageR": this.approverstager,
      "approverstageC": this.approverstagec,
      "level": Number(this.approverstage1),
      "approverstage2CR": this.approverstagen2,
      "approverstage2R": this.approverstager2,
      "approverstage2C": this.approverstagec2,
      "level2": Number(this.approverstage2),
      "approverstage3CR": this.approverstagen3,
      "approverstage3R": this.approverstager3,
      "approverstage3C": this.approverstagec3,
      "level3": Number(this.approverstage3),
      "createdBy": Number(this.user?.empData?.employeeNo),
      "createdDate": new Date().toISOString(),
      "supportIds": []
    };
    setTimeout(() => {
      this.http.post(apiUrl, requestBody, httpOptions).subscribe(
        (response: any) => {
          this.messagesuccess = true;
        },
        (error: any) => {
          this.messageerror = true;
          this.errormessage = error;
        }
      );
    }, 500);
  }
  Helpdeskbutton: boolean = false;
  ApproverButton: boolean = true;


}
