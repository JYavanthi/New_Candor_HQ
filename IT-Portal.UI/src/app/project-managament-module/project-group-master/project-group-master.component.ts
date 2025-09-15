import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HttpServiceService } from 'shared/services/http-service.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';

@Component({
  selector: 'app-project-group-master',
  templateUrl: './project-group-master.component.html',
  styleUrl: './project-group-master.component.css'
})
export class ProjectGroupMasterComponent {
  id: any
  projectGroupData: any
  user: any
  groupList: any[] = []
  groupvalue: any
  getprojectgroup: any[] = []
  projectdata: any[] =[]
  searchText: any
  constructor(public httpser: HttpServiceService, public route: Router, public userInfoSer: UserInfoSerService) {
    this.getGroupList()
    this.getProjectManagementList()
  }
  getProjectManagementList() {
    this.httpser.httpGet('/projectManagement/getProject').subscribe((response : any)=>{
      this.projectdata = response.data
      // this.paginatedData = this.projectManagementList?.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize)
    })
  }
  deleteRow(id: any) {
    let param = {
      "flag": "D",
      "projectGroupID": id,
      "projectGroupName": "string",
      "isActive": false,
      "createdBy": this.id ? this.user?.empData?.employeeNo : 0,
      "modifiedBy": this.id ? this.user?.empData?.employeeNo : 0
    }
    if(this.projectdata.filter((m:any)=>m.projectGroupId==id)?.length>0){
      alert('Cannot delete this project group because it is associated with existing projects.')
      return
    }
    else{
      this.httpser.httpPost('/projectGroup/saveProject', param).subscribe((res: any) => {
        alert('Project Group Deleted Succesfully.')
        this.getGroupList()
  
      })
    }
  }
  filterData() {
    debugger
    this.groupvalue = this.groupList.filter(item =>
      item.projectGroupName.toLowerCase().includes(this.searchText.toLowerCase())
    );
  }

  getGroupList() {
    this.httpser.httpGet('/projectGroup/getProjectGrops').subscribe((res: any) => {
      this.groupList = res['data']
      this.filterData();
    })
  }


  navigateTo(id: any = null) {
    this.route.navigate(['/projectgroupadd'], { queryParams: { id: id } });
  }
}
