import { Component } from '@angular/core';
import { HttpServiceService } from 'shared/services/http-service.service';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-newsupportmaster',
  templateUrl: './newsupportmaster.component.html',
  styleUrl: './newsupportmaster.component.css',
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
export class NewsupportmasterComponent {
  newSupportMasterForm !: FormGroup;
  supportvalue: any[] = [];
  // rpm: any = '';
  // rpmvalue: any = '';
  allEmpList: any = '';
  // rptManagerID!: number;
  // hodID!: number;
  user: any;
  MMID: any;
  allModuleList: any[] = [];
  // reportingManagerDropdownList: any[] = [];
  // HODDropdownList: any[] = [];
  moduleList: any[] = [];
  getUpdatedDataList: any[] = [];
  allModuleDropdownList: any[] = [];
  selectedModuleID!: number | null;
  isDialogOpen: boolean = false;

  constructor(private fb: FormBuilder, private route: ActivatedRoute, private httpSer: HttpServiceService, private employeeInfo: GetEmployeeInfoService, private userInfo: UserInfoSerService, private router: Router) {
    this.employeeInfo.empList().then(() => {
      this.allEmpList = this.employeeInfo.EmpList;

      this.route.queryParamMap.subscribe((param) => {
        this.MMID = param.get('id');
        if (this.MMID) {
          this.getSupportByID(this.MMID);
        }
      })
    });
    this.user = this.userInfo.getUser();
  }

  ngOnInit() {
    this.formInit();
  }

  formInit() {
    this.newSupportMasterForm = this.fb.group({
      selectParentModule: [''],
      moduleName: [''],
      myfile: [''],
      reportingManagerID: [false],
      HoDID: [false],
      url: [''],
      active: [false],
      visible: [false]
    })
    this.AllModules();
  }

  async AllModules() {
    const apiurl = '/SupportMaster/GetSupportValue';
    try {
      const response: any = await firstValueFrom(this.httpSer.httpGet(apiurl));
      if (response) {
        this.allModuleList = response.data;
      }
    }
    catch (error) {
      console.log(error)
    }
  }

  // filterList(field: string) {
  //   var filter = field == 'reportingManagerID' ? this.newSupportMasterForm.value.reportingManagerID?.toUpperCase().trim() :
  //     field == 'HoDID' ? this.newSupportMasterForm.value.HoDID?.toUpperCase().trim() : '';

  //   const dropdownList = this.allEmpList.filter((item: any) =>
  //     item.employeeId.toUpperCase().toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter)
  //   );

  //   if (field == 'reportingManagerID') {
  //     this.reportingManagerDropdownList = dropdownList;
  //     if (this.reportingManagerDropdownList.length === 0 && filter !== '') { this.reportingManagerDropdownList.push('') }
  //     else if (filter === '') { this.reportingManagerDropdownList.length = 0 }
  //   }
  //   if (field == 'HoDID') {
  //     this.HODDropdownList = dropdownList;
  //     if (this.HODDropdownList.length === 0 && filter !== '') { this.HODDropdownList.push('') }
  //     else if (filter === '') { this.HODDropdownList.length = 0 }
  //   }
  // }

  // selectItem(item: any, selectedField: string) {
  //   if (item.employeeId != undefined) {
  //     selectedField == 'reportingManagerID' ? (this.newSupportMasterForm.patchValue({ reportingManagerID: item.employeeId?.trim() + ' ' + '-' + ' ' + item.employeeName?.trim() }), this.reportingManagerDropdownList = []) :
  //       selectedField == 'HoDID' ? (this.newSupportMasterForm.patchValue({ HoDID: item.employeeId?.trim() + ' ' + '-' + ' ' + item.employeeName?.trim() }), this.HODDropdownList = []) : undefined;

  //     selectedField == 'reportingManagerID' ? this.rptManagerID = item.employeeId : null;
  //     selectedField == 'HoDID' ? this.hodID = item.employeeId : null;
  //   }
  // }

  getFilteredModule(ID: number) {
    this.moduleList = this.allModuleList.filter(item => item.supportId == ID);
    if (this.moduleList.length > 0) {
      this.selectedModuleID = this.getUpdatedDataList[0]?.parentId;
      const updateFields = {
        selectParentModule: this.allModuleList?.find(item => item.supportId == this.getUpdatedDataList[0]?.parentId).supportName,
        moduleName: this.getUpdatedDataList[0]?.supportName,
        myfile: '',
        url: this.getUpdatedDataList[0]?.url,
        reportingManagerID: this.getUpdatedDataList[0]?.isRpmreq,
        HoDID: this.getUpdatedDataList[0]?.isHodreq,
        active: this.getUpdatedDataList[0]?.isActive,
        visible: this.getUpdatedDataList[0]?.isVisible
      }
      this.newSupportMasterForm.patchValue(updateFields);
    }
  }

