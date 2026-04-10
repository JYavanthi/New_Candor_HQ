import { Component, HostListener } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { trigger, state, style, transition, animate } from '@angular/animations';

@Component({
  selector: 'app-sr-master',
  templateUrl: './sr-master.component.html',
  styleUrl: './sr-master.component.css',
  animations: [
    trigger('expandCollapseAnimation', [
      state('void', style({
        height: '0',
        opacity: '0'
      })),
      state('*', style({
        height: '*',
        opacity: '1'
      })),
      transition('void <=> *', animate('300ms ease-out')),
    ])
  ]
})
export class SrMasterComponent {
  serviceList: any;
  isServiceActive = 'S';
  user: any
  filteredList: any;
  isVisible: boolean = false;
  filterForm: any;
  serviceModuleList: any;
  requestTypeList: any;
  formFilteredList: any;
  paginatedTableData: any
  pageSize = 10
  pageIndex = 0
  paginatedData: any;
  assign: any = '';
  reAssign: any = '';
  assignToDropDown = false;
  reAssignToDropDown = false;
  assignToList: any;
  reAssignToList: any;
  Allselected = false;
  selectedRow: any[] = [];
  disableAssign: boolean = true;
  disableReAssign = true;
  isOpenService = true


  constructor(public httpSer: HttpServiceService, private route: Router, private fb: FormBuilder,
    public userInfoSer: UserInfoSerService) { }

  ngOnInit(): void {
    this.user = this.userInfoSer.getUser()
    this.getServiceList();
    this.filterForm = this.fb.group({
      service: [''],
      requestType: [''],
      status: [''],
      StartDate: [''],
      EndDate: ['']
    })
  }

  getServiceList() {
    this.httpSer.httpGet('/serviceMaster/getService').subscribe((res: any) => {
      this.serviceList = res?.data
      this.toggleMyServiceTable('S', true)
    })
  }

  toggleVisibility() {
    this.isVisible = !this.isVisible;
    if (this.isVisible == true) {
      this.getServicesData();
    }
  }

  @HostListener('document:click', ['$event'])
  onDocumentClick(event: MouseEvent) {
    const target = event.target as HTMLElement;
    const field = document.querySelector('.field');
    const button = document.querySelector('button');
    if (field && !field.contains(target) && button && !button.contains(target)) {
      this.assignToDropDown = false;
      this.reAssignToDropDown = false;
    }
  }

  onButtonClick(event: MouseEvent, visible: string) {
    event.stopPropagation();
    if (visible == 'true' || visible == 'reAssign') {
      if (visible == 'true') {
        this.assignToDropDown = !this.assignToDropDown
      }
      if (visible == 'reAssign') {
        this.reAssignToDropDown = !this.reAssignToDropDown
      }
      if (this.assignToDropDown == true || this.reAssignToDropDown == true) {
        this.assign = '';
        this.httpSer.httpGet('/SupportTeam').subscribe((response: any) => {
          let a = response.filter((m: any) => m.supportId == this.selectedRow[0].supportId || m.isSuperAdmin)
          this.assignToList = a.filter((m: any, i: any) => a.map((x: any) => x.empId).indexOf(m.empId) == i);
          this.reAssignToList = this.assignToList.filter((a: any) => !this.selectedRow.some((b: any) => b.assignedTo == a.empId))
        })
      }
    }
    if (visible == 'false' || visible == "reAssignSubmit") {
      if (visible == 'false' && !this.assign) {
        alert('Select Assign to');
        return;
      } else if (visible == "reAssignSubmit" && !this.reAssign) {
        alert("Select Re-Assign to");
        return;
      } else {
        this.assignSubmit()
      }

    }
  }

