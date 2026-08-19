import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PasscrdataService } from 'app/change-request/passcrdata.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { GetEmployeeInfoService } from '../../services/get-employee-info.service';

@Component({
  selector: 'app-cr-execute',
  templateUrl: './cr-execute.component.html',
  styleUrl: './cr-execute.component.css',
})
export class CrExecuteComponent {
  templateId: string = '';
  selectoption: string = '';
  predefindTemplateList: any;
  predefindTaskRadio: boolean = false;
  @Input() crData: any;
  templateNames: any;
  getCheckedValues: any;
  systemlandscape: any;
  implementPlanList: any;
  showTaskTable: boolean = false;
  showPreDefindTaskList: any[] = [];
  user: any;
  assignedToMeList: any[] = [];
  executionHistoryList: any[] = [];
  implementBtn: boolean = false;
  landscapeTasks: { [key: string]: any[] } = {};
  landscapeNames: { [key: string]: string } = {};
  landscapeOptions: number[] = [];
  showPreDefindTaskField: boolean = false;
  DisableSelectTemplate: boolean = false;
  itcrid: any = '';
  filteredData: any[] = [];
  releaseforapprove: boolean = false;
  value!: any[];
  executetaskbyid: any[] = [];
  assignToButton: boolean = false;
  issupportengineer: any;
  isImplemented: boolean = false;
  addtaskflag: boolean = false;
  assignAndViewTask: boolean = false;
  templateName: any;
  submitfor: boolean = true;
  actualEndDt: any = '';
  actualEndDtValue = this.actualEndDt ? this.actualEndDt : null;
  allEmpList:any[]=[];
  supportteamList:any[]=[];

  constructor(
    private routeservice: PasscrdataService,
    private httpSer: HttpServiceService,
    private router: Router,
    private route: ActivatedRoute,
    private userInfo: UserInfoSerService,
    private employeeInfo: GetEmployeeInfoService,
  ) {
    this.employeeInfo.empList().then(() => {
      this.allEmpList = this.employeeInfo.EmpList;
    });
    
    this.employeeInfo.suppTeamList().then(() => {
      this.supportteamList = this.employeeInfo.SupportTeamList;
    });

    this.user = userInfo.getUser();
    this.itcrid = this.route.snapshot.paramMap.get('id');
    this.getvalue();
  }

  API_URLS = {
    GET_CR_TASK: '/Crexecute/GetExecute',
    GET_CR_TEMPLATE: '/CRTemplate/GetCRTemplate',
    POST_CR_TEMPLATE: '/CRTemplate/PostCRTemplate',
    executePlanAPI: '/Crexecute/executeplan',
    GET_APPROVER_EMAIL: '/GetApproverforEmail/GetApproverEmail',
    POST_SAVE_TASK: '/CRTemplateExe/PostCRTemplateExe',
    SupportteamAssignedAPI : '/SupportteamAssigned',
  };

  ngOnInit(): void {
    // this.getImplementPlanList();
    this.asignandviewtasks();
    const arrayCRData = [this.crData];
    this.landscapeOptions = arrayCRData
      .map((item: { sysLandscape: any }) => item.sysLandscape)
      .filter(
        (value: any, index: any, self: string | any[]) =>
          self.indexOf(value) === index
      );
    this.getsystemlandscape();
    this.getexecutionhistory();
    this.getsupportteams();
  }

  ngOnChanges() {
    this.isImplemented = this.crData.isImplemented;
    if ([this.crData].length > 0) {
      this.addtaskflag = true;
    } else {
      if (this.crData.crownerid == parseInt(this.user.empData.employeeNo)) {
        this.addtaskflag = true;
      } else {
        this.addtaskflag = false;
      }
    }
  }

  asignandviewtasks() {
    if (Object.keys(this.landscapeTasks).length === 0) {
      this.assignAndViewTask = true;
    } else {
      this.assignAndViewTask = false;
    }
  }

  viewExecutionPlan() {
    this.implementBtn = true;
    this.assignToButton = false;
    this.getvalue();
  }

  isapprover: any;
  getsupportid: any;
async getsupportteams() {
  try {
    await this.employeeInfo.suppTeamList();
    if (this.supportteamList) {
      const supportteams:any[] = this.supportteamList.filter((row: any) => row.empId === parseInt(this.user.empData.employeeNo));
      this.getsupportid = supportteams[0].supportTeamId;
      this.getsupportteamassign();
    }
  }
  catch (error) {
    console.error('GET request failed', error);
  }
}

