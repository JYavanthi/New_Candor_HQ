import { Component, numberAttribute } from '@angular/core';
import { IDropdownSettings, } from 'ng-multiselect-dropdown';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Console } from 'console';
import { response } from 'express';
import { PasscrdataService } from '../../change-request/passcrdata.service';import { environment } from '@environments/environment';
interface DropdownDepartmentItem {
  itemdepartment_id: number;
  itemdepartment_text: string;
}

interface DropdownCatItem {
  itemcat_id: number;
  itemcat_text: string;
}
interface DropdownCattypeItem {
  itemcat_id: number;
  itemcat_text: string;
  catId : number
}

@Component({
  selector: 'app-support-team',
  templateUrl: './support-team.component.html',
  styleUrl: './support-team.component.css'
})
export class SupportTeamComponent {
  showMiniForm: boolean = false;
  formFields: any[] = [];

  dropdownListDepartment: DropdownDepartmentItem[] = [];
  dropdownDepartmentSettings = {
    idField: 'itemdepartment_id',
    textField: 'itemdepartment_text',
  };

  dropdownListCat: DropdownCatItem[] = [];
  dropdownCatSettings = {
    idField: 'itemcat_id',
    textField: 'itemcat_text',
  };
  dropdownListCattype: DropdownCattypeItem[] = [];
  dropdownCattypeSettings = {
    idField: 'itemcat_id',
    textField: 'itemcat_text',
  };

  supportteammemid: any;
  totalSubCat: any;
  constructor(private http: HttpClient, private route: Router, private routeservice:PasscrdataService) {
    this.addFormField();
    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);