  assignSubmit() {
    if (this.selectedRow.length === 0) {
      alert('No items selected for resolution.');
      // return;
    }

    const apiPromises: any = [];

    this.selectedRow.forEach(row => {
      const requestBody = {
        "srid": row.srid,
        "assignedBy": this.user?.empData?.employeeNo,
        "assignedTo": this.assign ? this.assign : this.reAssign,
        "modifiedBy": this.user?.empData?.employeeNo,
        "status": "Open"
      };

      const apiRequest = this.httpSer.httpPost('/serviceMaster/srAssignTo', requestBody).toPromise();
      apiPromises.push(apiRequest);
    });

    return Promise.all([Promise.all(apiPromises)])
      .then((apiResponses: any[]) => {
        let successCount = apiResponses.filter(response => response.type !== "E").length;

        if (successCount === 1) {
          alert('Assigned Successfully!');
          this.getServiceList();
          this.reAssignToDropDown = false;
          this.assignToDropDown = false;
          this.selectedRow = [];
          this.disableAssign = true;
          this.disableReAssign = true;
        } else if (successCount > 1) {
          alert(`Successfully Resolved ${successCount} item(s)!`);
        } else {
          alert('No assignments were successfully completed.');
        }

        // if (successCount === 1 || successCount > 1) {
        //   this.BulkResolutionRemarks = '';
        //   this.ShowResolveDescription = false;
        //   this.DisableAssign = true;
        //   this.DisableForward = true;
        //   this.DisableResolve = true;
        //   this.getissuelist();
        //   this.selectedRow = [];
        //   this.mergeIssueList();
        // }

      })
      .catch((error: any) => {
        throw error;
      });
  }

  navigateToEdit(url: any, srId: any) {
    let param = { srId: srId, isEngineer: this.isServiceActive=='S' ? true : false };
    this.route.navigate(['/' + url], { queryParams: param });
  }

  serviceListShow: any
  pendingServiceListShow: any

  toggleMyServiceTable(myService: any, first = false, isOpenSer = true) {
    this.isServiceActive = myService
    this.pageIndex = 0
    if (first) {
      
      this.serviceListShow = (this.serviceList?.filter((m: any) => {
        return (m.hodEmpNo?.toString() == this.user?.empData?.employeeNo || m.rpmEmpNo == this.user?.empData?.employeeNo || this.user?.supportTeamAssignList[0]?.isSuperAdmin
          || this.user?.supportTeamAssignList?.map((a: any) => a.supportId).includes(m.supportId)) && m.status?.trim() != 'Draft'
      }))?.length > 0
      this.pendingServiceListShow = this.serviceList?.filter((m: any) => {
        return ((m.hodEmpNo?.toString() == this.user?.empData?.employeeNo || m.rpmEmpNo == this.user?.empData?.employeeNo) ||
          (m?.srselectedfor?.trim() == 'guest' && m.guestReportingManagerEmployeeId?.toString() == this.user?.empData?.employeeNo)) &&

          (m.status?.trim() == 'Pending Approval' || m.status?.trim() == 'Pending HOD Approval')
      })?.length > 0
    }
    if (this.isServiceActive == 'S') {
      this.filteredList = this.serviceList?.filter((m: any) => {
        return (m.hodEmpNo?.toString() == this.user?.empData?.employeeNo || m.rpmEmpNo == this.user?.empData?.employeeNo || this.user?.supportTeamAssignList[0]?.isSuperAdmin
          || this.user?.supportTeamAssignList?.map((a: any) => a.supportId).includes(m.supportId)) && m.status?.trim() != 'Draft'
      })

      if (this.filteredList?.length == 0) {
        this.isServiceActive = 'P'
      }
    }
    if (this.isServiceActive == 'P') {
      this.filteredList = this.serviceList?.filter((m: any) => {
        return ((m.hodEmpNo?.toString() == this.user?.empData?.employeeNo || m.rpmEmpNo == this.user?.empData?.employeeNo) ||
          (m?.srselectedfor?.trim() == 'guest' && m.guestReportingManagerEmployeeId?.toString() == this.user?.empData?.employeeNo)) &&

          (m.status?.trim() == 'Pending Approval' || m.status?.trim() == 'Pending HOD Approval')
      })
      if (this.filteredList?.length == 0) {
        this.isServiceActive = 'M'
      }
    }
    if (this.isServiceActive == 'M') {
      this.filteredList = this.serviceList?.filter((m: any) => {
        return m.raiseforId?.toString() == this.user?.empData?.employeeNo || m.srraiseBy?.split('(')[1].split(')')[0]?.toString() == this.user?.empData?.employeeNo
      })
      this.toggleMyIssues(isOpenSer)
    }
    this.filetSerList()
  }

  toggleMyIssues(isOpen = true) {
    this.isOpenService = isOpen
    if (this.isOpenService) {
      this.filteredList = this.filteredList?.filter((m: any) => {
        return (m.status?.trim() != 'Resolved')
      })
    } else {
      this.filteredList = this.filteredList?.filter((m: any) => {
        return (m.status?.trim() == 'Resolved')
      })
    }
  }
  getServicesData() {
    this.httpSer.httpGet('/SupportMaster/GetSupportValue').subscribe((response: any) => {
      this.serviceModuleList = response.data.filter((m: any) => m.parentId == 4)
      this.requestTypeList = response.data.filter((m: any) => (m.parentId == Number(this.filterForm.value.service)) && m.parentId.toString() != 0);
    })
  }