  async getsupportteamassign() {
    try {
      const response: any = await this.httpSer.httpGet(this.API_URLS.SupportteamAssignedAPI).toPromise();
  
      if (response) {
        const supportteamassign:any[] = response.filter((row: any) => row.supportTeamId === parseInt(this.getsupportid));
        this.isapprover = supportteamassign[0].isApprover;
        this.issupportengineer = supportteamassign[0].isSupportEngineer;
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  // getexecutetask() {
  //   const apiUrl = this.apiurl + '/Crexecute/GetExecute';
  //   const requestBody = {};

  //   this.http.get(apiUrl, requestBody).subscribe(
  //     (response: any) => {
  //       this.executetaskbyid = response.filter((item: any) => item.itcrid === this.crid.itcrid);
  //       this.landscapeTasks = {};
  //       this.landscapeNames = {};
  //       this.executetaskbyid.forEach((item: any) => {
  //         const landscape = item.sysLandscapeid;
  //         if (!this.landscapeTasks[landscape]) {
  //           this.landscapeTasks[landscape] = [];
  //           this.landscapeNames[landscape] = item.sylandscape;
  //         }
  //         this.landscapeTasks[landscape].push(item);
  //       });
  //     },
  //     (error: any) => {
  //       console.error('GET request failed', error);
  //     }
  //   );
  // }

  togglePredefined() {
    this.showPreDefindTaskField = !this.showPreDefindTaskField;
  }

  savePreDefinedTask() {
    const requestBody = {
      flag: 'I',
      crTemplateID: Number(this.templateId),
      crid: Number(this.crData.itcrid),
      createdBy: Number(this.user.empData.employeeNo),
    };

    this.httpSer.httpPost(this.API_URLS.POST_SAVE_TASK, requestBody).subscribe(
      (response: any) => {
        if (response.type == 'E') {
          alert(response.message);
          return;
        }
        else {
          alert('Saved Template Successfully');
          this.router.navigate(['/change-request']);
        }
      },
      (error: any) => {
        console.log('Post request failed', error);
      }
    );
  }

  getPreDefinedTemplates() {
    this.httpSer.httpGet(this.API_URLS.GET_CR_TEMPLATE).subscribe(
      (response: any) => {
        this.templateNames = response.filter(
          (item: any) =>
            item.categoryId == this.crData?.itcategoryId &&
            item.categoryTypId == this.crData?.categoryTypeId
        );

        const groupedTemplates = this.templateNames.reduce(
          (acc: any, item: any) => {
            if (!acc[item.crtemplateId]) {
              acc[item.crtemplateId] = new Set();
            }
            acc[item.crtemplateId].add(item.sysLandscapeId);
            return acc;
          },
          {}
        );

        const checkedValuesSet = new Set(
          this.getCheckedValues.map((id: any) => parseInt(id, 10))
        );

        const qualifyingTemplateIds = Object.keys(groupedTemplates).filter(
          (crtemplateId) => {
            const landscapeIdsSet = groupedTemplates[crtemplateId];
            return (
              checkedValuesSet.size === landscapeIdsSet.size &&
              [...checkedValuesSet].every((val) => landscapeIdsSet.has(val))
            );
          }
        );

        const filteringpredefindtemplate = this.templateNames.filter(
          (item: any) =>
            qualifyingTemplateIds.includes(item.crtemplateId.toString())
        );
        this.predefindTemplateList = this.removeDuplicates(
          filteringpredefindtemplate,
          'crtemplateId'
        );
        if (this.predefindTemplateList.length === 0) {
          this.DisableSelectTemplate = true;
        } else {
          this.DisableSelectTemplate = false;
        }
      },
      (error: any) => {
        console.error('GET request failed', error);
      }
    );
  }

  getExecuteList:any[]=[];
  getvalue() {
    this.httpSer.httpGet(this.API_URLS.GET_CR_TASK).subscribe(
      (response: any) => {
        this.getExecuteList = response;
        this.value = response.filter(
          (item: any) => item.itcrid === parseInt(this.crData.itcrid)
        );
        const totalRecordLength = this.value.length;

        const completedList:any[] = response.filter(
          (item: any) =>
            item.itcrid === this.crData.itcrid && item.status == 'Completed'
        );
        const completedListLength = completedList.length;

        if (Number(totalRecordLength) == Number(completedListLength) && Number(totalRecordLength) != 0 && !this.isImplemented) {
          this.submitfor = true;
        }
        else {
          this.submitfor = false;
        }

        this.landscapeTasks = {};
        this.landscapeNames = {};
        this.value.forEach((item: any) => {
          const landscape = item.sysLandscapeid;
          if (!this.landscapeTasks[landscape]) {
            this.landscapeTasks[landscape] = [];
            this.landscapeNames[landscape] = item.sylandscape;
          }
          this.landscapeTasks[landscape].push(item);
        });
      },
      (error: any) => {
        alert('Request failed -' + error);
      }
    );
  }

  assignToMeFunc(){
    this.assignToButton = true;
    this.implementBtn = false;
    this.assignedToMeList = this.getExecuteList.filter(
      (item: any) =>
        item.itcrid === this.crData.itcrid &&
        item.assignedtoid === parseInt(this.user.empData.employeeNo)
    );
  }

  filterData(event: any) {
    const selectedLandscape: number = event.target.value;
    if (selectedLandscape) {
      this.filteredData = this.value.filter((row: any) => row.sysLandscapeid.toString() === selectedLandscape.toString());
    }
    else {
      this.filteredData = this.value;
    }
  }

  SaveTemplate() {
    if (!this.templateName) {
      alert('Enter Template Name');
    } else {
      const requestBody = {
        flag: 'I',
        crTemplateID: 0,
        templateName: this.templateName,
        crid: this.crData.itcrid,
        crTemplateDtlsID: 0,
        supportID: this.crData.supportId,
        sysLandscapeID: 1,
        classificationID: this.crData.classifcationId,
        categoryID: this.crData.categoryId,
        categoryTypID: this.crData.categoryTypeId,
        taskName: 'string',
        taskDesc: 'string',
        priority: this.crData.priorityType,
        isActive: true,
        createdBy: this.crData.supportId,
      };

      this.httpSer
        .httpPost(this.API_URLS.POST_CR_TEMPLATE, requestBody)
        .subscribe(
          (response: any) => {
            if (response.type == 'E') {
              alert(response.message);
              return;
            } else {
              alert('Saved as predefined task');
              this.router.navigate(['/changerequest/cr-master']);
            }
          },
          (error: any) => {
            console.log('Post request failed', error);
          }
        );
    }
  }

  showPreDefindTask() {
    if (this.templateId == '') {
      alert('Please select template!');
    } else if (this.showPreDefindTaskList.length > 0) {
      alert('Cannot add template, as task exists for the change!');
    } else {
      this.showTaskTable = true;
      this.showPreDefindTaskList = this.templateNames.filter(
        (item: any) => item.crtemplateId === parseInt(this.templateId)
      );
    }
  }

  deleteitcrexecId!: number;
  deleteConfirmation: boolean = false;
  deleteInProgress: boolean = false;
  deleteSuccess: boolean = false;
  deleteMessage: any = '';
  deleteInMessage: any = '';
  deleteItcrexecId : any;

  deleteRow(itcrexecId: any) {
    this.deleteitcrexecId = itcrexecId;
    this.deleteConfirmation = true;
  }

  deleteYes() {
    this.deleteConfirmation = false
    this.executeAction('delete',this.deleteitcrexecId)
  }

  deleteNo() {
    this.deleteConfirmation = false
  }

  navigateinprogress() {
    this.deleteInProgress = false;
  }
  
  navigatesuccess() {
    this.deleteSuccess = false;
    this.router.navigate(["/change-request"])
  }

  getexecutionhistory() {
    const apiUrls = '/ViewChangeHistory/GetCrExecutionPlanHistory?id=' + this.crData?.itcrid;
    this.httpSer.httpGet(apiUrls).subscribe(
      (response: any) => {
        this.executionHistoryList = response.sort((a: any, b: any) => {
          return (
            new Date(a.crhistoryDt).getTime() -
            new Date(b.crhistoryDt).getTime()
          );
        });
      },
      (error) => {
        console.error('Data fetching error', error);
      }
    );
  }
  // getImplementPlanList() {
  //   const apiUrl = '/Crexecute/GetExecute';
  //   this.httpSer.httpGet(apiUrl).subscribe(
  //     (response: any) => {
  //       this.implementPlanList = response.filter((item: any) => item.itcrid === parseInt(this.crData?.itcrid));
  //       this.assignedToMeList = response.filter((item: any) => item.itcrid === this.crData?.itcrid && item.assignedtoid === parseInt(this.user?.supportTeamData?.empId));
  //       let executetaskbyid: any[] = [];
  //       executetaskbyid = this.implementPlanList
  //       executetaskbyid.forEach((item: any) => {
  //         const landscape = item.sysLandscapeid;
  //         if (!this.landscapeTasks[landscape]) {
  //           this.landscapeTasks[landscape] = [];
  //           this.landscapeNames[landscape] = item.sylandscape;
  //         }
  //         this.landscapeTasks[landscape].push(item);
  //       });
  //       // this.totrecords = this.value.length
  //       // this.implcompleted = response.filter((item: any) => item.itcrid === this.crData.itcrid && item.status == 'Completed');
  //       // this.comprecords = this.implcompleted.length

  //     //   if ((Number(this.totrecords) == Number(this.comprecords)) && (Number(this.totrecords) != 0) && (!this.isImplemented))
  //     //     this.submitfor = true;
  //     //   else
  //     //     this.submitfor = false;
  //     },
  //     (error: any) => {
  //       alert('Request failed -' + error);
  //     });
  // }

  removeDuplicates(array: any[], property: string): any[] {
    return array.filter(
      (obj, index, self) =>
        index === self.findIndex((o) => o[property] === obj[property])
    );
  }

  async getsystemlandscape() {
    const apiUrl = '/SystemLandscape/Getsystems';
    const requestBody = {
      categroyId: this.crData?.itcategoryId,
      supportId: this.crData?.supportId,
      classificationId: this.crData?.itclassificationId,
    };
    try {
      const response: any = await this.httpSer
        .httpPost(apiUrl, requestBody)
        .toPromise();

      if (response) {
        this.systemlandscape = response;
        if (this.crData?.['sysLandscapeId'] != null) {
          this.getCheckedValues = this.crData?.['sysLandscapeId'].split(',');
          this.systemlandscape.forEach((m: any) => (m['isChcked'] = this.getCheckedValues.indexOf(m.sysLandscapeId.toString()) != -1? true : false));
          this.systemlandscape = this.systemlandscape.filter((item: any) => item.isChcked == true);
          this.getPreDefinedTemplates();
        }
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  executeAction(status:any, itcrexecId:any){
    const requestBody = {
      "flag": status == "delete" ? 'D':'V',
      "itcrExecID": status == "delete" ? itcrexecId : 0,
      "itcrid": status == "delete" ? 0 : this.crData.itcrid,
      "sysLandscape": status == "delete" ? 0 : 1,
      "executionStepName": status == "delete" ? "string":'',
      "executionStepDesc": status == "delete" ? "string":'',
      "assignedTo": status == "delete" ? 0 : null,
      "startDt": status == "delete" ? "2024-05-27T13:04:04.576Z" : null,
      "endDT": status == "delete" ? "2024-05-27T13:04:04.576Z" : null,
      "attachments": status == "delete" ? "string" : null,
      "status": status == "delete" ? "string" : 'Implemented',
      "forwardStatus": status == "delete" ? "string" : null,
      "forwardedTo": status == "delete" ? 0 : null,
      "forwardedDt": status == "delete" ? "2024-05-27T13:04:04.576Z" : null,
      "reasonForwarded": status == "delete" ? "string" : null,
      "remarks": status == "delete" ? "string" : null,
      "pickedStatus": status == "delete" ? "string" : null,
      "pickedDt": status == "delete" ? "2024-05-27T13:04:04.576Z" : null,
      "actualStartDt": status == "delete" ? "2024-05-27T13:04:04.576Z" : null,
      "actualEndDt": status == "delete" ? "2024-05-27T13:04:04.576Z" : this.actualEndDtValue,
      "dependSysLandscape": 0,
      "dependTaskId": 0,
      "createdBy": status == "delete" ? 0 : null
    }

    this.httpSer.httpPost(this.API_URLS.executePlanAPI, requestBody).subscribe(
      (response: any) => {
        if(status == "delete"){
          if (response.type == "E") {
            this.deleteInProgress = true;
            this.deleteInMessage = "There are open items, it can't be deleted!"
          } else if (response.type == "S") {
            this.deleteSuccess = true;
            this.deleteMessage = "Deleted Task ID: " + this.deleteitcrexecId + " Successfully"
          }
        } 
        else{
          if (response.type == 'E') {
            alert(response.message);
            return;
          } else {
            alert('RFC Code' + ' ' + this.crData.crcode + ' ' + ': Release successfully submitted for Approval');
            this.emailapproversinfo('Submitted for Approval');
            this.router.navigate(['/change-request']);
          }
        }
      },
      (error: any) => {
        console.log('Post request failed', error);
      }
    );
  }

  // executeFunc() {
  //   const requestBody = {
  //     "flag": "D",
  //     "itcrExecID": this.deleteitcrexecId,
  //     "itcrid": 0,
  //     "sysLandscape": 0,
  //     "executionStepName": "string",
  //     "executionStepDesc": "string",
  //     "assignedTo": 0,
  //     "startDt": "2024-05-27T13:04:04.576Z",
  //     "endDT": "2024-05-27T13:04:04.576Z",
  //     "attachments": "string",
  //     "status": "string",
  //     "forwardStatus": "string",
  //     "forwardedTo": 0,
  //     "forwardedDt": "2024-05-27T13:04:04.576Z",
  //     "reasonForwarded": "string",
  //     "remarks": "string",
  //     "pickedStatus": "string",
  //     "pickedDt": "2024-05-27T13:04:04.576Z",
  //     "actualStartDt": "2024-05-27T13:04:04.576Z",
  //     "actualEndDt": "2024-05-27T13:04:04.576Z",
  //     "dependSysLandscape": 0,
  //     "dependTaskId": 0,
  //     "createdBy": 0
  //   }

  //   return this.httpSer.httpPost(this.API_URLS.executePlanAPI, requestBody).toPromise()
  //     .then((response: any) => {
  //       if (response.type == "E") {
  //         this.deleteInProgress = true;
  //         this.deleteInMessage = "There are open items, it can't be deleted!"
  //       } else if (response.type == "S") {
  //         this.deleteSuccess = true;
  //         this.deleteMessage = "Deleted Task ID: " + this.deleteitcrexecId + " Successfully"
  //       }
  //     })
  //     .catch((error: any) => {
  //       throw error;
  //     });
  // }

  // submitExexute() {
  //   const requestBody = {
  //     flag: 'V',
  //     itcrid: this.crData.itcrid,
  //     sysLandscape: 1,
  //     executionStepName: '',
  //     executionStepDesc: '',
  //     assignedTo: null,
  //     startDt: null,
  //     endDT: null,
  //     attachments: null,
  //     status: 'Implemented',
  //     forwardStatus: null,
  //     forwardedTo: null,
  //     forwardedDt: null,
  //     reasonForwarded: null,
  //     remarks: null,
  //     pickedStatus: null,
  //     pickedDt: null,
  //     actualStartDt: null,
  //     actualEndDt: this.actualEndDtValue,
  //     createdBy: null,
  //   };

  //   this.httpSer.httpPost(this.API_URLS.executePlanAPI, requestBody).subscribe(
  //     (response: any) => {
  //       if (response.type == 'E') {
  //         alert(response.message);
  //         return;
  //       } else {
  //         alert(
  //           'RFC Code' +
  //           ' ' +
  //           this.crData.crcode +
  //           ' ' +
  //           ': Release successfully submitted for Approval'
  //         );
  //         this.emailapproversinfo('Submitted for Approval');
  //         this.router.navigate(['/change-request']);
  //       }
  //     },
  //     (error: any) => {
  //       console.log('Post request failed', error);
  //     }
  //   );
  // }

  emailapproversinfo(status: string): Promise<any> {
    const requestBody = {
      stage: 'C',
      plantid: Number(this.crData.plantcode),
      categoryId: Number(this.crData.itcategoryId),
      classificationId: Number(this.crData.itclassificationId),
    };

    return this.httpSer
      .httpPost(this.API_URLS.GET_APPROVER_EMAIL, requestBody)
      .toPromise()
      .then((response: any) => {
        //this.sendemailfrom(status, response);
      })
      .catch((error: any) => {
        throw error;
      });
  }

  addNewTask() {
    this.router.navigate(['/changerequest/cr-addtask'], {
      queryParams: { id: this.crData.itcrid, sysid: this.selectoption },
    });
  }

  navigateToUpdateTask(itcrexecId: string) {
    this.router.navigate(['/changerequest/cr-updateTask'], {
      queryParams: {
        id: itcrexecId,
        sysid: this.selectoption,
        impid: this.crData.itcrid,
      },
    });
  }

  navigateFromImplementtoUpdateTask(row: any) {
    this.router.navigate(['/changerequest/cr-updateTask'], {
      queryParams: { 
        id: row.dependTaskId, 
        sysid: this.selectoption,
        impid: this.crData.itcrid
      }
    });
  }
}
