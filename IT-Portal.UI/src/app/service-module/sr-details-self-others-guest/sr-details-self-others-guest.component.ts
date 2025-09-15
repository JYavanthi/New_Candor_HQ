import { GetEmployeeInfoService } from './../../services/get-employee-info.service';
import { Component, EventEmitter, Input, Output, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { FormValidationService } from 'app/services/form-validation.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-sr-details-self-others-guest',
  templateUrl: './sr-details-self-others-guest.component.html',
  styleUrls: ['./sr-details-self-others-guest.component.css',]
})
export class SrDetailsSelfOthersGuestComponent {
  @ViewChild('EnterIssueID') EnterIssueID: any;
  @Output() radioBtnValues = new EventEmitter<any>();
  @Output() empDetail = new EventEmitter<any>();

  @Input() srData: any;
  srId: any;
  assetId: any;
  spareId: any;
  radioBtnForm !: FormGroup;
  allEmpList: any[] = [];
  supportTeamList: any[] = [];
  filteredSupportTeamList: any[] = [];
  filteredSupportTeamListOthers: any[] = [];
  filteredSupportTeamListGuest: any[] = [];
  dropdownItems: any[] = [];
  allPlantList: any[] = [];
  user: any;
  status!: string;

  othersEmployeeID: string = '';
  othersName: string = '';
  othersEmail: string = '';
  othersContactNo: string = '';
  othersReportingManager: string = '';
  othersStaffCategory: string = '';
  othersPlant: string = '';
  othersPaygroup: string = '';
  othersDepartment: string = '';
  othersDesignation: string = '';
  othersRole: string = '';
  othersDateOfJoining: any;

  ReportingManagerinML: string = '';
  StaffCategoryofML: string = '';
  GuestPlant: string = '';
  PaygroupML: string = '';
  DepartmentML: string = '';
  DesignationofMLManager: string = '';
  RoleofMLManager: string = '';

  selfEmployeeID: string = '';
  selfName: string = '';
  selfEmail: string = '';
  selfContactNo: string = '';
  selfReportingManager: string = '';
  selfStaffCategory: string = '';
  selfPlant: string = '';
  selfPaygroup: string = '';
  selfDepartment: string = '';
  selfDesignation: string = '';
  selfRole: string = '';
  selfDateOfJoining: any;