  getSupportByID(supportID: any) {
    const apiurl = '/SupportMaster/GetSupportById';
    let param = {
      id: parseInt(supportID)
    }
    this.httpSer.httpGet(apiurl, param).subscribe((res: any) => {
      if (res) {
        this.getUpdatedDataList = [res.data];
        this.getFilteredModule(this.getUpdatedDataList[0].supportId);
        // if (this.getUpdatedDataList[0].rpm != 0 && this.getUpdatedDataList[0].hod != 0) {
        //   this.getEmpUpdateData();
        // }
      }
    })
  }

  // getEmpUpdateData() {
  //   const keys = ['rpm', 'hod'];
  //   if (this.allEmpList.length > 0) {
  //     keys.forEach(key => {
  //       const filteredData = this.allEmpList.filter((item: any) =>
  //         item.employeeId.includes(this.getUpdatedDataList[0][key])
  //       )
  //       if (filteredData.length > 0) {
  //         const formControlName = key === 'rpm' ? 'reportingManagerID' : 'HoDID';
  //         this.newSupportMasterForm.patchValue({
  //           [formControlName]: `${filteredData[0].employeeId.trim()} - ${filteredData[0].employeeName.trim()}`
  //         })
  //       }
  //     });
  //   }
  // }

  filterAllModules() {
    var filter = this.newSupportMasterForm.value.selectParentModule.toUpperCase().trim();
    this.allModuleDropdownList = this.allModuleList.filter((item: any) => item.supportName.toUpperCase().toString().includes(filter));
    if (this.allModuleDropdownList.length === 0 && filter !== '') {
      this.allModuleDropdownList.push('No match found. Try again!');
    } else if (filter === '') {
      this.allModuleDropdownList.length = 0;
    }
  }

  selectDropdownItem(item: any) {
    if (item != 'No match found. Try again!') {
      this.newSupportMasterForm.patchValue({ selectParentModule: item.supportName });
      this.selectedModuleID = null;
      this.selectedModuleID = item.supportId;
      this.allModuleDropdownList = [];
    }
  }

  openDialog() {
    this.isDialogOpen = true;
  }

  handleSubmit(data: any) {
    this.newSupportMasterForm.patchValue({ selectParentModule: data.selectedSupportName });
    this.selectedModuleID = null;
    this.selectedModuleID = data.formData.selectedId;
    this.handleClose();
  }

  handleClose() {
    this.isDialogOpen = false;
  }

  submitForm() {
    if (!this.newSupportMasterForm.get('selectParentModule')?.value) {
      return alert('Please enter or select a parent module!')
    }
    else if (!this.newSupportMasterForm.get('moduleName')?.value) {
      return alert('Please enter module name!')
    }
    // else if (!this.newSupportMasterForm.get('reportingManagerID')?.value) {
    //   return alert('Reporting Manager is required!')
    // }
    // else if (!this.newSupportMasterForm.get('HoDID')?.value) {
    //   return alert('HOD is required!')
    // }
    else {
      const apiUrls = this.MMID ? '/SupportMaster/UpdateSupport' : '/SupportMaster/SaveSupport';
      let param = {
        "supportId": this.MMID ? this.MMID : 0,
        "supportName": this.newSupportMasterForm.get('moduleName')?.value,
        "parentId": this.selectedModuleID,
        "rpm": this.newSupportMasterForm.get('reportingManagerID')?.value,
        "hod": this.newSupportMasterForm.get('HoDID')?.value,
        "image": "string",
        "url": this.newSupportMasterForm.get('url')?.value,
        "isActive": this.newSupportMasterForm.get('active')?.value,
        "isVisible": this.newSupportMasterForm.get('visible')?.value,
        "createdBy": this.MMID ? parseInt(this.getUpdatedDataList[0]?.createdBy) : parseInt(this.user.empData.employeeNo),
        "createdDt": "2024-10-14T09:15:02.979Z",
        "modifiedBy": this.MMID ? parseInt(this.user.empData.employeeNo) : 0,
        "modifiedDt": "2024-10-14T09:15:02.979Z"
      }

      const httpCall = this.MMID ? this.httpSer.httpPut(apiUrls, param) : this.httpSer.httpPost(apiUrls, param);

      httpCall.subscribe(
        (response: any) => {
          if (response.type == "S") {
            if (!this.MMID) {
              alert('Status Submitted Successfully!');
            }
            else {
              alert('Status Updated Successfully!');
            }
            this.router.navigate(['/mastermodule/supportmaster']);
          } else {
            alert(response.message);
          }
        }
      )
    }
  }


}
