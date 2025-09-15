import { Component, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { FormValidationService } from 'app/services/form-validation.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UserConfigTreeviewComponent } from '../user-config-treeview/user-config-treeview.component';
import { Location } from '@angular/common';

interface PlantDropdown {
  itemPlant_id: number;
  itemPlant_text: string;
}

interface CategoryDropdown {
  itemCategory_id: number;
  itemCategory_text: string;
}

interface CategoryTypeDropdown {
  itemCategoryType_id: number;
  itemCategoryType_text: string;
}

interface ClassificationDropdown {
  itemClassification_id: number;
  itemClassification_text: string;
}

@Component({
  selector: 'app-user-configuration',
  templateUrl: './user-configuration.component.html',
  styleUrls: ['./user-configuration.component.css', '../../service-module/servicemodule.css'],
  animations: [
    trigger('expandCollapse', [
      state('void', style({ height: '0', opacity: 0 })),
      state('*', style({ height: '*', opacity: 1 })),
      transition('void <=> *', [
        animate('300ms ease-in-out')
      ])
    ])
  ]
})

export class UserConfigurationComponent {
  @ViewChild(UserConfigTreeviewComponent) treeViewComponent!: UserConfigTreeviewComponent;

  plantDropdownSettings = {
    idField: 'itemPlant_id',
    textField: 'itemPlant_text',
  };
  plantList: PlantDropdown[] = [];

  categoryDropdownSettings = {
    idField: 'itemCategory_id',
    textField: 'itemCategory_text',
  };
  categoryList: CategoryDropdown[] = [];

  categoryTypeDropdownSettings = {
    idField: 'itemCategoryType_id',
    textField: 'itemCategoryType_text',
  };
  categoryTypeList: CategoryTypeDropdown[] = [];

  classificationDropdownSettings = {
    idField: 'itemClassification_id',
    textField: 'itemClassification_text',
  };
  classificationList: ClassificationDropdown[] = [];

  supportTeamAssignList: any
  supportTeamData: any
  isModuleVisible = true;
  userForm!: FormGroup;
  allEmpList: any[] = [];
  allSupportIDs: any[] = [];
  parentModuleList: any[] = [];
  assetSpareList: any[] = [];
  supportTeamList: any[] = [];
  user: any;
  suportTeamAssignList: any
  parentSupportID!: number;
  showSRTree: boolean = false;
  showCRList: boolean = false;
  showAssetList: boolean = false;
  showApproverLevels: boolean = false;
  showApproverLevel1: boolean = false;
  showApproverLevel2: boolean = false;
  showApproverLevel3: boolean = false;
  EmployeeID!: string;
  Name!: string;
  Email!: string;
  ContactNo!: string;
  ReportingManager!: string;
  StaffCategory!: string;
  Plant!: string;
  Paygroup!: string;
  Department!: string;
  Designation!: string;
  Role!: string;
  parentModuleChilds: { [key: number]: any[] } = {};
  employeeDropdownList: any[] = [];
  showAdminSuperAdmin: boolean = true;
  supportDropdownList: any[] = [];
  copiedEmployeeID!: null | number;
  empID!: number | null;
  checkedItemList: any[] = [];
  supportTeamID: any;

  constructor(private fb: FormBuilder,
    private employeeInfo: GetEmployeeInfoService,
    private httpSer: HttpServiceService,
    public formValidSer: FormValidationService,
    private userInfo: UserInfoSerService,
    private router: Router,
    private location: Location,
    private activeRoute: ActivatedRoute
  ) {
    this.user = this.userInfo.getUser();
    this.employeeInfo.empList().then(() => {
      this.allEmpList = this.employeeInfo.EmpList;
    });
    this.getSupportTeam();

    this.activeRoute.queryParamMap.subscribe(param => {
      if (param.get('suppID')) {
        this.supportTeamID = param.get('suppID');
        if (this.supportTeamID) {
          this.getValue()
          this.getSuppportTeamAssigned()
        }
      }
    })
  }

  apiUrl = {
    getParentValue: '/SupportMaster/GetParentValue',
    getSupportById: '/SupportMaster/GetSupportById'
  }

  ngOnInit() {
    this.formInit();
    this.getParents(0);
    this.getPlant();
    this.getCategoryList();
    this.getClassificationList();
    this.getSupportByID(4);
    this.getSupportTeamAssign()
  }

  formInit() {
    this.userForm = this.fb.group({
      employeeID: [''],
      Admin: [true],
      superAdmin: [false],
      copiedEmpID: [''],
      CRApprover: [false],
      CRAnalyst: [false],
      CREngineer: [false],
      issueEngineer: [false],
      userConfigPlant: [''],
      userConfigCategory: [''],
      userConfigCategoryType: [''],
      userConfigClassification: [''],
      isApprove: [false],
      isAnalyst: [false],
      isExecutive: [false],
      approverLevel1: [false],
      approverLevel2: [false],
      approverLevel3: [false],
      CRApproverLevel1: [false],
      releaseApproverLevel1: [false],
      closureApproverLevel1: [false],
      CRApproverLevel2: [false],
      releaseApproverLevel2: [false],
      closureApproverLevel2: [false],
      CRApproverLevel3: [false],
      releaseApproverLevel3: [false],
      closureApproverLevel3: [false]
    });
  }

  patchFormValues(data: any) {
    this.userForm.patchValue({
      employeeType: data?.empType ? data?.empType : ''
    })
  }

  resetCRList() {
    this.userForm.patchValue({
      isApprove: false,
      isAnalyst: false,
      isExecutive: false
    })
    this.onApproveChange();
  }

  onParentCheckBoxChange(supportId: number, event: Event) {
    const isChecked = (event.target as HTMLInputElement).checked;
    // this.parentModuleList.forEach((m,i)=>{
    //   if(m.supportId==supportId){
    //     this.parentModuleList[i]['isChecked']=isChecked
    //   }
    // })
    if (supportId == 1) {
      this.resetCRList();
      if (isChecked) {
        this.showCRList = true;
        this.allSupportIDs.push(supportId);
      }
      else {
        this.showCRList = false;
        this.allSupportIDs = this.allSupportIDs.filter(id => id !== supportId);
      }
    }
    else {
      if (isChecked) {
        this.getParentModuleChilds(supportId);
        if (!this.allSupportIDs.includes(supportId)) {
          this.allSupportIDs.push(supportId);
        }
      }
      else {
        if (this.parentModuleChilds[supportId]) {
          this.parentModuleChilds[supportId].forEach(child => {
            this.userForm.removeControl(child.supportName);
            this.allSupportIDs = this.allSupportIDs.filter(id => id !== child.supportId);
          });
          const childMatchingParent = this.parentModuleChilds[supportId].some(child => child.supportId === this.parentSupportID);
          if (childMatchingParent) {
            this.showSRTree = false;
            this.checkedItemList = [];
            this.allSupportIDs = this.getCheckedModuleSupportIds();
          }
          delete this.parentModuleChilds[supportId];
        }
        this.allSupportIDs = this.allSupportIDs.filter(id => id !== supportId);
      }
    }
  }

  getParentModuleChilds(supportId: number) {
    this.httpSer.httpGet(this.apiUrl.getParentValue, { ParentId: supportId }).subscribe((res: any) => {
      this.parentModuleChilds[supportId] = res;
      this.parentModuleChilds[supportId].forEach(child => {
        this.userForm.addControl(child.supportName, this.fb.control(false));
      });
    });
  }

  getValue() {
    this.httpSer.httpGet('/SupportTeam/getSupportTeamById', { supportTeamId: this.supportTeamID }).subscribe(
      (response: any) => {
        this.supportTeamData = response.data[0]
        this.supportTeamAssignList = response.data.filter((m: any, i: any) => response.data.map((a: any) => a.supportId).indexOf(m.supportId) == i)
        this.userValueBind()

      }
    );
  }

  getSuppportTeamAssigned() {
    this.httpSer.httpGet('/SupportteamAssigned').subscribe(
      (response: any) => {
        this.supportTeamList = response.filter((m: any) => m.supportTeamId == this.supportTeamID)

        this.parentModuleList.forEach(m => {
          this.userForm.controls[m]?.setValue(true)
        })

      }
    );
  }
  async userValueBind() {
    this.userForm.patchValue({ employeeID: this.supportTeamData?.empId?.toString() + ' ' + '-' + ' ' + this.supportTeamData.firstName?.trim() })
    this.empID = this.supportTeamData?.empId;
    this.employeeDropdownList = [];
    // this.parentModuleList.forEach(m=>{
    //   if(this.supportTeamAssignList.map((a:any)=>a.supportId).includes(m.supportId)){
    //     this.userForm.controls[m.supportName].setValue(true)
    //   }
    // })
    try {
      await this.fetchAllItems(this.supportTeamData?.empId);
      this.assignEmployeesDetails();
    } catch (error) {
      console.error('Error fetching items:', error);
    }
  }

  clickParentModule() {

  }
  // onChildModuleChange(childName: string, supportID: number) {
  //   const isChecked = this.userForm.get(childName)?.value;
  //   if (supportID == 5) {
  //     if (isChecked) {
  //       console.log('allSupportIDs',this.allSupportIDs)
  //       this.showAssetList = true;
  //       this.allSupportIDs.push(supportID);

  //       this.httpSer.httpGet('/SupportMaster/GetParentValue', { ParentId: supportID }).subscribe((res: any) => {
  //         this.assetSpareList = res;

  //         this.assetSpareList.forEach((item: any) => {
  //           if (!this.userForm.contains(item.supportName)) {
  //             this.userForm.addControl(item.supportName, new FormControl(false));
  //           }
  //           this.allSupportIDs.push(item.supportId);
  //         });
  //       });
  //     } else {
  //       this.showAssetList = false;
  //       this.allSupportIDs = this.allSupportIDs.filter(id => id !== supportID);
  //       this.assetSpareList.forEach(item => {
  //         this.userForm.get(item.supportName)?.setValue(false);
  //       });
  //     }
  //   }
  //   else {
  //     if (isChecked) {
  //       if (supportID && !this.allSupportIDs.includes(supportID)) {
  //         this.allSupportIDs.push(supportID);
  //       }
  //       if (supportID == this.parentSupportID) {
  //         this.showSRTree = true;
  //       }
  //     } else {
  //       if (supportID) {
  //         if (supportID == this.parentSupportID) {
  //           this.showSRTree = false;
  //           this.checkedItemList = [];
  //           this.allSupportIDs = this.getCheckedModuleSupportIds();
  //           //this.allSupportIDs = this.allSupportIDs.filter(id => this.checkedItemList.includes(id));
  //         }
  //         this.allSupportIDs = this.allSupportIDs.filter(id => id !== supportID);
  //       }
  //     }
  //   }
  // }

  onChildModuleChange(childName: string, supportID: number) {
    const isChecked = this.userForm.get(childName)?.value;

    if (supportID == 5) {
      if (isChecked) {
        this.showAssetList = true;
        this.allSupportIDs.push(supportID);

        this.httpSer.httpGet('/SupportMaster/GetParentValue', { ParentId: supportID }).subscribe((res: any) => {
          this.assetSpareList = res;

          this.assetSpareList.forEach((item: any) => {
            if (!this.userForm.contains(item.supportName)) {
              this.userForm.addControl(item.supportName, new FormControl(false));
            }

            this.userForm.get(item.supportName)?.valueChanges.subscribe((checked: boolean) => {
              if (checked && !this.allSupportIDs.includes(item.supportId)) {
                this.allSupportIDs.push(item.supportId);
              }
              else if (!checked) {
                this.allSupportIDs = this.allSupportIDs.filter(id => id !== item.supportId);
              }
            });
          });
        });
      } else {
        this.showAssetList = false;
        this.allSupportIDs = this.allSupportIDs.filter(id => id !== supportID);
        this.assetSpareList.forEach(item => {
          this.userForm.get(item.supportName)?.setValue(false);
        });
      }
    }
    else {
      if (isChecked) {
        if (supportID && !this.allSupportIDs.includes(supportID)) {
          this.allSupportIDs.push(supportID);
        }
        if (supportID == this.parentSupportID) {
          this.addControlsToChild()
          this.showSRTree = true;
        }
      } else {
        if (supportID) {
          if (supportID == this.parentSupportID) {
            this.showSRTree = false;
            this.checkedItemList = [];
            this.allSupportIDs = this.getCheckedModuleSupportIds();
          }
          this.allSupportIDs = this.allSupportIDs.filter(id => id !== supportID);
        }
      }
    }
  }

  filteredEmpList: any[] = [];

  addControlsToChild() {

  }
  async fetchAllItems(employeeId: any) {
    try {
      await this.employeeInfo.empList();
      this.filteredEmpList = this.allEmpList.filter((row: any) => row.employeeId == parseInt(employeeId));
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  filterItem() {
    var filter = this.userForm.value.employeeID.toUpperCase().trim();
    this.employeeDropdownList = this.allEmpList.filter((item: any) =>
      item.employeeId.toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter)

    );
    if (this.employeeDropdownList.length === 0 && filter !== '') {
      this.employeeDropdownList.push('');
    }
    else if (filter === '') {
      this.employeeDropdownList.length = 0
    }
    this.userValueBind()
    console.log('Empl ID', filter);
  }

  async selectItem(item: any) {
    if (item.employeeId != undefined) {
      this.userForm.patchValue({ employeeID: item.employeeId?.trim() + ' ' + '-' + ' ' + item.employeeName?.trim() })
      this.empID = item.employeeId;
      this.employeeDropdownList = [];
      try {
        await this.fetchAllItems(item.employeeId);
        this.assignEmployeesDetails();
      } catch (error) {
        console.error('Error fetching items:', error);
      }
    }
  }

  filterItemToCopy() {
    var filter = this.userForm.value.copiedEmpID.toUpperCase().trim();
    this.supportDropdownList = this.supportTeamList.filter((item: any) =>
      item.empId.toString().includes(filter) || item.firstName.toUpperCase().toString().includes(filter)
    );
    if (this.supportDropdownList.length === 0 && filter !== '') {
      this.supportDropdownList.push('');
    }
    else if (filter === '') {
      this.supportDropdownList.length = 0
    }
  }

  selectCopyUserItem(item: any) {
    if (item.supportId != undefined) {
      this.userForm.patchValue({ copiedEmpID: item.empId + ' ' + '-' + ' ' + (item.firstName?.trim() + ' ' + item.middleName?.trim() + ' ' + item.lastName?.trim())?.trim() })
      this.copiedEmployeeID = item.empId;
      this.supportDropdownList = [];
    }
  }

  clearCopiedEmpID() {
    this.copiedEmployeeID = null;
  }

  assignEmployeesDetails() {
    if (this.filteredEmpList && this.filteredEmpList.length > 0) {
      this.EmployeeID = this.filteredEmpList[0].employeeId;
      this.Name = this.filteredEmpList[0].employeeName;
      this.Email = this.filteredEmpList[0].officialEmailId;
      this.ContactNo = this.filteredEmpList[0].mobileNo;
      this.ReportingManager = this.filteredEmpList[0].reportManagerName;
      this.StaffCategory = this.filteredEmpList[0].staffCategory;
      this.Plant = this.filteredEmpList[0].plantcode;
      this.Paygroup = this.filteredEmpList[0].payGroup;
      this.Department = this.filteredEmpList[0].department;
      this.Designation = this.filteredEmpList[0].designation;
      this.Role = this.filteredEmpList[0].role;
    }
  }

  clearEmployeeDetails() {
    this.EmployeeID = '';
    this.Name = '';
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

  getPlant() {
    const apiUrls = '/Plantid'
    this.httpSer.httpGet(apiUrls).subscribe(res => {
      // this.plantList = res;
      this.plantList = res?.map((item: any) => ({
        itemPlant_id: item.id,
        itemPlant_text: item.code
      }));
    })
  }

  getCategoryList() {
    const apiUrls = '/Category';
    this.httpSer.httpGet(apiUrls).subscribe(res => {
      // this.categoryList = res;
      this.categoryList = res?.map((item: any) => ({
        itemCategory_id: item.itcategoryId,
        itemCategory_text: item.categoryName
      }));
    })
  }

  getCategoryTypeList() {
    if (this.categoryList.length > 0) {
      const apirURLS = '/CategoryTyp';
      this.httpSer.httpGet(apirURLS).subscribe(res => {
        if (this.userForm.value.userConfigCategory[0].itemCategory_id) {
          const catType = res.filter((item: any) => item.categoryId == this.userForm.value.userConfigCategory[0].itemCategory_id)
          const catTypeList = catType?.map((item: any) => ({
            itemCategoryType_id: item.categoryTypeId,
            itemCategoryType_text: item.categoryType
          }))
          this.categoryTypeList = [...catTypeList];
        }
        else {
          this.categoryTypeList = [];
        }
      })
    }
  }

  getClassificationList() {
    const apiURL = '/Classification';
    this.httpSer.httpGet(apiURL).subscribe(res => {
      this.classificationList = res?.map((item: any) => ({
        itemClassification_id: item.itclassificationId,
        itemClassification_text: item.classificationName
      }));
    })
  }

  getParents(id: number) {
    this.httpSer.httpGet(this.apiUrl.getParentValue).subscribe((res: any) => {
      this.parentModuleList = res.filter((item: any) => item.parentId == id);
      this.parentModuleList.forEach(module => {
        this.userForm.addControl(module.supportName, this.fb.control(false));
      })
    })
  }

  getSupportByID(ID: any) {
    this.httpSer.httpGet(this.apiUrl.getSupportById, { id: ID }).subscribe((res: any) => {
      this.parentSupportID = res.data.supportId;
    }, (error) => {
      console.error('API request failed', error);
    });
  }

  getCheckedModuleSupportIds(): number[] {
    const checkedModuleSupportIds = this.parentModuleList
      .filter(module => this.userForm.get(module.supportName)?.value)
      .map(module => module.supportId);

    const checkedChildSupportIds = Object.values(this.parentModuleChilds).flatMap(children =>
      children.filter(child => this.userForm.get(child.supportName)?.value).map(child => child.supportId)
    );

    return [...checkedModuleSupportIds, ...checkedChildSupportIds];
  }

  handleCheckedItems(checkedItems: number[]) {
    this.checkedItemList = checkedItems;

    this.checkedItemList.forEach(item => {
      if (!this.allSupportIDs.includes(item)) {
        this.allSupportIDs.push(item);
      }
    });

    const checkedModuleSupportIds = this.getCheckedModuleSupportIds();
    const updatedSupportIds = [...new Set([...this.checkedItemList, ...checkedModuleSupportIds])];
    const assetSpareListIds = this.assetSpareList.map(item => item.supportId);

    this.allSupportIDs = this.allSupportIDs.filter(id =>
      updatedSupportIds.includes(id) || assetSpareListIds.includes(id)
    );
  }

  // handleCheckedItems(checkedItems: number[]) {
  //   debugger
  //   if (this.showSRTree) {
  //     // Update the checkedItemList first
  //     this.checkedItemList = checkedItems;
  //   }

  //   this.checkedItemList.forEach(item => {
  //     if (!this.allSupportIDs.includes(item)) {
  //       this.allSupportIDs.push(item);
  //     }
  //   });

  //   const checkedModuleSupportIds = this.getCheckedModuleSupportIds();

  //   const updatedSupportIds = [...new Set([...this.checkedItemList, ...checkedModuleSupportIds])];

  //   // this.allSupportIDs = updatedSupportIds;
  //   updatedSupportIds.forEach(id => {
  //     if (!this.allSupportIDs.includes(id)) {
  //       this.allSupportIDs.push(id);
  //     }
  //   });

  //   console.log('Updated allSupportIDs:', this.allSupportIDs);
  // }

  // handleCheckedItems(checkedItems: number[]) {
  //   if (this.showSRTree) {
  //     this.checkedItemList = checkedItems;
  //   }
  //   this.checkedItemList.forEach(item => {
  //     if (!this.allSupportIDs.includes(item)) {
  //       this.allSupportIDs.push(item);
  //     }
  //   });
  //   const checkedModuleSupportIds = this.getCheckedModuleSupportIds();
  //   this.allSupportIDs = this.allSupportIDs.filter(id =>
  //     this.checkedItemList.includes(id) || checkedModuleSupportIds.includes(id)
  //   );
  // }

  Submit() {
    if (!this.showAdminSuperAdmin) {
      if (!this.empID || !this.userForm.get('employeeID')?.value) {
        return alert('Enter Employee ID!')
      }
      if (!this.copiedEmployeeID || !this.userForm.get('copiedEmpID')?.value) {
        return alert('Please Select Employee ID to Copy!')
      }
      this.ExecuteCopy()
    }
    else {
      if (this.userForm.get('Admin')?.value && this.userForm.get('superAdmin')?.value) {
        return alert('Both the Roles Cannot Be Selected!')
      }
      if (this.userForm.get('Admin')?.value == true && this.userForm.get('superAdmin')?.value == false || this.userForm.get('Admin')?.value == false && this.userForm.get('superAdmin')?.value == false) {
        if (!this.empID || !this.userForm.get('employeeID')?.value) {
          return alert('Enter Employee ID!')
        }
        else if (!this.userForm.get('userConfigPlant')?.value) {
          return alert('Select Plant!')
        }
        else if (!this.userForm.get('userConfigCategory')?.value) {
          return alert('Select Category!')
        }
        else if (!this.userForm.get('userConfigCategoryType')?.value) {
          return alert('Select Category Type!')
        }
        else if (!this.userForm.get('userConfigClassification')?.value) {
          return alert('Select Classification!')
        }
        else if (this.allSupportIDs.length == 0) {
          return alert('Please select any Module!')
        }
        else {
          this.ExecuteSubmit()
        }
      }
      else if (this.userForm.get('Admin')?.value == false && this.userForm.get('superAdmin')?.value == true) {
        if (!this.empID || !this.userForm.get('employeeID')?.value) {
          return alert('Enter Employee ID!')
        } else {
          this.ExecuteSubmit();
        }
      }
    }
  }

  getSupportTeam() {
    this.httpSer.httpGet('/SupportTeam').subscribe((res: any[]) => {
      this.supportTeamList = Array.from(
        new Map(res.map(item => [item.empId, item])).values()
      );
    });
  }


  getSupportTeamAssign() {
    this.httpSer.httpGet('/SupportteamAssigned', { supportTeamId: Number(this.supportTeamID) }).subscribe((res: any) => {
      this.suportTeamAssignList = res.data
    });
  }

  ExecuteCopy() {
    let param = {
      empId: Number(this.empID),
      existingEmpId: Number(this.copiedEmployeeID),
      createdBy: parseInt(this.user.empData.employeeNo)
    }
    this.httpSer.httpPost('/SupportTeam/copySupportTeam', param).subscribe((res: any) => {
      if (res.type == 'S') {
        alert("Submitted Successfully!");
        this.router.navigate(['/support_view']);
      } else {
        alert("Submit failed!");
      }
    }, (error) => {
      console.error('API request failed', error);
    });
  }

  async ExecuteSubmit() {
    const apiUrl = '/SupportTeam/PostSupportTeam';
    let lastSuccessful = false;
    for (const m of this.allSupportIDs) {
      const param = {
        "flag": "I",
        "supportTeamId": 0,
        "supportTeamAssgnID": 0,
        "email": this.filteredEmpList[0].officialEmailId ? this.filteredEmpList[0].officialEmailId : '',
        "firstName": this.filteredEmpList[0].firstName ? this.filteredEmpList[0].firstName : '',
        "middleName": this.filteredEmpList[0].middleName ? this.filteredEmpList[0].middleName : '',
        "lastName": this.filteredEmpList[0].lastName ? this.filteredEmpList[0].lastName : '',
        "imgUrl": "",
        "designation": this.filteredEmpList[0].designation ? this.filteredEmpList[0].designation : '',
        "role": this.filteredEmpList[0].role ? this.filteredEmpList[0].role : '',
        "empId": Number(this.empID),
        "isActive": true,
        "dol": "2024-10-17T11:08:50.005Z",
        "dob": "2024-10-17T11:08:50.005Z",
        "isAdmin": this.userForm.get('Admin')?.value,
        "isSuperAdmin": this.userForm.get('superAdmin')?.value,
        "isApprover": this.userForm.get('isApprove')?.value,
        "isChangeAnalyst": this.userForm.get('isAnalyst')?.value,
        "isSupportEngineer": this.userForm.get('isExecutive')?.value,
        "plantId": this.userForm.get('userConfigPlant')?.value[0].itemPlant_id,
        "supportId": 1,
        "categoryId": this.userForm.get('userConfigCategory')?.value[0].itemCategory_id,
        "categoryTypID": this.userForm.get('userConfigCategoryType')?.value[0].itemCategoryType_id,
        "classificationId": this.userForm.get('userConfigClassification')?.value[0].itemClassification_id,
        "approverstageCR": this.userForm.get('CRApproverLevel1')?.value ? 'N' : '',
        "approverstageR": this.userForm.get('releaseApproverLevel1')?.value ? 'R' : '',
        "approverstageC": this.userForm.get('closureApproverLevel1')?.value ? 'C' : '',
        "level": this.userForm.get('approverLevel1')?.value == true ? 1 : 0,
        "approverstage2CR": this.userForm.get('CRApproverLevel2')?.value ? 'N' : '',
        "approverstage2R": this.userForm.get('releaseApproverLevel2')?.value ? 'R' : '',
        "approverstage2C": this.userForm.get('closureApproverLevel2')?.value ? 'C' : '',
        "level2": this.userForm.get('approverLevel2')?.value == true ? 2 : 0,
        "approverstage3CR": this.userForm.get('CRApproverLevel3')?.value ? 'N' : '',
        "approverstage3R": this.userForm.get('releaseApproverLevel3')?.value ? 'R' : '',
        "approverstage3C": this.userForm.get('closureApproverLevel3')?.value ? 'C' : '',
        "level3": this.userForm.get('approverLevel3')?.value == true ? 3 : 0,
        "createdBy": parseInt(this.user.empData.employeeNo),
        "createdDate": new Date().toISOString(),
        "supportIds": []
      }
      try {
        const res = await this.httpSer.httpPost(apiUrl, param).toPromise();
        const response = res as unknown as { type: string; message: string; data: any; count: number };

        if (m === this.allSupportIDs[this.allSupportIDs.length - 1]) {
          lastSuccessful = response && response.type !== "E";
        }
      } catch (error) {
        console.error('API error:', error);
      }

      console.log('param', param)
    }

    if (lastSuccessful) {
      alert('Successfully Submitted!');
      this.router.navigate(['/support_view']);
    } else {
      alert('The last submission failed. Please check the details.');
    }
  }

  onChangeCheckBox() {
    if (this.userForm.get('Admin')?.value == false && this.userForm.get('superAdmin')?.value == true) {
      this.clearAll();
    }
    else if (this.userForm.get('Admin')?.value == true && this.userForm.get('superAdmin')?.value == true) {
      this.userForm.patchValue({ Admin: false })
      this.clearAll();
    }
  }

  resetRole() {
    this.userForm.patchValue({ roleRadio: 'Admin' });
  }

  clearAll() {
    this.empID = null;
    this.copiedEmployeeID = null;
    this.userForm.patchValue({
      employeeID: '',
      userConfigPlant: '',
      userConfigCategory: '',
      userConfigCategoryType: '',
      userConfigClassification: '',
      copiedEmpID: ''
    });

    // if (this.showAdminSuperAdmin) {
    //   this.userForm.patchValue({
    //     employeeID: '',
    //     userConfigPlant: '',
    //     userConfigCategory: '',
    //     userConfigCategoryType: '',
    //     userConfigClassification: ''
    //   });
    // }

    // if (!this.showAdminSuperAdmin) {
    //   if (this.userForm.get('employeeID')?.value && this.userForm.get('copiedEmpID')?.value) {
    //     this.userForm.patchValue({ employeeID: '', copiedEmpID: '' })
    //   }
    // }

    this.categoryTypeList = [];

    if (this.allSupportIDs.length > 0) {
      this.parentModuleList.forEach(module => {
        this.userForm.get(module.supportName)?.setValue(false);
      });

      const mockEvent = { target: { checked: false } } as Event & { target: { checked: boolean } };
      this.parentModuleList.forEach(module => {
        this.onParentCheckBoxChange(module.supportId, mockEvent);
      });

      this.treeViewComponent?.clearCheckedItems(this.treeViewComponent.treeData);
    }
    this.showCRList = false;
    this.showAssetList = false;
    if (this.assetSpareList.length > 0) {
      this.assetSpareList.forEach(item => {
        this.userForm.get(item.supportName)?.setValue(false);
      });
    }
    this.resetCRList();
  }

  resetApproverLevels() {
    this.userForm.patchValue({
      approverLevel1: false,
      approverLevel2: false,
      approverLevel3: false,
    })
    this.resetNRC('ApproverLevel1');
    this.resetNRC('ApproverLevel2');
    this.resetNRC('ApproverLevel3');
  }

  onApproveChange() {
    this.resetApproverLevels();
    if (this.userForm.get('isApprove')?.value == true) {
      this.showApproverLevels = true;
    } else {
      this.showApproverLevels = false;
      this.showApproverLevel1 = false;
      this.showApproverLevel2 = false;
      this.showApproverLevel3 = false;
    }
  }

  resetNRC(level: string) {
    if (level == 'ApproverLevel1') {
      this.userForm.patchValue({
        CRApproverLevel1: false,
        releaseApproverLevel1: false,
        closureApproverLevel1: false
      })
    }
    if (level == 'ApproverLevel2') {
      this.userForm.patchValue({
        CRApproverLevel2: false,
        releaseApproverLevel2: false,
        closureApproverLevel2: false
      })
    }
    if (level == 'ApproverLevel3') {
      this.userForm.patchValue({
        CRApproverLevel3: false,
        releaseApproverLevel3: false,
        closureApproverLevel3: false
      })
    }
  }

  approverLevel1() {
    this.resetNRC('ApproverLevel1');
    if (this.userForm.get('approverLevel1')?.value == true) {
      this.showApproverLevel1 = true;
    }
    else {
      this.showApproverLevel1 = false;
    }
  }

  approverLevel2() {
    this.resetNRC('ApproverLevel2');
    if (this.userForm.get('approverLevel2')?.value == true) {
      this.showApproverLevel2 = true;
    }
    else {
      this.showApproverLevel2 = false;
    }
  }

  approverLevel3() {
    this.resetNRC('ApproverLevel3');
    if (this.userForm.get('approverLevel3')?.value == true) {
      this.showApproverLevel3 = true;
    }
    else {
      this.showApproverLevel3 = false;
    }
  }

  copyFunc() {
    this.userForm.patchValue({ copiedEmpID: '' });
    this.showAdminSuperAdmin = !this.showAdminSuperAdmin;
    this.userForm.patchValue({ Admin: false, superAdmin: false });
    this.clearAll();
    if (this.supportTeamList.length == 0) {
      this.getSupportTeam();
    }
  }

  Back() {
    this.location.back();
  }

}
