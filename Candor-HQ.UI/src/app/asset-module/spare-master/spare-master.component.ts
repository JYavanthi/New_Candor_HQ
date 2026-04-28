import { Component, HostListener, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpServiceService } from 'shared/services/http-service.service';
import { Location } from '@angular/common';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-spare-master',
  templateUrl: './spare-master.component.html',
  styleUrls: ['./spare-master.component.css', '../assetmodule.css'],
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
export class SpareMasterComponent {
  Allselected = false;
  spareList: any[] = [];
  isAssetActive = 'S';
  isVisible: boolean = false;
  paginatedData: any
  formFilteredList: any = [];
  paginatedTableData: any
  pageSize = 10
  pageIndex = 0
  selectedRow: any[] = [];
  assignToDropDown = false;
  assign: any = '';
  reAssign: any = '';
  assignToList: any;
  reAssignToList: any;
  disableAssign: boolean = true;
  user: any
  asetListShow: any;
  pendingAssetListShow: any;
  filteredList: any;
  isOpenAsset: any;
  filterForm!: FormGroup
  reAssignToDropDown = false;
  disableReAssign = true;

  constructor(public activeRoute: ActivatedRoute, private route: Router, private location: Location,
    public httpSer: HttpServiceService, public userInfoSer: UserInfoSerService, public fb: FormBuilder) {
  }