    this.routeservice.getsupportteam();
    this.supportteammemid = this.routeservice.supporterID;
  }

  fetchDropdownDepartment(): void {
    const apiUrl = this.apiurl + '/Plantid'; // Replace with your API endpoint
    this.http.get<any[]>(apiUrl).subscribe(
      (data) => {
        this.dropdownListDepartment = data.map(item => ({
          itemdepartment_id: item.id,
          itemdepartment_text: item.code // Assuming your API response has 'id' and 'name' fields
        }));
      },
      (error) => {
        console.error('Error fetching dropdown data:', error);
      }
    );
  }

  impactedPlant: any = '';
  selecteddepartmentNames: DropdownDepartmentItem[] = [];

  onSelecteddepartmentItemsChange(): void {
    this.impactedPlant = this.selecteddepartmentNames.map((item: any) => item.itemdepartment_id);
  }

  fetchDropdownCat(): void {
    const apiUrl = this.apiurl + '/Category';
    this.http.get<any[]>(apiUrl).subscribe(
      (data) => {
        this.dropdownListCat = data.map(item => ({
          itemcat_id: item.itcategoryId,
          itemcat_text: item.categoryName
        }));
      },
      (error) => {
        console.error('Error fetching dropdown data:', error);
      }
    );
  }

  fetchDropdownCattype(): void {
    const apiUrl = this.apiurl + '/CategoryTyp';
    this.http.get<any[]>(apiUrl).subscribe(
      (data) => {
        this.dropdownListCattype = data.map(item => ({
          itemcat_id: item.categoryTypeId,
          itemcat_text: item.categoryType,
          catId: item.categoryId
        }));

        this.totalSubCat = this.dropdownListCattype
        this.dropdownListCattype = []
      },
      (error) => {
      }
    );
  }

  multiplecat: any = '';
  selectedmultiplecat: DropdownDepartmentItem[] = [];

  onSelectedcatItemsChange(): void {
    this.multiplecat = this.selectedmultiplecat.map((item: any) => item.itemcat_id);
    this.dropdownListCattype = this.totalSubCat.filter((m:any)=>{
      return this.multiplecat.indexOf(m.catId)!=-1
    })
    
  }
  multiplecattype: any = '';
  selectedmultiplecattype: DropdownDepartmentItem[] = [];

  onSelectedcattypeItemsChange(): void {
    this.multiplecattype = this.selectedmultiplecattype.map((item: any) => item.itemcat_id);
  
  }

  /* form*/

  toggleMiniForm() {
    this.showMiniForm = !this.showMiniForm;
    this.rolechange()
  }

  addFormField() {
    this.formFields.push({});
  }

  removeFormField() {
    this.formFields.pop();
  }

  /*multiselect*/

  ngOnInit() {
    this.fetchDropdownDepartment();
    this.fetchDropdownCat();
    this.fetchDropdownCattype();
    this.getcategorytype();
    this.categoryfunctions();
    this.getcategorytype();
    this.getsystemlandscape();
    this.getclassification();
    this.getsystemlandscape();
    this.getcategory();
    this.getplant();
    this.fetchAllItems();
    this.filterItems();
    this.getitsupport();
    this.getsupportteams();
  }

  Helpdeskbutton: boolean = false;
  ApproverButton: boolean = true;
  value: any[] = [];
  onselect() {
    this.value = this.itsupportid.filter(item => item.supportId == this.supportId)
    if (this.value[0].supportName == "Helpdesk" || this.value[0].supportName == "Issue") {
      this.Helpdeskbutton = true;
      this.ApproverButton = false;
    }
    else {
      this.Helpdeskbutton = false;
      this.ApproverButton = true;
    }

  }

  rolechange() {

    if (this.IsApprove == true) {
      this.role = "Approver"
    }
    if (this.IsAnalyst == true) {
      this.role = "Change Analyst"
    }
    if (this.IsEngineer == true) {
      this.role = "Executive"
    }
    if (this.IsAdmin == true) {
      this.role = "Admin"
    }
    if (this.IsApprove == true && this.IsAnalyst == true) {
      this.role = "Change Analyst,Approver"
    }
    if (this.IsApprove == true && this.IsEngineer == true) {
      this.role = "Approver,Executive"
    }
    if (this.IsAnalyst == true && this.IsEngineer == true) {
      this.role = "Change Analyst,Executive"
    }
    if (this.IsAnalyst == true && this.IsEngineer == true && this.IsApprove == true) {
      this.role = "Change Analyst,Approver,Executive"
    }
    if (this.IsAnalyst == true && this.IsAdmin == true) {
      this.role = "Change Analyst,Admin"
    }
    if (this.IsApprove == true && this.IsAdmin == true) {
      this.role = "Approver,Admin"
    }
    if (this.IsEngineer == true && this.IsAdmin == true) {
      this.role = "Executive,Admin"
    }
    if (this.IsAnalyst == true && this.IsApprove == true && this.IsAdmin == true) {
      this.role = "Change Analyst,Approver,Admin"
    }
    if (this.IsAnalyst == true && this.IsEngineer == true && this.IsAdmin == true) {
      this.role = "Change Analyst,Executive,Admin"
    }
    if (this.IsApprove == true && this.IsEngineer == true && this.IsAdmin == true) {
      this.role = "Approver,Executive,Admin"
    }
    if (this.IsAnalyst == true && this.IsEngineer == true && this.IsApprove == true && this.IsAdmin == true) {
      this.role = "Admin"
    }
  }

  selectedCategory: any = '';
  categoryTypeId: any = '';
  supportId: any = '';
  classificationId: any = '';
  today: any = '';
  firstname: any = '';
  middlename: any = '';
  lastname: any = '';
  imageurls: any = '';
  Email: any = '';
  designation: any = '';
  role: any = '';
  empid: any = '';
  dob: any = '';
  dol: any = '';
  category: any = '';
  classfication: any = '';
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
  categorynameid: string = '';
  private apiurl = environment.apiurls;

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

    this.impactedPlant.forEach((plantId: any) => {
      this.multiplecat.forEach((categoryId: any) => {
        if (this.multiplecattype) {
          this.multiplecattype.forEach((categorytypeId: any) => {
            this.executefunc(plantId, categoryId, categorytypeId);
          });
        }
        else {
          const categorytypeId = 0
          this.executefunc(plantId, categoryId, categorytypeId);
        }
      });
    });
  }

  executefunc(plantId: any, categoryId: any, categorytypeId: any) {
    const apiUrl = this.apiurl + '/SupportTeam/PostSupportTeam';
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    const requestBody = {
      "flag": "I",
      "supportTeamId": 0,
      "email": this.Email ? this.Email : "",
      "firstName": this.firstname ? this.firstname : "",
      "middleName": this.middlename ? this.middlename : "",
      "lastName": this.lastname ? this.lastname : "",
      "imgUrl": this.imageurls ? this.imageurls : "",
      "designation": this.designation ? this.designation : "",
      "role": this.role,
      "empId": Number(this.empid),
      "isActive": this.isActive,
      "dol": this.dol ? this.dol : null,
      "dob": this.dob ? this.dob :null,
      "isAdmin": this.IsAdmin,
      "isSuperAdmin": this.IsSuperAdmin,
      "isApprover": this.IsApprove,
      "isChangeAnalyst": this.IsAnalyst,
      "isSupportEngineer": this.IsEngineer,
      "plantId": plantId,
      "supportId": Number(this.supportId),
      "categoryId": categoryId,
      "CategoryTypID": categorytypeId,
      "classificationId": Number(this.classificationId),
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
      "createdBy": Number(this.supportteammemid),
      "createdDate": this.today,
      "supportIds":[]
    };
    setTimeout(() => {
      this.http.post(apiUrl, requestBody, httpOptions).subscribe(
        (response: any) => {
          this.messagesuccess = true;
          const categoryname = this.categorydata.filter((item: any) => item.itcategoryId == categoryId && item.supportId == 1)
          this.categorynameid = categoryname[0].categoryName
          alert("Inserted value for Plant Category:" + ' ' + this.categorynameid);
        },
        (error: any) => {
          this.messageerror = true;
          this.errormessage = error;
        }
      );
    }, 1000);
  }

  navigatesuccess() {
    this.route.navigate(['/support_view']);
  }

  closeNotification() {
    this.messageerror = false;
  }



  classifications: any[] = [];
  plantcode: any[] = [];

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
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }
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
        this.classifications = response;
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  getsystemlandscape() {
    const apiUrl = this.apiurl + '/SystemLandscape/Getsystems';
    const requestBody = {
      "categroyId": this.selectedCategory,
      "supportId": 1,
      "classificationId": this.classificationId
    };
    this.http.post(apiUrl, requestBody).subscribe(
      (response: any) => {
        this.systemlandscape = response;
      },
      (error: any) => {
        console.error('POST request failed', error);
      }
    );
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
        const checkcatid = this.selectedCategory
        this.catidfilter = checkcatid
        this.categorytype = response.filter((item: any) => item.categoryId.toString() === this.catidfilter);
      },
      (error) => {
        console.error("Post failed", error)
      }
    )

  }
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
        this.categorydata = response.filter((item: any) => item.supportId === 1);
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  itsupportid: any[] = [];
  getitsupport() {

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
        this.itsupportid = response;
        console.log("this.itsupportid",this.itsupportid)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  categoryfunctions() {
    this.getsystemlandscape();
    this.getcategorytype();
  }
  item: any = '';
  onItemSelect(item: any) {

    this.updateApproverStage();
  }


  onItemDeSelect(item: any) {
    this.updateApproverStage();
  }


  onSelectAll(items: any) {

    this.updateApproverStage();
  }


  onUnSelectAll() {

    this.updateApproverStage();
  }

    private updateApproverStage() {



  }
  isApprover: boolean = false;
  isChangeAnalyst: boolean = false;
  isSupportEngineer: boolean = false;
  getsupport() {

    if (this.item.item_text == "Change Request") {
      this.isApprover = true;
    }
    else if (this.item.item_text == "Closure") {
      this.isChangeAnalyst = true;
    }
    else if (this.item.item_text == "Release")  {
      this.isSupportEngineer = true;
    }
    else if (this.item.length == 2) {
      this.item = true;
    }
    else {
      this.isApprover = true;
      this.isChangeAnalyst = true;
      this.isSupportEngineer = true;
    }
  }


  dropdownItems: any[] = [];
  dropdownItemscr: any[] = [];
  selectedValue: any = '';
  selectedValuecr: any = '';
  supportteamname: any[] = [];
  supportnames: any[] = [];

  filterItems() {
    const filter = this.empid;
    this.dropdownItems = this.supportnames.filter(item =>
      item.employeeId.toString().includes(filter)
    );
    if (this.dropdownItems.length === 0 && filter === '') {
      this.dropdownItems.push('');
    } else if (filter === '') {
      this.dropdownItems.length = 0;
    }
  }

  fetchAllItems() {
    const apiUrl = this.apiurl + '/HREmployee';
    this.http.get(apiUrl).subscribe(
      (response:any) => {
        this.supportnames = response;
      },
      (error: any) => {
        console.error('GET request failed', error);
      }
    );
  }

  selectItem(item:any) {
    this.empid = item.employeeId;
    this.firstname = item.firstName;
    this.middlename = item.middleName;
    this.lastname = item.lastName;
    this.Email = item.officialEmailId;
    this.imageurls = item.imgUrl || '';
    this.designation = item.role;
    this.dol = item.dateOfLeaving;
    this.dob = item.dateOfBirth;
    this.dropdownItems = [];
  }

  supportteams: any[] = [];
  getsupportid: any;
  supportpersonname = '';
  getsupportteams() {
    const apiUrls = this.apiurl + '/SupportTeam'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.supportteams = response.filter((row: any) => row.empId === parseInt(this.supportteammemid.trim()));
        this.getsupportid = this.supportteams[0].supportTeamId;
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
    this.getsupportteamassign();
  }

  supportteamassign: any[] = [];
  ischangeanalyst: any;
  isapprover: any;
  issupportegineer: any;
  superadminaccess: any;


  getsupportteamassign() {
    const apiUrls = this.apiurl + '/SupportteamAssigned'

    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.supportteamassign = response.filter((row: any) => row.supportTeamId === this.getsupportid);
        this.isapprover = this.supportteamassign[0].isApprover
        this.issupportegineer = this.supportteamassign[0].isSupportEngineer
        this.ischangeanalyst = this.supportteamassign[0].isChangeAnalyst
        this.superadminaccess = this.supportteamassign[0].isSuperAdmin
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }
}
