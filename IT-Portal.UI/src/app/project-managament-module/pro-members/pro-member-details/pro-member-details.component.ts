import { filter } from 'rxjs';
import { Location } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { FormValidationService } from 'app/services/form-validation.service';

interface DropdownDepartmentItem {
  itemDepartment_text?: string;
}

@Component({
  selector: 'app-pro-member-details',
  templateUrl: './pro-member-details.component.html',
  styleUrls: ['./pro-member-details.component.css', '../../promanagement.css']
})
export class ProMemberDetailsComponent {
  employeeList: any[] = [];
  selectedEmployeeDetails: any;
  projectId: any;
  loggedinUserDetails: any;
  memberDetails: any;
  memberId: any;
  dropdownListDepartment: any[] = [];
  projectdetails: any
  orgEmpList: any
  ASCI: any[] = ['Responsibility', 'Accountable', 'Consulted', 'Informed']

  constructor(public fb: FormBuilder, public employeeInfo: GetEmployeeInfoService, private httpSer: HttpServiceService,
    private activateRoute: ActivatedRoute, private userInfo: UserInfoSerService, private location: Location,
    public formValidationService: FormValidationService
  ) {
    this.employeeInfo.empList();
    this.loggedinUserDetails = userInfo.getUser();
    this.activateRoute.queryParams.subscribe((m: any) => {
      this.projectId = m.projectId;
      this.memberId = m.memberId;
      if (this.memberId) {
        this.getMemberData(this.memberId);
      }
    })
    this.formInit();
  }

  ngOnInit() {
    this.dropdownListDepartment = this.ASCI
    this.getProjectDetails()
  }

  membersForm!: FormGroup

  allFieldValues = {
    projectName: '',
    type: '',
    inputEmployeeId: '',
    department: [],
    participants: ''
  }

  formInit() {
    this.membersForm = this.fb.group({
      participants: ['',Validators.required],
      type: ['', Validators.required],
      inputEmployeeId: ['', Validators.required],
      empId: ['', Validators.required],
      department: [[]]
    });
  }

  clearForm() {
    this.membersForm.patchValue(this.allFieldValues);
    this.selectedEmployeeDetails = undefined
  }

  clear() {
    this.selectedEmployeeDetails = '';
  }

  filterItem() {
    var filter = this.membersForm.value.inputEmployeeId.toUpperCase().trim();

    this.orgEmpList = this.employeeInfo?.EmpList
    this.employeeList = this.employeeInfo?.EmpList?.filter((item: any) =>
      item.employeeId.toUpperCase().toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter)
    );
    if (this.employeeList.length === 0 && filter === '') {
      this.employeeList.push('');
    } else if (filter === '') {
      this.employeeList.length = 0;
    }
  }

  async getMemberData(memberId: any) {
    await this.employeeInfo.empList();
    this.httpSer.httpGet('/projectManagement/getMemberByMemberId', { id: memberId }).subscribe((response: any) => {
      let departMents = []
      if (response?.data?.responsible) departMents.push('Responsibility')
      if (response?.data?.accountable) departMents.push('Accountable')
      if (response?.data?.consulted) departMents.push('Consulted')
      if (response?.data?.informed) departMents.push('Informed')
      this.membersForm.patchValue({
        participants: response.data.role, type: response.data.type,
        department: departMents
      });
      const memberId = this.employeeInfo?.EmpList?.filter((m: any) => m.employeeId == response.data.empId

      );
      this.selectItem(memberId[0]);
      this.membersForm.disable();
    })

  }

  dropdownDepartmentSettings = {
    textField: 'itemDepartment_text'
  };



  selectItem(item: any) {
    this.membersForm.patchValue({
      inputEmployeeId: item.employeeId?.trim() + '-' + item.employeeName?.trim(),
      empId: item.employeeId
    })
    this.selectedEmployeeDetails = item;
    this.employeeList = [];
  }


  getProjectDetails() {
    this.httpSer.httpGet('/projectManagement/getProjectById', { id: this.projectId }).subscribe((response: any) => {
      this.projectdetails = response.data;
      if (this.projectdetails?.projectStatus == 'Cancel' || this.projectdetails?.projectStatus == 'Discontinue' || this.projectdetails?.projectStatus == 'Completed'
        || this.projectdetails?.projectStatus == 'Approved'
      ) {
        this.membersForm.disable()
      }
    })
  }

  submitMember() {
    if (!this.orgEmpList?.map((m: any) => m.employeeId).includes(this.membersForm.value.inputEmployeeId?.split('-')[0])) {
      alert('Select valid employee.');
      return
    }

    if (this.formValidationService.validateForm(this.membersForm)) {
      const requestBody = {
        "flag": "I",
        "prMemberId": 0,
        "projectMgmtID": this.projectId,
        "empID": this.selectedEmployeeDetails?.employeeId,
        "role": this.membersForm?.value.participants,
        "type": this.membersForm?.value.type,
        "responsible": this.membersForm?.value?.department?.filter((m: any) => m == 'Responsibility')?.length > 0,
        "accountable": this.membersForm?.value?.department?.filter((m: any) => m == 'Accountable')?.length > 0,
        "consulted": this.membersForm?.value?.department?.filter((m: any) => m == 'Consulted')?.length > 0,
        "informed": this.membersForm?.value?.department?.filter((m: any) => m == 'Informed')?.length > 0,
        "createdBy": parseInt(this.loggedinUserDetails.empData.employeeNo),
        "createdDt": new Date().toISOString().slice(0, 10),
        "modifiedBy": parseInt(this.loggedinUserDetails.empData.employeeNo),
        "modifiedDt": new Date().toISOString().slice(0, 10)
      }
      this.httpSer.httpPost('/projectManagement/saveProjectMember', requestBody).subscribe((response: any) => {
        if (response.type == 'S') {
          alert('Submitted Successfully!');
          this.location.back();
        } else {
          alert(response?.data)
        }
      })
    }
  }
}