  ngOnInit() {
    this.user = this.userInfoSer.getUser()
    this.getAssetData()
    this.filterForm = this.fb.group({
      service: [''],
      requestType: [''],
      status: [''],
      StartDate: [''],
      EndDate: ['']
    })
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

  getAssetData() {
    this.httpSer.httpGet('/ITSpareRequest/GetSparevalue').subscribe(
      (response: any) => {
        this.spareList = response?.data;
        this.toggleMyServiceTable('S', true)
        // this.onPageChange(undefined, true)
      }
    )
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

  navigateToBack() {
    this.route.navigate(['/assets/viewassets'])
  }


  toggleMyServiceTable(myService: any, first = false, isOpenSer = true) {
    this.isAssetActive = myService
    this.pageIndex = 0
    if (first) {
      this.asetListShow = (this.spareList?.filter((m: any) => {
        return (m.hodEmpNo?.toString() == this.user?.empData?.employeeNo || m.rpmEmpNo == this.user?.empData?.employeeNo || this.user?.supportTeamAssignList[0]?.isSuperAdmin
          || this.user?.supportTeamAssignList?.map((a: any) => a.supportId).includes(m.supportId)) && m.status?.trim() != 'Draft'
      }))?.length > 0
      this.pendingAssetListShow = this.spareList?.filter((m: any) => {
        return ((m.hodEmpNo?.toString() == this.user?.empData?.employeeNo || m.rpmEmpNo == this.user?.empData?.employeeNo) ||
          (m?.srselectedfor?.trim() == 'guest' && m.guestRmanagerId?.toString() == this.user?.empData?.employeeNo)) &&

          (m.status?.trim() == 'Pending Approval' || m.status?.trim() == 'Pending HOD Approval')
      })?.length > 0
    }
    if (this.isAssetActive == 'S') {
      this.filteredList = this.spareList?.filter((m: any) => {
        return (m.hodEmpNo?.toString() == this.user?.empData?.employeeNo || m.rpmEmpNo == this.user?.empData?.employeeNo || this.user?.supportTeamAssignList[0]?.isSuperAdmin
          || this.user?.supportTeamAssignList?.map((a: any) => a.supportId).includes(m.supportId)) && m.status?.trim() != 'Draft'
      })

      if (this.filteredList?.length == 0) {
        this.isAssetActive = 'P'
      }
    }
    if (this.isAssetActive == 'P') {
      this.filteredList = this.spareList?.filter((m: any) => {
        return ((m.hodEmpNo?.toString() == this.user?.empData?.employeeNo || m.rpmEmpNo == this.user?.empData?.employeeNo) ||
          (m?.srselectedfor?.trim() == 'guest' && m.guestRmanagerId?.toString() == this.user?.empData?.employeeNo)) &&

          (m.status?.trim() == 'Pending Approval' || m.status?.trim() == 'Pending HOD Approval')
      })
      if (this.filteredList?.length == 0) {
        this.isAssetActive = 'M'
      }
    }
    if (this.isAssetActive == 'M') {
      this.filteredList = this.spareList?.filter((m: any) => {
        return m.requestedFor?.toString() == this.user?.empData?.employeeNo || m.requestedBy?.toString() == this.user?.empData?.employeeNo

      })
      this.toggleMyIssues(isOpenSer)
    }
    this.filetSerList()
  }

  filetSerList() {
    // this.formFilteredList = this.filteredList?.filter((m: any) => {
    //   return (
    //   );

    this.formFilteredList = this.filteredList?.filter((m: any) => {
      return (
        (this.filterForm.controls['status'].value == '' || this.filterForm.controls['status'].value == null || m.status?.trim() == this.filterForm.controls['status'].value) &&
        (this.filterForm.controls['service'].value == '' || this.filterForm.controls['service'].value == null || m.requesttype.trim() == this.filterForm.controls['service'].value) &&
        (this.filterForm.controls['StartDate'].value == '' || this.filterForm.controls['StartDate'].value == null || m.createdDt?.split('T')[0] >= this.filterForm.controls['StartDate'].value) &&
        (this.filterForm.controls['EndDate'].value == '' || this.filterForm.controls['EndDate'].value == null || m.createdDt?.split('T')[0] <= this.filterForm.controls['EndDate'].value)
      )
    });
    this.onPageChange(undefined, true)
  }


  delete(srId: any) {
    this.httpSer.httpGet('/ITSpareRequest/deleteSpareById', { ID: srId }).subscribe((res: any) => {
      alert('Service Deleted Successfully.')
      this.spareList = this.spareList.filter((m: any) => m.itspareId != srId)
      this.toggleMyServiceTable(this.isAssetActive)
    })
  }
  toggleMyIssues(isOpen = true) {
    this.isOpenAsset = isOpen
    if (this.isOpenAsset) {
      this.filteredList = this.filteredList?.filter((m: any) => {
        return (m.status?.trim() != 'Resolved')
      })
    } else {
      this.filteredList = this.filteredList?.filter((m: any) => {
        return (m.status?.trim() == 'Resolved')
      })
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
        this.reAssign = '';
        this.httpSer.httpGet('/SupportTeam').subscribe((response: any) => {
          let a = response.filter((m: any) => m.supportId == 9 || m.isSuperAdmin)
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
      return Promise.resolve();
    }
    const apiPromises: any = [];

    this.selectedRow.forEach(row => {
      const requestBody = {

        "flag": "S",
        "itAssetID": 0,
        "itSpareID": row.itspareId,
        "userRemarks": "",
        "proposedResolDt": null,
        "resolDt": null,
        "description": "",
        "onHoldReason": 0,
        "remarks": "",
        "assignedTo": this.assign ? this.assign : this.reAssign,
        "assignedBy": this.user?.empData?.employeeNo,
        "status": "Open",
        "createdBy": this.user?.empData?.employeeNo
      };

      const apiRequest = this.httpSer.httpPost('/AssetRequest/SaveResolution', requestBody).toPromise();
      apiPromises.push(apiRequest);
    });

    return Promise.all([Promise.all(apiPromises)])
      .then((apiResponses: any[]) => {
        let successCount = apiResponses.filter(response => response.type !== "E").length;

        if (successCount === 1) {
          alert('Assigned Successfully!');
          this.getAssetData();
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
      })
      .catch((error: any) => {
        throw error;
      });

  }

  toggleVisibility() {
    this.isVisible = !this.isVisible;
  }

  updateButtonStates() {
    if (this.selectedRow.length > 0 && this.selectedRow.every(m => m.assignedTo == 0 || m.assignedTo == null) &&
      (this.selectedRow.every(m => m.status.trim() == 'Approved') || this.selectedRow.every(m => m.status.trim() == 'Approval not required'))) {
      this.disableAssign = false;
    } else {
      this.disableAssign = true;
    }

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

  navigateToEdit(spareID: any) {
    this.route.navigate(['/assets/itspare'], { queryParams: { spareid: spareID, isEngineer: this.isAssetActive == 'S' } });
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


  reset() {
    this.filterForm.reset()
    this.toggleMyServiceTable(this.isAssetActive)
  }
}
