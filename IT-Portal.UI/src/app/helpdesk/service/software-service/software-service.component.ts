import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';import { environment } from '@environments/environment';
import { PasscrdataService } from 'app/change-request/passcrdata.service';
import { Router } from '@angular/router';

interface DropdownDepartmentItem {
  itemdepartment_id: number;
  itemdepartment_text: string;
}

interface DropdownCatItem {
  itemcat_id: number;
  itemcat_text: string;
}

@Component({
  selector: 'app-software-service',
  templateUrl: './software-service.component.html',
  styleUrl: './software-service.component.css'
})
export class SoftwareServiceComponent {
  ShowSelf=false;
  ShowOthers = false;
  ShowGuest = false;
  EnterIssueID: any;
  supportid: any;
  supportnames: any;
  supportteamsforOthers: any;
  supportteamsforGuest: any;
  supportteams: any;
  EmployeeID: any;
  Name: any;
  Email: any;
  GxpApp=false;
  ContactNo: any;
  ReportingManager: any;
  StaffCategory: any;
  Plant: any;
  Paygroup: any;
  Department: any;
  Designation: any;
  Role: any;
  ReportingManagerEmpID: any;
  dropdownItems2:any=[];
  ReportingManagerinML: any;
  StaffCategoryofML: any;
  GuestPlant: any;
  PaygroupML: any;
  DepartmentML: any;
  DesignationofMLManager: any;
  RoleofMLManager: any;
  EmployeeIDOthers: string='';
  OthersName: string = '';
  EmailOthers: string = '';
  ContactNoOthers: string = '';
  ReportingManagerOthers: string = '';
  StaffCategoryOthers: string = '';
  PlantOthers: string = '';
  PaygroupOthers: string = '';
  DepartmentOthers: string = '';
  DesignationOthers: string = '';
  RoleOthers: string = '';
  issueRaiseFor: any;
  GuestEmployeeID: string = '';
  GuestContactNo: string = '';
  Guestemail: string = '';
  GuestName: string = '';
  plantId: string = '';
  categoryId: string = '';
  Type: string = '';
  priority: string = '';
  source: string = '';
  assetId: string = '';
  assignedTo: string = '';
  Subject: string = '';
  issueDesc: string = '';
  attachment: string = '';
  plantcode: any;
  prioritytype: any;
  categorydata: any;
  showChatPanel = false;
  resolCom: any;
  showPanel: boolean=false;