  selectAll(event: any) {
    const isChecked = event.target.checked;
    this.paginatedData.forEach((row: any) => row.selected = isChecked);

    if (isChecked) {
      this.selectedRow = [...this.paginatedData];
    } else {
      this.selectedRow = [];
    }
    this.updateButtonStates();
  }

  updateButtonStates() {
    if (this.selectedRow.length > 0 && Array.from(new Set(this.selectedRow.map(m => m.supportId))).length == 1 && this.selectedRow.every(m => m.assignedTo == 0)
      && (this.selectedRow.every(m => m.status.trim() == "Approved") || this.selectedRow.every(m => m.status.trim() == "Approval not required"))) {
      this.disableAssign = false;
    } else {
      this.disableAssign = true;
    }
    //  const enableReAssign =this.selectedRow.filter(m=> m.status?.trim() !="Pending Approval" || m.status?.trim() !="Draft" ||
    //   m.status?.trim() !="Rejected" || m.status?.trim() !="Resolved" || m.status?.trim() !="Approved" ||
    //    m.status?.trim() !="Approval not required" || m.status?.trim() !="Pending HOD Approval").length>0
    const enableReAssign = this.selectedRow.filter(m => m.status?.trim() == "Pending Approval" || m.status?.trim() == "Draft" ||
      m.status?.trim() == "Rejected" || m.status?.trim() == "Resolved" || m.status?.trim() == "Approved" ||
      m.status?.trim() == "Approval not required" || m.status?.trim() == "Pending HOD Approval").length == 0
    if (this.selectedRow.length > 0 && Array.from(new Set(this.selectedRow.map(m => m.supportId))).length == 1 &&
      this.selectedRow.every(m => m.assignedTo != 0) && enableReAssign) {
      this.disableReAssign = false;
    } else {
      this.disableReAssign = true;
    }
  }


  toggleRowSelection(row: any) {
    if (row.selected) {
      this.selectedRow.push(row);
    } else {
      this.selectedRow = this.selectedRow.filter((r) => r !== row);
    }
    this.Allselected = this.paginatedData.every((item: any) => item.selected);
    this.updateButtonStates();
  }

  onPageChange(event: any, defaultPage: any) {
    if (defaultPage) {
      this.paginatedData = this.formFilteredList?.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize)
    }
    else {
      this.pageIndex = event?.pageIndex;
      this.pageSize = event?.pageSize;
      this.paginatedData = this.formFilteredList?.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize)

    }
  }

  filetSerList() {
    this.formFilteredList = this.filteredList?.filter((m: any) => {
      return (
        (this.filterForm.controls['status'].value == '' || this.filterForm.controls['status'].value == null || m.status?.trim() == this.filterForm.controls['status'].value) &&
        (this.filterForm.controls['service'].value == '' || this.filterForm.controls['service'].value == null || m.serviceId?.toString() == this.filterForm.controls['service'].value) &&
        (this.filterForm.controls['requestType'].value == '' || this.filterForm.controls['requestType'].value == null || m.supportId?.toString() == this.filterForm.controls['requestType'].value) &&
        (this.filterForm.controls['StartDate'].value == '' || this.filterForm.controls['StartDate'].value == null || m.createdDt?.split('T')[0] >= this.filterForm.controls['StartDate'].value) &&
        (this.filterForm.controls['EndDate'].value == '' || this.filterForm.controls['EndDate'].value == null || m.createdDt?.split('T')[0] <= this.filterForm.controls['EndDate'].value)
      );
    })
    this.onPageChange(undefined, true)
  }

  delete(srId: any) {
    this.httpSer.httpGet('/serviceMaster/DeleteSRById', { srId: srId }).subscribe((res: any) => {
      alert('Service Deleted Successfully.')
      this.serviceList = this.serviceList.filter((m: any) => m.srid != srId)
      this.toggleMyServiceTable(this.isServiceActive)
    })
  }



  reset() {
    this.filterForm.reset()
    this.toggleMyServiceTable(this.isServiceActive)
  }
}
