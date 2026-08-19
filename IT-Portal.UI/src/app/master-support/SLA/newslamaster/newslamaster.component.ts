import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { PasscrdataService } from '../../../change-request/passcrdata.service';
import { ActivatedRoute, Router } from '@angular/router';import { environment } from '@environments/environment';
import { FormBuilder, FormControl,FormGroup } from '@angular/forms';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { map, startWith } from 'rxjs';
import { MatAutocomplete, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { HttpServiceService } from 'shared/services/http-service.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';

@Component({
  selector: 'app-newslamaster',
  templateUrl: './newslamaster.component.html',
  styleUrl: './newslamaster.component.css'
})
export class NewslamasterComponent {
  supportteammemid: any;
  supportList: any;
  filteredAssigneesList: any[]=[];
  @ViewChild(MatAutocomplete) auto!: MatAutocomplete;
  selectedAssignee: any;
  filteredSypListEsc1: any[]=[];
  filteredSypListEsc2: any[]=[];
  classiFicationList: any;
  supportTeamId: any;
  SlaId: any=0;
  slaData: any;
  user: any;
  supportid: any;
  constructor(private http: HttpClient, private routeservice: PasscrdataService, private router: Router,
    private fb:FormBuilder, private getSupportList: GetEmployeeInfoService,private userInfo: UserInfoSerService,
    private route: ActivatedRoute,private httpService: HttpServiceService) {
      
    this.route.queryParamMap.subscribe(params => {
      this.SlaId = params.get('id');
    });
    
    this.user = this.userInfo.getUser();
    this.supportid = this.user?.supportTeamData?.supportTeamId;
  }
  categorydata: any = '';
  selectedCategory:any ='';
  catidfilter:any='';
  categorytype:any='';
  categoryTypeId:any='';
  categoryName: any[] = [];
  checklist: any[] = [];
  plantcode: any[] = [];
  plantId:any='';
  classificationId:any='';
  private apiurl = environment.apiurls;
  slaForm!: FormGroup;
  
  async ngOnInit() {
    this.slaForm=this.fb.group({
      category:'',
      categoryType:'',
      WaitTime:'',
      WaitTimeUnit:'',
      AssignedTo:'',
      PlantId:'',
      Escalation1:'',
      WaitTimeEscal1:'',
      WaitTimeUnitEscal1:'',
      Escalation2:'',
      WaitTimeEscal2:'',
      WaitTimeUnitEscal2:'',
      slaId:'',
      Classification : ''
    })
    if(this.SlaId!=null&&this.SlaId!=undefined&&this.SlaId!=0){
    await this.getSlaList();
    }
    await this.getCategory();
    await this.getplant();
    await this.getsupportTeamList();
    await this.getClassification();
  }
  patchValue() {
    let filteredAssigneesList = [{ empId:this.slaData.assignedTo }]
    this.filteredAssigneesList = filteredAssigneesList
    
    let filteredSypListEsc1 = [{ empId:this.slaData.escalation1 }]
    this.filteredSypListEsc1 = filteredSypListEsc1
    
    let filteredSypListEsc2 = [{ empId:this.slaData.escalation2 }]
    this.filteredSypListEsc2 = filteredSypListEsc2

    this.slaForm.patchValue({
      WaitTime:this.slaData.waitTime,
      WaitTimeUnit:this.slaData.waitTimeUnit,
      WaitTimeEscal1:this.slaData.waitTimeEscal1,
      WaitTimeUnitEscal1:this.slaData.waitTimeUnitEscal1,
      WaitTimeEscal2:this.slaData.waitTimeEscal1,
      WaitTimeUnitEscal2:this.slaData.waitTimeUnitEscal2,
      AssignedTo:this.slaData.assignedTo,
      Escalation1:this.slaData.escalation1,
      Escalation2:this.slaData.escalation2
    })
    console.log(this.filteredAssigneesList)
    console.log(this.slaForm.controls['AssignedTo'].value)
  }

  getSlaList() {
    const getSlaList= '/SlaMaster/GetSlaList'
    let param = {
      id : this.SlaId
    }
    this.httpService.httpGet(getSlaList,param).subscribe(res=>{
      this.slaData = res[0]
      this.patchValue()
    })

  }

  getClassification(){
    
    const apiUrls = this.apiurl + '/Classification'
    const requestBody = {

    }
    this.http.get(apiUrls, requestBody).subscribe(
      (response: any) => {
        this.classiFicationList = response
        this.slaForm.controls['Classification'].setValue(this.slaData?this.slaData['classificationId']:'')
      }
    )
  }
  filterItems(event:any) {
    this.filteredAssigneesList = this.supportList.filter((a:any)=>{
      return a.firstName.includes(event.data.toLowerCase())||a.empId.toString().includes(event.data.toLowerCase())
    })
    this.slaForm.controls['AssignedTo'].setValue(this.slaData?this.slaData['assignedTo']:'')
  }

  filterItemsEsc1(event:any) {
    this.filteredSypListEsc1 = this.supportList.filter((a:any)=>{
      return a.firstName.includes(event.data.toLowerCase())||a.empId.toString().includes(event.data.toLowerCase())
    })
    this.slaForm.controls['Escalation1'].setValue(this.slaData?this.slaData['escalation1']:'')
  }

  filterItemsEsc2(event:any) {
    this.filteredSypListEsc2 = this.supportList.filter((a:any)=>{
      return a.firstName.includes(event.data.toLowerCase())||a.empId.toString().includes(event.data.toLowerCase())
    })
    this.slaForm.controls['Escalation2'].setValue(this.slaData?this.slaData['escalation2']:'')
  }

  displayFn(item: any): string {
    return item
  }

  displayFnEsc1(item: any): string {
    return item
  }

  displayFnEsc2(item: any): string {
    return item
  }

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
        this.plantcode = response;
        this.slaForm.controls['PlantId'].setValue(this.slaData?this.slaData['plantId']:'')
      },
      (error) => {
      }
    )
  }
  getCategory() {

    const apiUrls = this.apiurl + '/Category'
    const requestBody = {

    }
    this.http.get(apiUrls, requestBody).subscribe(
      (response: any) => {
        this.categorydata = response
        this.slaForm.controls['category'].setValue(this.slaData?this.slaData['categoryId']:'')
        if(this.slaData){
          this.getcategorytype()
        }
      },
      (error) => {
        throw error
      }
    )
  }
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
        this.categorytype = response.filter((item: any) => item.categoryId == this.slaForm.controls['category'].value);
        console.log(this.categorytype)
        this.slaForm.controls['categoryType'].setValue(this.slaData?this.slaData['categoryTypId']:'')
      }
    )}
    submitForm(){
      this.supportteammemid = this.routeservice.supporterID;
      let param = {
        "flag": "I",
        "itslaid": Number(this.SlaId ?? 0),
        "categoryID": parseInt(this.slaForm.controls['category'].value),
        "classificationID": parseInt(this.slaForm.controls['Classification'].value),
        "categoryTypID": parseInt(this.slaForm.controls['categoryType'].value),
        "supportID":  this.supportid,
        "waitTime": parseInt(this.slaForm.controls['WaitTime'].value),
        "waitTimeUnit": this.slaForm.controls['WaitTimeUnit'].value,
        "assignedTo": parseInt(this.slaForm.controls['AssignedTo'].value),
        // "plantID": parseInt(this.slaForm.controls['PlantId'].value),
        "plantID" : 2,
        "escalation1": parseInt(this.slaForm.controls['Escalation1'].value),
        "waitTimeEscal1": parseInt(this.slaForm.controls['WaitTimeEscal1'].value),
        "waitTimeUnitEscal1": this.slaForm.controls['WaitTimeUnitEscal1'].value,
        "escalation2": parseInt(this.slaForm.controls['Escalation2'].value),
        "waitTimeEscal2": parseInt(this.slaForm.controls['WaitTimeEscal2'].value),
        "waitTimeUnitEscal2": this.slaForm.controls['WaitTimeUnitEscal2'].value,
        "createdBy": parseInt(this.user?.supportTeamData?.empId)
      }
      const apiUrls = this.apiurl + '/SlaMaster/PostSlamaster'
      this.http.post(apiUrls, param).subscribe(
        (response: any) => {
    this.router.navigate(['/slamaster']);
        },
        (error) => {
        }
      )
    }

    async getsupportTeamList(){
      await this.getSupportList.suppTeamList();
      this.supportList = this.getSupportList.SupportTeamList
      // let empId = this.routeservice.getEmployeeId()
      // this.supportTeamId = this.supportList.filter((m:any)=>m.empId.toString() == empId)[0].supportTeamId
      
    }
}