  constructor(private http: HttpClient,private route: Router, private routeservice: PasscrdataService) {
    
    this.supportid = this.routeservice.supporterID;
    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);
    this.fetchDropdownDepartment();
    this.selectedOption = "self";
    this.OnLabelChange();
  }


  showProcureBuy: boolean = false;
  showDevelopmentApplicationmobileapp: boolean = false;
  showWebsiteDevelopment: boolean = false;
  Installationtype: string = '';
  RequestFor: string = '';
  today='';
  selectAMC: string = '';
  showAMC: boolean = false; 
  showImplementationRequired: boolean = false;
  selectImplementationRequired: string = '';
  selectInterface: string = '';
  selectdevelopmentInterface: string = '';
  showInterfaceRequirements: boolean = false;
  showInstallSoftware: boolean = false;
  showupgradeSoftware: boolean = false;
  showUnInstallSoftware: boolean = false;
  SelectPlant: string = '';
  dropdownListDepartment: DropdownDepartmentItem[] = [];
  impactedPlant: any = '';
  private apiurl = environment.apiurls;
  selectedOption=''
  dropdownItems:any=[]
  DisableissueRaiseFor:boolean=false

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

  ngOnInit(): void {
    this.fetchAllItems();
    this.getplant();
    this.getcategory();
    this.priorityapi();
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
        console.log(response);
        this.categorydata = response.filter((item: any) => item.supportId === 1);
        console.log(this.categorydata)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  priorityapi() {
    const apiUrls = this.apiurl + '/Priority'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.prioritytype = response;
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  toggleResoPanel(){
    this.resolCom = !this.resolCom
  }
  getplant() {
    const apiUrls = this.apiurl + '/Plantid'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.plantcode = response;
      },
      (error) => {
        throw error
      }
    )
  }
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

  togglePanelHis() {
    this.showPanel = !this.showPanel;
  }

  toggleChatPanel(){
    this.showChatPanel = !this.showChatPanel;
  }
  RequestForFunc() {
    if (this.RequestFor === "Procure/Buy") {
      this.showProcureBuy = true;
      this.showDevelopmentApplicationmobileapp = false;
      this.showWebsiteDevelopment = false;
      this.showInstallSoftware = false;
      this.showupgradeSoftware = false;
      this.showUnInstallSoftware = false;
    }
    else if (this.RequestFor === "Development-Application,mobile app") {
      this.showDevelopmentApplicationmobileapp = true;
      this.showProcureBuy = false;
      this.showWebsiteDevelopment = false;
      this.showInstallSoftware = false;
      this.showupgradeSoftware = false;
      this.showUnInstallSoftware = false;
    }
    else if (this.RequestFor === "Website Development") {
      this.showWebsiteDevelopment = true;
      this.showProcureBuy = false;
      this.showDevelopmentApplicationmobileapp = false;
      this.showInstallSoftware = false;
      this.showupgradeSoftware = false;
      this.showUnInstallSoftware = false;
    }
    else if (this.RequestFor === "Install Software") {
      this.showInstallSoftware = true;
      this.showWebsiteDevelopment = false;
      this.showProcureBuy = false;
      this.showDevelopmentApplicationmobileapp = false;
      this.showupgradeSoftware = false;
      this.showUnInstallSoftware = false;
    }
    else if (this.RequestFor === "Upgrade Software") {
      this.showProcureBuy = false;
      this.showDevelopmentApplicationmobileapp = false;
      this.showWebsiteDevelopment = false;
      this.showInstallSoftware = false;
      this.showUnInstallSoftware = false;
      this.showupgradeSoftware = true;

    }
    else if (this.RequestFor === "Uninstall Software") {
      this.showUnInstallSoftware = true;
      this.showProcureBuy = false;
      this.showDevelopmentApplicationmobileapp = false;
      this.showWebsiteDevelopment = false;
      this.showInstallSoftware = false;
      this.showupgradeSoftware = false;
    }


  }

  amcOption() {
    if (this.selectAMC === "Yes") {
      this.showAMC = true;
    } else {
      this.showAMC = false;
    }
  }

  ImplementationRequiredOption() {
    if (this.selectImplementationRequired === "Yes") {
      this.showImplementationRequired = true;
    } else {
      this.showImplementationRequired = false;
    }
  }

  interfaceOption() {
    if (this.selectInterface) {
      this.showInterfaceRequirements = true;
    } else {
      this.showInterfaceRequirements = false;
    }
  }

  ClearGuestInputs() {
    this.GuestEmployeeID = '';
    this.GuestName = '';
    this.Guestemail = '';
    this.GuestContactNo = '';
    this.ReportingManagerEmpID = '';
    this.ReportingManagerinML = '';
    this.StaffCategoryofML = '';
    this.GuestPlant = '';
    this.PaygroupML = '';
    this.DepartmentML = '';
    this.DesignationofMLManager = '';
    this.RoleofMLManager = '';
  }
  
  async OnLabelChange() {
    if (this.selectedOption) {
      this.ClearSelfInputs();
      this.ClearOtherInputs();
      this.ClearGuestInputs();
      this.ClearIssueDetailsInputs();
      this.supportteams = [];
      this.supportteamsforOthers = [];
      this.supportteamsforGuest = [];
      this.issueRaiseFor = '';
      this.dropdownItems = [];
      this.dropdownItems2 = [];

      if (this.selectedOption === "self") {
        this.DisableissueRaiseFor = true;
        this.ShowSelf = true;
        this.ShowOthers = false;
        this.ShowGuest = false;
      }
      else if (this.selectedOption === "others") {
        setTimeout(() => {
          this.EnterIssueID.nativeElement.focus();
        }, 0);
        this.DisableissueRaiseFor = false;
        this.ShowSelf = false;
        this.ShowOthers = true;
        this.ShowGuest = false;
      }
      else if (this.selectedOption === "guest") {
        this.DisableissueRaiseFor = true;
        this.ShowSelf = false;
        this.ShowOthers = false;
        this.ShowGuest = true;
      }

      this.supportid = this.routeservice.supporterID;
      try {
        await this.fetchAllItems();
        this.getInputDatas();
      } catch (error) {
        console.error('Error fetching items:', error);
      }

    }
  }

  
  ClearIssueDetailsInputs() {
    this.plantId = '';
    this.categoryId = '';
    this.categoryId = '';
    this.priority = '';
    this.Type = '';
    this.source = '';
    this.assetId = '';
    this.assignedTo = '';
    this.Subject = '';
    this.issueDesc = '';
    this.attachment = '';
  }
  fetchAllItems(): Promise<any> {
    const apiUrl = this.apiurl + '/EmployeeMasters';
    return this.http.get(apiUrl).toPromise()
      .then((response: any) => {
        this.supportnames = response;
        this.supportteams = response.filter((row: any) => row.employeeId == parseInt(this.supportid.trim()));
        if (this.selectedOption == "others") {
          this.supportteamsforOthers = response.filter((row: any) => row.employeeId == parseInt(this.issueRaiseFor.trim()));
        }
        if (this.selectedOption == "guest") {
          this.supportteamsforGuest = response.filter((row: any) => row.employeeId == parseInt(this.ReportingManagerEmpID.trim()));
        }
      })
      .catch((error: any) => {
        throw error;
      });
  }

  ClearSelfInputs() {
    this.EmployeeID = '';
    this.Name = '  ';
    this.Email = '';
    this.ContactNo = '';
    this.ReportingManager = '';
    this.StaffCategory = '';
    this.Plant = '';
    this.Paygroup = '';
    this.Department = '';
    this.Designation = '';
    this.Role = '';
  }

  getInputDatas() {
    this.EmployeeID = this.supportteams[0].employeeId;
    this.Name = this.supportteams[0].employeeName;
    this.Email = this.supportteams[0].email;
    this.ContactNo = this.supportteams[0].phoneNumber;
    this.ReportingManager = this.supportteams[0].reportManagerName;
    this.StaffCategory = this.supportteams[0].staffCategory;
    this.Plant = this.supportteams[0].plantcode;
    this.Paygroup = this.supportteams[0].payGroup;
    this.Department = this.supportteams[0].department;
    this.Designation = this.supportteams[0].designation;
    this.Role = this.supportteams[0].role;
  }

  async selectItem(item: any) {
    if (this.selectedOption == "others") {
      this.issueRaiseFor = item.employeeId;
      this.dropdownItems = [];
      try {
        await this.fetchAllItems();
        this.getOtherInputDatas();
      } catch (error) {
        console.error('Error fetching items:', error);
      }
    }

    if (this.selectedOption == "guest") {
      this.ReportingManagerEmpID = item.employeeId;
      this.dropdownItems2 = [];
      try {
        await this.fetchAllItems();
        this.getGuestInputDatas();
      } catch (error) {
        console.error('Error fetching items:', error);
      }
    }
  }
  
  getOtherInputDatas() {
    this.EmployeeIDOthers = this.supportteamsforOthers[0].employeeId;
    this.OthersName = this.supportteamsforOthers[0].employeeName;
    this.EmailOthers = this.supportteamsforOthers[0].email;
    this.ContactNoOthers = this.supportteamsforOthers[0].phoneNumber;
    this.ReportingManagerOthers = this.supportteamsforOthers[0].reportManagerName;
    this.StaffCategoryOthers = this.supportteamsforOthers[0].staffCategory;
    this.PlantOthers = this.supportteamsforOthers[0].plantcode;
    this.PaygroupOthers = this.supportteamsforOthers[0].payGroup;
    this.DepartmentOthers = this.supportteamsforOthers[0].department;
    this.DesignationOthers = this.supportteamsforOthers[0].designation;
    this.RoleOthers = this.supportteamsforOthers[0].role;
  }
  
  ClearOtherInputs() {
    this.EmployeeIDOthers = '';
    this.OthersName = '';
    this.EmailOthers = '';
    this.ContactNoOthers = '';
    this.ReportingManagerOthers = '';
    this.StaffCategoryOthers = '';
    this.PlantOthers = '';
    this.PaygroupOthers = '';
    this.DepartmentOthers = '';
    this.DesignationOthers = '';
    this.RoleOthers = '';
  }

  ClearGuestOtherInputs() {
    this.ReportingManagerinML = '';
    this.StaffCategoryofML = '';
    this.GuestPlant = '';
    this.PaygroupML = '';
    this.DepartmentML = '';
    this.DesignationofMLManager = '';
    this.RoleofMLManager = '';
  }
  
  getGuestInputDatas() {
    this.ReportingManagerinML = this.supportteamsforGuest[0].reportManagerName;
    this.StaffCategoryofML = this.supportteamsforGuest[0].staffCategory;
    this.GuestPlant = this.supportteamsforGuest[0].plantcode;
    this.PaygroupML = this.supportteamsforGuest[0].payGroup;
    this.DepartmentML = this.supportteamsforGuest[0].department;
    this.DesignationofMLManager = this.supportteamsforGuest[0].designation;
    this.RoleofMLManager = this.supportteamsforGuest[0].role;
  }
  filterItemsforGuest() {
    const filter = this.ReportingManagerEmpID;
    this.dropdownItems2 = this.supportnames.filter((item:any) =>
      item.employeeId.toString().includes(filter)
    );
    if (this.dropdownItems2.length === 0 && filter === '') {
      this.dropdownItems2.push('');
    } else if (filter === '') {
      this.dropdownItems2.length = 0;
    }
  }

  filterItems() {
    const filter = this.issueRaiseFor;
    this.dropdownItems = this.supportnames.filter((item:any) =>
      item.employeeId.toString().includes(filter)
    );
    if (this.dropdownItems.length === 0 && filter === '') {
      this.dropdownItems.push('');
    } else if (filter === '') {
      this.dropdownItems.length = 0;
    }
  }

  // DevinterfaceOption(){
  //   if (this.selectdevelopmentInterface === "Yes") {
  //     this.showInterfaceRequirements = true;
  //   } else {
  //     this.showInterfaceRequirements = false;
  //   }
  // }
}