  constructor(public fb: FormBuilder,
    public userInfo: UserInfoSerService,
    private employeeInfo: GetEmployeeInfoService,
    public formValidationService: FormValidationService,
    private activeRoute: ActivatedRoute) {
    this.user = userInfo.getUser();
    this.employeeInfo.getPlant().then(() => {
      this.allPlantList = this.employeeInfo.plantList;
    })
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.srId = m.srId
      this.assetId = m.assetid
      this.spareId = m.spareid
    });
    this.formInit();
  }

  async ngOnChanges(changes: SimpleChanges) {
    if (changes['srData'] && this.srData != undefined) {
      await this.employeeInfo.empList()
      this.allEmpList = this.employeeInfo.EmpList;
      this.getAllEmpDtls();
      this.patchFormValues(this.srData);
    }
  }

  patchFormValues(data: any) {
    if (!data?.itassetId) {
      this.radioBtnForm.patchValue({
        userType: data?.srselectedfor,
        guestEmployeeID: data?.guestEmployeeId,
        guestName: data?.guestName,
        guestEmail: data?.guestEmail,
        guestContactNo: data?.guestContactNo,
      })
      this.updateOnChange();
    }

    if (data?.itassetId || data?.itspareId) {
      this.employeeInfo.empList().then(() => {
        this.radioBtnForm.patchValue({
          userType: data?.srselectedfor,
          guestEmployeeID: data?.guestId,
          guestName: data?.guestName,
          guestEmail: data?.guestEmail,
          guestContactNo: data?.guestContactNo,
        })
        this.allEmpList = this.employeeInfo.EmpList;
        if (data?.srselectedfor == "others") {
          const inputEmployeeID = this.allEmpList.filter((row: any) => row.employeeId == data?.requestedFor)[0];
          this.radioBtnForm.patchValue({
            inputEmployeeID: inputEmployeeID?.employeeId?.trim() + ' ' + '-' + ' ' + inputEmployeeID?.employeeName?.trim(),
          })
        }
        else if (data?.srselectedfor == "guest") {
          const guestReportingManagerEmployeeId = this.allEmpList.filter(row => row.employeeId == data?.guestRmanagerId || row.employeeId == data?.guestReportingManagerEmployeeId)[0];
          this.radioBtnForm.patchValue({
            reportingManagerID: guestReportingManagerEmployeeId?.employeeId?.trim() + ' ' + '-' + ' ' + guestReportingManagerEmployeeId?.employeeName?.trim()
          })
        }
        this.updateOnChange();
        if (data?.status?.trim() != 'Draft') {
          this.radioBtnForm.get('inputEmployeeID')?.disable();
        }
      })
    }

    if (data?.status?.trim() != 'Draft') {
      this.radioBtnForm.disable();
    }
  }

  getAllEmpDtls() {
    if (!this.assetId && !this.spareId) {
      this.employeeInfo.empList().then(() => {
        this.allEmpList = this.employeeInfo.EmpList;
        if (!this.srData?.selectedFor) {
          this.onChangingRadiobtn();
        }
        if (this.srId) {
          if (this.srData?.srselectedfor == "others") {
            const inputEmployeeID = this.allEmpList.filter((row: any) => row.employeeId == parseInt(this.srData?.srraiseFor?.split('(')[1]?.split(')')[0]?.trim()))[0];
            this.radioBtnForm.patchValue({
              inputEmployeeID: inputEmployeeID?.employeeId?.trim() + ' ' + '-' + ' ' + inputEmployeeID?.employeeName?.trim(),
            })
          }
          else if (this.srData?.srselectedfor == "guest") {
            const guestReportingManagerEmployeeId = this.allEmpList.filter((row: any) => row.employeeId == parseInt(this.srData?.guestReportingManagerEmployeeId))[0];
            this.radioBtnForm.patchValue({
              reportingManagerID: guestReportingManagerEmployeeId?.employeeId?.trim() + ' ' + '-' + ' ' + guestReportingManagerEmployeeId?.employeeName?.trim()
            })
          }
          this.patchFormValues(this.srData);
        }
      });
    }
    if (this.assetId || this.spareId) {
      this.onChangingRadiobtn()
    }
  }

  formInit() {
    this.radioBtnForm = this.fb.group({
      userType: ['self'],
      inputEmployeeID: [null, Validators.required],
      guestEmployeeID: [null],
      guestName: ['', Validators.required],
      guestEmail: [''],
      guestContactNo: [null],
      reportingManagerID: [null, Validators.required]
    })
    if (!this.srId && !this.assetId && !this.spareId) {
      this.getAllEmpDtls();
    }
  }

  onInput(event: Event): void {
    const input = event.target as HTMLInputElement;
    input.value = input.value.replace(/[^0-9]/g, '');
    if (input.value.length > 10) {
      input.value = input.value.slice(0, 10);
    }
    this.radioBtnForm.get('guestContactNo')?.setValue(input.value);
  }

  allFields = {
    userType: 'self',
    inputEmployeeID: null,
    guestEmployeeID: null,
    guestName: '',
    guestEmail: '',
    guestContactNo: null,
    reportingManagerID: null
  }

  resetFields() {
    this.radioBtnForm.patchValue(this.allFields)
    this.radioBtnForm.get('inputEmployeeID')?.disable();
  }

  async onChangingRadiobtn() {
    if (this.radioBtnForm.value.userType) {
      this.ClearInputs();
      this.updateOnChange();
    }
  }

  async updateOnChange() {
    if (this.radioBtnForm.controls['userType'].value == "self") {
      this.radioBtnForm.get('inputEmployeeID')?.disable();
    }
    else if (this.radioBtnForm.controls['userType'].value == "others") {
      this.radioBtnForm.get('inputEmployeeID')?.enable();
      setTimeout(() => {
        this.EnterIssueID.nativeElement.focus();
      }, 0);
    }
    else if (this.radioBtnForm.controls['userType'].value == "guest") {
      this.radioBtnForm.get('inputEmployeeID')?.disable();
    }
    try {
      await this.fetchAllItems();
      this.getInputDatas();
    }
    catch (error) {
      console.error('Error fetching items:', error);
    }
  }

  restrictNonNumeric(event: KeyboardEvent): void {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode < 48 || charCode > 57) {
      event.preventDefault();
    }
  }


  async fetchAllItems() {
    try {
      if (this.allEmpList.length > 0) {
        const empID = Number(this.srData?.srraiseBy?.split('(')[1].split(')')[0]) || parseInt(this.user.empData.employeeNo)
        this.filteredSupportTeamList = this.allEmpList.filter((row: any) => row.employeeId == empID);

        if (this.radioBtnForm.controls['userType'].value == "others") {
          this.filteredSupportTeamListOthers = this.allEmpList.filter((row: any) => row.employeeId == parseInt(this.radioBtnForm.value.inputEmployeeID?.trim()));

        }
        if (this.radioBtnForm.controls['userType'].value == "guest") {
          this.filteredSupportTeamListGuest = this.allEmpList.filter((row: any) => row.employeeId == parseInt(this.radioBtnForm.value.reportingManagerID?.trim()));
        }
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  async selectItem(item: any) {
    this.empDetail.emit(item);
    if (this.radioBtnForm.value.userType == "others") {
      this.radioBtnForm.patchValue({ inputEmployeeID: item.employeeId?.trim() + '-' + item.employeeName?.trim() })
      this.dropdownItems = [];
    }

    if (this.radioBtnForm.value.userType == "guest") {
      this.radioBtnForm.patchValue({ reportingManagerID: item.employeeId?.trim() + '-' + item.employeeName?.trim() })
      this.dropdownItems = [];
    }

    try {
      await this.fetchAllItems();
      this.getInputDatas();
    } catch (error) {
      console.error('Error fetching items:', error);
    }
  }

  filterItem() {
    if (this.radioBtnForm.value.inputEmployeeID) {
      var filter = this.radioBtnForm.value.inputEmployeeID.toUpperCase().trim();
    }
    else if (this.radioBtnForm.value.reportingManagerID) {
      var filter = this.radioBtnForm.value.reportingManagerID.toUpperCase().trim();;
    }
    this.dropdownItems = this.allEmpList.filter((item: any) =>
    ((item.employeeId.toUpperCase().toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter)) &&
      item.employeeId != this.user.empData.employeeNo)
    );
    if (this.dropdownItems.length === 0 && filter === '') {
      this.dropdownItems.push('');
    } else if (filter === '') {
      this.dropdownItems.length = 0;
    }
  }

  getInputDatas() {
    if (this.selfEmployeeID == '') {
      if (this.filteredSupportTeamList && this.filteredSupportTeamList.length > 0) {
        this.selfEmployeeID = this.filteredSupportTeamList[0].employeeId;
        this.selfName = this.filteredSupportTeamList[0].employeeName;
        this.selfEmail = this.filteredSupportTeamList[0].officialEmailId;
        this.selfContactNo = this.filteredSupportTeamList[0].mobileNo;
        this.selfReportingManager = this.filteredSupportTeamList[0].reportManagerName;
        this.selfStaffCategory = this.filteredSupportTeamList[0].staffCategory;
        this.selfPlant = this.filteredSupportTeamList[0].plantcode;
        this.selfPaygroup = this.filteredSupportTeamList[0].payGroup;
        this.selfDepartment = this.filteredSupportTeamList[0].department;
        this.selfDesignation = this.filteredSupportTeamList[0].designation;
        this.selfRole = this.filteredSupportTeamList[0].role;
        this.selfDateOfJoining = this.filteredSupportTeamList[0].dateOfJoining;
      }
    }

    if (this.radioBtnForm.controls['userType'].value == 'others') {
      if (this.filteredSupportTeamListOthers && this.filteredSupportTeamListOthers.length > 0) {
        this.othersEmployeeID = this.filteredSupportTeamListOthers[0].employeeId;
        this.othersName = this.filteredSupportTeamListOthers[0].employeeName;
        this.othersEmail = this.filteredSupportTeamListOthers[0].officialEmailId;
        this.othersContactNo = this.filteredSupportTeamListOthers[0].mobileNo;
        this.othersReportingManager = this.filteredSupportTeamListOthers[0].reportManagerName;
        this.othersStaffCategory = this.filteredSupportTeamListOthers[0].staffCategory;
        this.othersPlant = this.filteredSupportTeamListOthers[0].plantcode;
        this.othersPaygroup = this.filteredSupportTeamListOthers[0].payGroup;
        this.othersDepartment = this.filteredSupportTeamListOthers[0].department;
        this.othersDesignation = this.filteredSupportTeamListOthers[0].designation;
        this.othersRole = this.filteredSupportTeamListOthers[0].role;
        this.othersDateOfJoining = this.filteredSupportTeamListOthers[0].dateOfJoining;
      }
    }
    else if (this.radioBtnForm.controls['userType'].value == 'guest') {
      if (this.filteredSupportTeamListGuest && this.filteredSupportTeamListGuest.length > 0) {
        this.ReportingManagerinML = this.filteredSupportTeamListGuest[0].reportManagerName;
        this.StaffCategoryofML = this.filteredSupportTeamListGuest[0].staffCategory;
        this.GuestPlant = this.filteredSupportTeamListGuest[0].plantcode;
        this.PaygroupML = this.filteredSupportTeamListGuest[0].payGroup;
        this.DepartmentML = this.filteredSupportTeamListGuest[0].department;
        this.DesignationofMLManager = this.filteredSupportTeamListGuest[0].designation;
        this.RoleofMLManager = this.filteredSupportTeamListGuest[0].role;
      }
    }
    this.emitData();
  }

  emitData() {
    let serviceRaisedFor: number = 0;
    let plantCode: string = '';
    if (this.radioBtnForm.value.userType == 'self') {
      plantCode = this.selfPlant;
      serviceRaisedFor = Number(this.selfEmployeeID);
    }
    else if (this.radioBtnForm.value.userType == 'others') {
      plantCode = this.othersPlant;
      serviceRaisedFor = Number(this.othersEmployeeID);
    }
    else if (this.radioBtnForm.value.userType == 'guest') {
      plantCode = this.GuestPlant ? this.GuestPlant : this.selfPlant;
      serviceRaisedFor = this.radioBtnForm.value.guestEmployeeID != '' ? Number(this.radioBtnForm.value.guestEmployeeID) : 0;
    }

    const plantID = plantCode ? this.allPlantList.find(plant => plant.code === plantCode)?.id : 0
    let updatedData = {
      formValues: this.radioBtnForm.value,

      selfEmployeeID: this.selfEmployeeID,
      selfName: this.selfName,
      selfEmail: this.selfEmail,
      selfContactNo: this.selfContactNo,
      selfReportingManager: this.selfReportingManager,
      selfStaffCategory: this.selfStaffCategory,
      selfPlant: this.selfPlant,
      selfPaygroup: this.selfPaygroup,
      selfDepartment: this.selfDepartment,
      selfDesignation: this.selfDesignation,
      selfRole: this.selfRole,
      selfDateOfJoining: this.selfDateOfJoining,

      othersEmployeeID: this.othersEmployeeID,
      othersName: this.othersName,
      othersEmail: this.othersEmail,
      othersContactNo: this.othersContactNo,
      othersReportingManager: this.othersReportingManager,
      othersStaffCategory: this.othersStaffCategory,
      othersPlant: this.othersPlant,
      othersPaygroup: this.othersPaygroup,
      othersDepartment: this.othersDepartment,
      othersDesignation: this.othersDesignation,
      othersRole: this.othersRole,
      othersDateOfJoining: this.othersDateOfJoining,

      guestReportingManager: this.ReportingManagerinML,
      guestStaffCategory: this.StaffCategoryofML,
      guestPlant: this.GuestPlant,
      guestPaygroup: this.PaygroupML,
      guestDepartment: this.DepartmentML,
      guestDesignation: this.DesignationofMLManager,
      guestRole: this.RoleofMLManager,

      plantID: plantID,
      validationStatus: this.status || '',
      serviceRaisedFor: serviceRaisedFor
    };
    this.radioBtnValues.emit(updatedData);
  }

  ClearInputs() {
    this.filteredSupportTeamList = [];
    this.filteredSupportTeamListOthers = [];
    this.filteredSupportTeamListGuest = [];
    this.dropdownItems = [];

    this.selfEmployeeID = '';
    this.selfName = '';
    this.selfEmail = '';
    this.selfContactNo = '';
    this.selfReportingManager = '';
    this.selfStaffCategory = '';
    this.selfPlant = '';
    this.selfPaygroup = '';
    this.selfDepartment = '';
    this.selfDesignation = '';
    this.selfRole = '';
    this.status = '';

    this.clearOtherData();
    this.clearGuestData();

    this.radioBtnForm.patchValue({
      inputEmployeeID: null,
      guestEmployeeID: null,
      guestName: '',
      guestEmail: '',
      guestContactNo: null,
      reportingManagerID: null
    });
  }

  onMobileNumberChange(event: any): void {
    const inputValue = event.target.value;
    if (inputValue.length > 10) {
      event.preventDefault();
      event.target.value = inputValue.slice(0, 10);
    }
    event.target.value = event.target.value.replace(/\D/g, '');
  }

  clearOtherData() {
    this.othersEmployeeID = '';
    this.othersName = '';
    this.othersEmail = '';
    this.othersContactNo = '';
    this.othersReportingManager = '';
    this.othersStaffCategory = '';
    this.othersPlant = '';
    this.othersPaygroup = '';
    this.othersDepartment = '';
    this.othersDesignation = '';
    this.othersRole = '';
    this.status = '';
    this.filteredSupportTeamListOthers = [];

    const updatedData = {
      formValues: this.radioBtnForm.value,
      othersEmployeeID: this.othersEmployeeID,
      plantID: 0,
      serviceRaisedFor: 0,
      validationStatus: ''
    };
    this.radioBtnValues.emit(updatedData);
  }

  clearGuestData() {
    this.ReportingManagerinML = '';
    this.StaffCategoryofML = '';
    this.GuestPlant = '';
    this.PaygroupML = '';
    this.DepartmentML = '';
    this.DesignationofMLManager = '';
    this.RoleofMLManager = '';
    this.status = '';
    this.filteredSupportTeamListGuest = [];

    const updatedData = {
      formValues: this.radioBtnForm.value,
      guestReportingManager: this.ReportingManagerinML,
      plantID: 0,
      serviceRaisedFor: 0,
      validationStatus: ''
    };
    this.radioBtnValues.emit(updatedData);
  }

  executeFunc() {
    this.status = '';
    this.getInputDatas();

    if (this.formValidationService.validateForm(this.radioBtnForm)) {
      const userType = this.radioBtnForm.get('userType')?.value;

      if (userType === 'self') {
        this.status = 'Success';
        this.getInputDatas();
      }

      if (userType === 'others') {
        if (this.radioBtnForm.get('inputEmployeeID')?.value && !this.othersEmployeeID) {
          return alert("Please Enter Valid Employee ID!");
        }
        this.status = 'Success';
        this.getInputDatas();
      }

      if (userType === 'guest') {
        const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        if (this.radioBtnForm.get('guestEmail')?.value && !emailPattern.test(this.radioBtnForm.get('guestEmail')?.value)) {
          return alert("Please enter a valid email address!");
        }

        if (this.radioBtnForm.get('reportingManagerID')?.value && !this.ReportingManagerinML) {
          return alert("Please Enter Valid Reporting Manager Employee ID!");
        }
        if (this.radioBtnForm.get('guestContactNo')?.value && this.radioBtnForm.get('guestContactNo')?.value?.toString()?.length != 10) {
          return alert("Please Enter 10-digit Contact Number!");
        }

        this.status = 'Success';
        this.getInputDatas();
      }
    }
  }

}
