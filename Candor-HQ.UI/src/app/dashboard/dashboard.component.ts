import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { ChangeDetectorRef, Component, ElementRef, OnInit, ViewChild, viewChild } from '@angular/core';import { environment } from '@environments/environment';
import { Color } from '@swimlane/ngx-charts';
import { ChartData, ChartDataset, ChartOptions, ChartType, Plugin } from 'chart.js';
import { PasscrdataService } from '../change-request/passcrdata.service';
import { ActivatedRoute } from '@angular/router';
import { Chart } from 'chart.js';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
})

export class DashboardComponent implements OnInit {

  multi: any[] = [];
  showChart: boolean = false;
  chartOptions: any = {};
  issueOptions: any = {};
  @ViewChild('cCont', { static: true }) myElementRef!: ElementRef;
  @ViewChild('issueChart', { static: true }) issueElement!: ElementRef;
  supportid: any;
  today: any;
  crData: any[] = [];
  issueBarChartLabels: any;
  issueList: any;
  user: any
  isSuperAdmin: any;
  isSuportEngineer: any;
  isAdmin: any;
  completedIssueCount: any;
  openIssueCount: any;
  pendingIssueCount: any;
  newIssueList: any;
  completedProjectCount:any
  inProgressProjectCount:any
  projectManagementList=[]
  constructor(private http: HttpClient, private routeservice: PasscrdataService,
    private cdr: ChangeDetectorRef,private route: ActivatedRoute,public httpSer:HttpServiceService,
    private userInfo : UserInfoSerService) {
    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
    this.user = this.userInfo.getUser()
    this.isSuperAdmin = this.user.supportTeamAssignList.filter((m: any) => m.isSuperAdmin).length > 0
    this.isSuportEngineer = this.user.supportTeamAssignList.filter((m: any) => m.supportId == 4 && m.isSupportEngineer).length > 0
    this.isAdmin = this.user.supportTeamAssignList.filter((m: any) => m.supportId == 4 && m.isAdmin).length > 0
    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);
  }

  private apiurl = environment.apiurls;

  single: any;

  dropdownList: any[] = [];
  dplantcode: any = null;
  selectedPlantIds: any[] = [];
  startDate: any = '';
  endDate: any = '';
  colorScheme: any;
  data: any;
  options: any;
  Plant: any = '';
  serviceNew!: number | null;
  servicePending!: number | null;
  serviceCompleted!: number | null;
  assetNew!: number | null;
  assetPending!: number | null;
  assetCompleted!: number | null;
  spareNew!: number | null;
  sparePending!: number | null;
  spareCompleted!: number | null;

  ngOnInit(): void {
    /* this.getchangerequest();*/
    //this.getBarchart();
    //this.getChartData();\
    this.getProjectManagementList()
    this.getsupportteams()
    this.getissuelist()
    this.getService();
    this.getAsset();
    this.getSpare();
    this.getplant();
    // this.getIssueBarchart();
    this.colorScheme = {
      domain: ['#14A44D', '#808080ff', '#54B4D3', '#DC4C64', '#b5eb49']
    };
  }

  getService() {
    this.httpSer.httpGet('/serviceMaster/getService').subscribe((res: any) => {
      this.serviceNew = res?.data?.filter((m: any) => m.status?.trim() === "Pending Approval"
      ||m.status?.trim() === "Draft"
      ||m.status?.trim() === "Approval not required"||m.status?.trim() === "Pending HOD Approval")?.length;
      this.servicePending = res?.data?.filter((m: any) => m.status?.trim() === "In Progress"
      ||m.status?.trim() === "Open")?.length;
      this.serviceCompleted = res?.data?.filter((m: any) => m.status?.trim() === "Resolved")?.length;
    })
  }
  

  getAsset() {
    this.httpSer.httpGet('/AssetRequest/GetAssets').subscribe((res: any) => {
      this.assetNew = res?.data?.filter((m: any) => m.status?.trim() === "Pending Approval"
      ||m.status?.trim() === "Draft"
      ||m.status?.trim() === "Approval not required"||m.status?.trim() === "Pending HOD Approval")?.length;
      this.assetPending = res?.data?.filter((m: any) => m.status?.trim() === "In Progress"
      ||m.status?.trim() === "Open")?.length;
      this.assetCompleted = res?.data?.filter((m: any) => m.status?.trim() === "Resolved")?.length;
    })
  }

  
  getProjectManagementList() {
    this.httpSer.httpGet('/projectManagement/getProject').subscribe((response : any)=>{
      this.projectManagementList = response.data
      this.inProgressProjectCount = this.projectManagementList.filter((m:any)=>{
        return m.projectStatus!='Approved'
      })?.length

      this.completedProjectCount = this.projectManagementList.filter((m:any)=>{
        return m.projectStatus=='Approved'
      })?.length
    })
  }

  getSpare() {
    this.httpSer.httpGet('/ITSpareRequest/GetSparevalue').subscribe((res: any) => {
      this.spareNew = res?.data?.filter((m: any) => m.status?.trim() === "Pending Approval")?.length;
      this.sparePending = res?.data?.filter((m: any) => m.status?.trim() === "In Progress")?.length;
      this.spareCompleted = res?.data?.filter((m: any) => m.status?.trim() === "Resolved")?.length;
    })
  }

  dropdownSettings = {
    idField: 'item_id',
    textField: 'item_text',
    allowSearchFilter: true
  };

  isVisible: boolean = false;
  toggleVisibility(): void {
    this.isVisible = !this.isVisible
  }
  getissuelist() {
    const apiUrls = this.apiurl + '/IssueList/Getissuelist';
    return this.http.get(apiUrls).toPromise()
      .then((response: any) => {
        this.issueList = response;
  
        // First filter based on super admin or admin permissions
        this.issueList = this.issueList.filter((m: any) => {
          if (this.isSuperAdmin) {
            return true; // Allow all issues for super admin
          }
  
          if (this.isAdmin) {
            const isAssignedToCategory = (supportId: number, roleCheck: string) => {
              return this.user.supportTeamAssignList
                .filter((n: any) => n.supportId === supportId && m[roleCheck])
                .map((a: any) => a.categoryId)
                .includes(m.categoryId);
            };
  
            const isAssignedToCategoryType = (supportId: number, roleCheck: string) => {
              return this.user.supportTeamAssignList
                .filter((n: any) => n.supportId === supportId && m[roleCheck])
                .map((a: any) => a.categoryTypId)
                .includes(m.categoryTypId);
            };
  
            return (
              (isAssignedToCategory(4, 'isAdmin') || isAssignedToCategory(4, 'isSupportEngineer')) ||
              (isAssignedToCategoryType(4, 'isSupportEngineer') && isAssignedToCategory(4, 'isSupportEngineer'))
            );
          }
  
          return false;
        });
  
        if (!this.isSuperAdmin && !this.isAdmin) {
          this.issueList = this.issueList.filter((m: any) => {
            return m.issuerisedforid === parseInt(this.user?.empData?.employeeNo);
          });
        }
  
        this.newIssueList = this.issueList;
  
        this.completedIssueCount = this.issueList.filter((m: any) => m.status?.trim() === 'Closed')?.length;
        this.openIssueCount = this.issueList.filter((m: any) => m.status?.trim() === 'Open')?.length;
        this.pendingIssueCount = this.issueList.filter((m: any) => m.status?.trim() !== 'Closed' && m.status?.trim() !== 'Open')?.length;
  
        this.getIssueChart();
        this.getDoughnutChartData();
        this.getPlantWiseIssueCahrt();
      })
      .catch((error: any) => {
        throw error;
      });
  }
  
  getPlantWiseIssueCahrt(){
        this.multi = [];
        const uniquePlants = [...new Set(this.issueList.map((item: { plantId: any; }) => item.plantId))];

        uniquePlants.forEach(plantId => {
          const stagesCount: { [key: string]: number } = {};
          this.issueStageToCOunt.forEach(stage => {
            stagesCount[stage] = this.issueList.filter((item: any) => item.status?.trim() === stage&&item.plantId==plantId).length;
          });

      const issueSeries = {
        label: plantId,
        data: this.issueStageToCOunt.map(stage => stagesCount[stage])
      };

      this.multi.push(issueSeries);
    });
    this.issueOptions = {
      animationEnabled: true,
      exportEnabled: false,
      data: this.issueStageToCOunt.map((stage, index) => ({
        dataPoints: this.multi.map(plantSeries => ({ y: plantSeries.data[index], label: plantSeries.label })),
        type: "stackedBar",
        name: stage,
        showInLegend: true,
        color: this.getRandomColor(index)

      })),

      axisX: {
        title: "Plant ID",
        reversed: true

      },

      axisY: {
        title: "Total Changes",
        gridThickness: 0,
        includeZero: true
      },
      toolTip: {
        shared: true
      },
      legend: {
        dockInsidePlotArea: false,
        horizontalAlign: "center",
        verticalAlign: "top"
      }
    };
  }

  getIssueChart() {
    let monthWiseData = this.getIssuesByMonth()
    this.issueBarChartLabels = monthWiseData.issueMonth;
    this.issueBarChartData[0].data = monthWiseData.totalClosed
    this.issueBarChartData[1].data = monthWiseData.totalNotClosed
  }

  getDoughnutChartData() {
    this.issueDoughnutChartData = {
      labels: ['Draft', 'In Progress', 'Open', 'Seek Clarification', 'Submit Clarification', 'Resolved',
        'On Hold', 'Closed', 'Not Resolved', 'Cancelled'],
      datasets: [
        {
          data: [
            this.issueList.filter((m:any)=>m.status.trim()=='Draft').length,
            this.issueList.filter((m:any)=>m.status.trim()=='In Progress').length,
            this.issueList.filter((m:any)=>m.status.trim()=='Open').length,
            this.issueList.filter((m:any)=>m.status.trim()=='Seek Clarification').length,
            this.issueList.filter((m:any)=>m.status.trim()=='Submit Clarification').length,
            this.issueList.filter((m:any)=>m.status.trim()=='Resolved').length,
            this.issueList.filter((m:any)=>m.status.trim()=='On Hold').length,
            this.issueList.filter((m:any)=>m.status.trim()=='Not Resolved').length,
            this.issueList.filter((m:any)=>m.status.trim()=='Cancelled').length

          ],
          backgroundColor: ['#3B71CA', '#808080', '#14A44D', '#DC4C64', '#54B4D3', '#E4A11B', '#b5eb49', '#a9a1e8', '#FF5733', '#C70039', '#900C3F', '#581845']
        }
      ]
    };
  }
  onFilterChange() {
    this.reset()
    this.getchangerequest();
    this.getChartData();
    this.getBarchart();
  }

  /*onSelectedItemsChange(): void {
    console.log("this is the plant ids will come", this.Plant)
    this.Plant = this.selectedPlantIds.map((item: any) => item.item_id);

  }*/


  getplant() {
    const apiUrls = this.apiurl + '/Plantid';
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    this.http.get(apiUrls, httpOptions).subscribe(
      (response: any) => {
        console.log(response);
        this.dropdownList = response.map((item: any) => ({
          item_id: item.id,
          item_text: item.code
        }));

        console.log(this.dropdownList);
      },
      (error) => {
        console.error('Get plant failed', error);
      }
    );
  }

  mapedplantfilter: any;
  asignedplantidfilter: any;
  fromDt: any = '';
  endDt: any = '';
  mapedplantdatas() {
    this.mapedplantfilter = this.selectedPlantIds.map((item: any) => item.item_id);
    this.asignedplantidfilter = Array.from(new Set(this.mapedplantfilter));
  }

  openNav() {
    const mySidenav = document.getElementById('mySidenav');
    if (mySidenav) {
      mySidenav.style.width = '250px';
    }
  }

  closeNav() {
    const mySidenav = document.getElementById('mySidenav');
    if (mySidenav) {
      mySidenav.style.width = '0';
    }
  }



  // DoughnutChart


  //API Call for change request
  changerequest: any[] = [];
  newCount: number = 0;
  completedCount: number = 0;
  pendingCount: number = 0;
  pendingApproval: number = 0;
  Approved: number = 0;
  Rejected: number = 0;
  Implemention: number = 0;
  pending: number = 0;
  release: number = 0;
  Closure: number = 0;
  filter: any[] = [];
  getbarchart: any[] = [];


  getchangerequest() {
    const apiUrls = this.apiurl + '/ViewChangeRequest/ViewChangerequest';
    let queryParams = new HttpParams();
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      }),
    };

    this.http.get(apiUrls, httpOptions).subscribe(
      (response: any) => {
        if (this.issuperadmin) {
          this.changerequest = response
        }
        else if (this.ischangeanalyst) {
          this.changerequest = response.filter((item: { crownerid: any; }) => item.crownerid === parseInt(this.supportid));
        }
        else {
          this.changerequest = response.filter((item: any) => this.assignedcat.includes(item.itcategoryId) && this.assignedplant.includes(item.plantcode));
        }
        this.filter = this.changerequest
        this.countStatus();
        // this.issuecountStatus();
        const startDateObj = new Date(this.startDate);
        const endDateObj = new Date(this.endDate);

        // Filter by crdate within the date range
        this.filter = this.filter.filter((item: any) => {
          const crdate = new Date(item.crdate);
          return crdate >= startDateObj && crdate <= endDateObj;
        });
        console.log('plant:', this.filter)
      },

      (error) => {
        console.error("Post failed", error);
      }
    );
  }
  
  public doughnutChartData: ChartData<any, any[], string> = {
    labels: [],
    datasets: [
      {
        data: [],
        label: 'Status Counts',
        backgroundColor: []
      }
    ]
  };

  filterdonutbyplant() {
    this.filteredbarchartplant();
    // this.newIssueList = this.issueList
    this.issueList = this.newIssueList.filter((a:any)=>{
      return this.selectedPlantIds.map(m=>m.item_id).includes(a.plantId)
    })
    
    this.completedIssueCount = this.issueList.filter((m:any)=>m.status?.trim() == 'Closed')?.length
    this.openIssueCount = this.issueList.filter((m:any)=>m.status?.trim() == 'Open')?.length
    this.pendingIssueCount = this.issueList.filter((m:any)=>m.status?.trim() != 'Closed'&&m.status?.trim() != 'Open')?.length
    this.getIssueChart()
    this.getDoughnutChartData()
    this.getPlantWiseIssueCahrt()
    this.filterplantwisebar();
    if (this.asignedplantidfilter != '') {
      this.changerequest = this.changeanalystplant.filter((item: any) => this.asignedplantidfilter.includes(item.plantcode));
    }

    if (this.fromDt != '') {
      if (this.endDt == '') {
        this.endDt = this.today
      }
      this.changerequest = this.changeanalystplant.filter((item: any) => item.crdate.split('T')[0] >= this.fromDt && item.crdate.split('T')[0] <= this.endDt)
    }
    this.filter = this.changerequest
      this.countStatus();
      // this.issuecountStatus();
  }

  countStatus() {
    this.newCount = this.filter.filter(item => item.status?.trim() === 'Draft').length;
    this.completedCount = this.filter.filter(item => item.status?.trim() === 'Completed').length;
    this.pendingCount = this.filter.filter(item => item.status?.trim() !== 'Completed' && item.status?.trim() !== 'Draft').length;
    this.pendingApproval = this.filter.filter(item => item.status?.trim() === 'Pending Approval').length;
    this.Approved = this.filter.filter(item => item.status?.trim() === 'Approved').length;
    this.Rejected = this.filter.filter(item => item.status?.trim() === 'Rejected').length;
    this.Implemention = this.filter.filter(item => item.status?.trim() === 'Implement').length;
    this.pending = this.filter.filter(item => item.status?.trim() === 'Pending').length;
    this.release = this.filter.filter(item => item.status?.trim() === 'Release').length;

    this.doughnutChartData = {
      labels: ['Draft', 'Pending Approval', 'Approved', 'Rejected', 'Implementation', 'Pending', 'Release', 'Closure'],
      datasets: [
        {
          data: [
            this.newCount,
            this.pendingApproval,
            this.Approved,
            this.Rejected,
            this.Implemention,
            this.pending,
            this.release,
            this.completedCount
          ],
          label: 'Status Counts',
          backgroundColor: ['#3B71CA', '#808080', '#14A44D', '#DC4C64', '#54B4D3', '#E4A11B', '#b5eb49', '#a9a1e8', '#FF5733', '#C70039', '#900C3F', '#581845']
        }
      ]
    };
  };

  public doughnutChartLabels: string[] = ['Draft', 'Pending Approval', 'Approved', 'Rejected', 'Implementation', 'Pending', 'Release', 'Closure'];

  public doughnutChartType: ChartType = 'doughnut';

  public chartHovered(e: any): void {
    // console.log(e);
  }




  /*Barchart*/

  chartdata: any;
  completed: any[] = [];         //-------
  /*notcompleted: any[] = [];*/
  // noncompleted: any[] = [];
  month: any[] = [];

barChartData: ChartDataset[] = [
  { data: [], label: 'Completed'},
  { data: [], label: 'Non-Completed'}
];
issueBarChartData: ChartDataset[] = [
  { data: [], label: 'Completed'},
  { data: [], label: 'Non-Completed'}
];
  barChartLabels: string[] = [];
  // noncompletedtotal: number = 0;
  // completedtotal: number = 0;
  barChartLegend = true;
  getbarchartfilter: any[] = [];
  crmnthcnt: any[] = [];
  // issuebarChartLabels: string[] = [];
  // issuebarChartLegend = true;


    getBarchart() {
      const apiUrls = this.apiurl + '/Barchart/Getbarchart';
      const httpOptions = {
        headers: new HttpHeaders({
          'content-Type': 'application/json'
        }),
      };

      this.http.get<any>(apiUrls).subscribe(

        (response: any[]) => {
          this.chartdata = response;
          if (this.issuperadmin) {
            this.getbarchartfilter = response
          }
          else {
            if (this.ischangeanalyst) {
              this.getbarchartfilter = response.filter((item: { crowner: Number; }) => item.crowner === parseInt(this.supportid))
            }
            else {
              this.getbarchartfilter = response.filter((item: any) => this.assignedcat.includes(item.categoryId) && this.assignedplant.includes(item.plantId));
            }
          }
          this.getbarchart = this.getbarchartfilter
          this.crData = this.getbarchart

          const uniqueMonths = Array.from(new Set(this.getbarchart.map(item => item.crmonth)));

          // Update chart data and labels
          this.updateBarChartData();
          this.updateBarChartLabels(uniqueMonths);
        },
        (error) => {
        }
      );
    }

  filteredbarchartplant() {
    if (this.asignedplantidfilter != '') {
      this.getbarchart = this.crData.filter((item: any) => this.asignedplantidfilter.includes(item.plantId));
    }

    if (this.fromDt != '') {
      if (this.endDt == '') {
        this.endDt = this.today
      }
      this.getbarchart = this.crData.filter((item: any) => item.crdate.split('T')[0] >= this.fromDt && item.crdate.split('T')[0] <= this.endDt)
    }
    const uniqueMonths = Array.from(new Set(this.getbarchart.map(item => item.crmonth)));
    this.updateBarChartData();
    this.updateBarChartLabels(uniqueMonths);
  }

  getIssuesByMonth() {
    interface Issue {
      createdDt: string;
      isClosed: boolean;
    }

    interface MonthCounts {
      closed: { [key: string]: number };
      notClosed: { [key: string]: number };
    }

    let monthCounts: MonthCounts = {
      closed: {},
      notClosed: {}
    };

    this.issueList.forEach((issue: any) => {
      const createdDate = new Date(issue.createdDt);
      const month = createdDate.toLocaleString('default', { month: 'long' });
  
      if (issue.status?.trim()=='Closed') {
          monthCounts.closed[month] = (monthCounts.closed[month] || 0) + 1;
      } else {
        monthCounts.notClosed[month] = (monthCounts.notClosed[month] || 0) + 1;
      }
    });

    const result = {
      issueMonth: [] as string[],
      totalClosed: [] as number[],
      totalNotClosed: [] as number[]
    };

    const allMonths = new Set<string>([
      ...Object.keys(monthCounts.closed),
      ...Object.keys(monthCounts.notClosed)
    ]);

    allMonths.forEach((month) => {
      const closedCount = monthCounts.closed[month] || 0;
      const notClosedCount = monthCounts.notClosed[month] || 0;

      if (closedCount > 0 || notClosedCount > 0) {
        result.issueMonth.push(month);
        result.totalClosed.push(closedCount);
        result.totalNotClosed.push(notClosedCount);
      }
    });

    return result;

  };
  // OpenedIssueStatus: any[] = [];
  // ClosedIssueStatus: any[] = [];
  // getIssueBarchart() {
  //   const apiUrls = this.apiurl + '/IssueList/';
  //   const httpOptions = {
  //     headers: new HttpHeaders({
  //       'content-Type': 'application/json'
  //     }),
  //   };

  //   this.http.get(apiUrls, httpOptions).subscribe(
  //     (response: any) => {
  //       this.OpenedIssueStatus = response.filter((row: any) => row.status.toString().trim() === 'Open' )
  //       this.ClosedIssueStatus = response.filter((row: any) => row.status.toString().trim() === 'Closed' )
  //     }
  //   )

  // }


  updateBarChartData() {
    this.completed = this.getbarchart.map((item: { completedIdnum: any; }) => item.completedIdnum);
    // this.noncompleted = this.getbarchart.map((item: { nonCompletedIdnum: any; }) => item.nonCompletedIdnum);     // not used anywherew
    const { completedData, nonCompletedData } = this.groupByMonthAndSeparate(this.getbarchart)
    // this.noncompletedtotal = this.noncompleted.reduce((total: number, num: number) => total + num, 0);    // not used anywherew
    // this.completedtotal = this.completed.reduce((total: number, num: number) => total + num, 0);     // not used anywherew
    this.barChartLabels = completedData.map(data => `${data.crmonth}`);
    this.barChartData[0].data = completedData.map(data => data.total);
    this.barChartData[1].data = nonCompletedData.map(data => data.total);

  }


  groupByMonthAndSeparate = (data: any[]) => {
    const completedData: { [key: string]: { crmonth: number, total: number } } = {};
    const nonCompletedData: { [key: string]: { crmonth: number, total: number } } = {};

    data.forEach((obj: any) => {
      const key = `${obj.crmonth}`;

      // For completedIdnum
      if (obj.completedIdnum !== undefined) {
        if (!completedData[key]) {
          completedData[key] = {
            crmonth: obj.crmonth,
            total: 0
          };
        }
        completedData[key].total += obj.completedIdnum;
      }

      // For nonCompletedIdnum
      if (obj.nonCompletedIdnum !== undefined) {
        if (!nonCompletedData[key]) {
          nonCompletedData[key] = {
            crmonth: obj.crmonth,
            total: 0
          };
        }
        nonCompletedData[key].total += obj.nonCompletedIdnum;
      }
    });

    return {
      completedData: Object.values(completedData),
      nonCompletedData: Object.values(nonCompletedData)
    };
  };

  updateBarChartLabels(month: number[]) {

    this.barChartLabels = month.map(month => this.getMonthName(month));
  }

  getMonthName(month: number): string {
    const monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    return monthNames[month - 1];
  }


  onBarClick(event: any) {
    if (event.active.length > 0) {
      const clickedIndex = event.active[0]._index;
      const selectedMonth = this.barChartLabels[clickedIndex];

    }
  }

  public barChartOptions: any = {

    responsive: true
  };

  // events
  public chartClicked(e: any): void {
    // console.log(e);
  }




  //new bar
  changeanalystplant: any[] = [];
  plantwisebarchart: any[] = [];
  plantData: any[] = []
  stagesToCount: string[] = ['Approval', 'Closure', 'Implementation', 'Initiated', 'Release'];
  issueStageToCOunt: string[] = ['Draft', 'In Progress', 'Open', 'Seek Clarification', 'Submit Clarification', 'Resolved',
    'On Hold', 'Closed', 'Not Resolved', 'Cancelled']
  getChartData() {
    const apiUrls = this.apiurl + '/ViewChangeRequest/ViewChangerequest';
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }),
    };


    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.multi = [];

        const uniquePlants = [...new Set(response.map((item: { plantId: any; }) => item.plantId))];

        uniquePlants.forEach(plantId => {
          if (this.issuperadmin) {
            this.changeanalystplant = response
          }
          else if (this.ischangeanalyst) {
            this.changeanalystplant = response.filter((item: { crownerid: any; }) => item.crownerid === parseInt(this.supportid));
          }
          else {
            this.changeanalystplant = response.filter((item: any) => this.assignedcat.includes(item.itcategoryId) && this.assignedplant.includes(item.plantcode));
          }

          this.plantwisebarchart = this.changeanalystplant.filter((item: { plantId: any; }) => item.plantId === plantId);
          this.plantData = this.plantwisebarchart
          const stagesCount: { [key: string]: number } = {};
          this.stagesToCount.forEach(stage => {
            stagesCount[stage] = this.plantData.filter((item: { stage: string; }) => item.stage.trim() === stage).length;
          });

          const plantSeries = {
            label: plantId,
            data: this.stagesToCount.map(stage => stagesCount[stage])
          };

          this.multi.push(plantSeries);
        });

        setTimeout(() => {
          this.updateChartOptions();
        }, 2000);
        this.showChart = true;
      },
      (error: any) => {
      }
    );
  }

  filterplantwisebar() {
    this.filteredbarchartplant();
    if (this.asignedplantidfilter != '') {
      this.plantwisebarchart = this.changeanalystplant.filter((item: any) => this.asignedplantidfilter.includes(item.plantcode));
    }

    if (this.fromDt != '') {
      if (this.endDt == '') {
        this.endDt = this.today
      }
      this.plantwisebarchart = this.changeanalystplant.filter((item: any) => item.crdate.split('T')[0] >= this.fromDt && item.crdate.split('T')[0] <= this.endDt)
    }
    this.plantData = this.plantwisebarchart

    this.multi = []
    const uniquePlants = [...new Set(this.plantData.map((item: { plantId: any; }) => item.plantId))];
    uniquePlants.forEach(plantId => {

      const stagesCount: { [key: string]: number } = {};
      this.stagesToCount.forEach(stage => {
        stagesCount[stage] = this.plantData.filter((item: { stage: string; }) => item.stage.trim() === stage).length;
      });

      const plantSeries = {
        label: plantId,
        data: this.stagesToCount.map(stage => stagesCount[stage])
      };
      this.multi.push(plantSeries);
    })
    this.updateChartOptions();
    setTimeout(() => {
      this.updateChartOptions()
    }, 1000);
  }

  updateChartOptions() {
    this.chartOptions = {
      animationEnabled: true,
      exportEnabled: false,
      data: this.stagesToCount.map((stage, index) => ({
        dataPoints: this.multi.map(plantSeries => ({ y: plantSeries.data[index], label: plantSeries.label })),
        type: "stackedBar",
        name: stage,
        showInLegend: true,
        color: this.getRandomColor(index)

      })),

      axisX: {
        title: "Plant ID",
        reversed: true

      },

      axisY: {
        title: "Total Changes",
        gridThickness: 0,
        includeZero: true
      },
      toolTip: {
        shared: true
      },
      legend: {
        dockInsidePlotArea: false,
        horizontalAlign: "center",
        verticalAlign: "top"
      }
    };
    // this.myElementRef.nativeElement.options = this.chartOptions/
  }

  issueChartOptions() {
    this.chartOptions = {
      animationEnabled: true,
      exportEnabled: false,
      data: this.stagesToCount.map((stage, index) => ({
        dataPoints: this.multi.map(plantSeries => ({ y: plantSeries.data[index], label: plantSeries.label })),
        type: "stackedBar",
        name: stage,
        showInLegend: true,
        color: this.getRandomColor(index)

      })),

      axisX: {
        title: "Plant ID",
        reversed: true

      },

      axisY: {
        title: "Total Changes",
        gridThickness: 0,
        includeZero: true
      },
      toolTip: {
        shared: true
      },
      legend: {
        dockInsidePlotArea: false,
        horizontalAlign: "center",
        verticalAlign: "top"
      }
    };
  }

  getRandomColor(index: number) {
    const colors = ['#3B71CA', '#808080ff', '#54B4D3', '#009596', '#b5eb49','#a9a1e8', '#FF5733', '#C70039', '#900C3F', '#581845'];
    return colors[index % colors.length];
  }


  supportteams: any[] = [];
  getsupportid: any;
  supportpersonname = '';
  firstname: any;
  middlename: any;
  lastname: any;
  emailofreciver: any;
  getsupportteams() {

    const apiUrls = this.apiurl + '/SupportTeam'
    const requestBody = {

    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls, requestBody).subscribe(
      (response: any) => {
        this.supportteams = response.filter((row: any) => row.empId === parseInt(this.supportid.trim()));
        this.getsupportid = this.supportteams[0].supportTeamId;
        this.firstname = this.supportteams[0].firstName;
        this.middlename = this.supportteams[0].middleName;
        this.lastname = this.supportteams[0].lastName;
        this.emailofreciver = this.supportteams[0].email.trim();
        /*this.supportpersonname = this.firstname + this.middlename + this.lastname;*/
        if (this.firstname !== null && this.firstname !== undefined) {
          this.supportpersonname += this.firstname;
        }

        if (this.middlename !== null && this.middlename !== undefined) {
          // If the supportpersonname is not empty, add a space before concatenating middle name
          if (this.supportpersonname !== '') {
            this.supportpersonname += ' ';
          }
          this.supportpersonname += this.middlename;
        }

        if (this.lastname !== null && this.lastname !== undefined) {
          // If the supportpersonname is not empty, add a space before concatenating last name
          if (this.supportpersonname !== '') {
            this.supportpersonname += ' ';
          }
          this.supportpersonname += this.lastname;
        }

        // If all parts of the name are null or undefined, set supportpersonname to 'Unknown'
        if (this.supportpersonname === '') {
          this.supportpersonname = 'Unknown';
        }


        // If all parts of the name are null, set supportpersonname to 'Unknown'
        if (this.supportpersonname === '') {
          this.supportpersonname = 'Unknown';
        }
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
    setTimeout(() => {
      this.getsupportteamassign();
    }, 500);

  }



  supportteamassign: any[] = [];
  ischangeanalyst: any;
  isapprover: any;
  issupportegineer: any;
  assignedplant: any;
  assignedcat: any;
  mapplant: any;
  mapcategory: any;
  issuperadmin: any;
  getsupportteamassign() {

    const apiUrls = this.apiurl + '/SupportteamAssigned'
    const requestBody = {

    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls, requestBody).subscribe(
      (response: any) => {
        this.supportteamassign = response.filter((row: any) => row.supportTeamId === this.getsupportid);
        this.mapplant = this.supportteamassign.map((item: any) => item.plantId);
        this.assignedplant = Array.from(new Set(this.mapplant));
        this.mapcategory = this.supportteamassign.map((item: any) => item.categoryId);
        this.assignedcat = Array.from(new Set(this.mapcategory));
        this.isapprover = this.supportteamassign[0].isApprover
        this.issupportegineer = this.supportteamassign[0].isSupportEngineer
        this.ischangeanalyst = this.supportteamassign[0].isChangeAnalyst
        this.issuperadmin = this.supportteamassign[0].isSuperAdmin
        console.log("PlantLogin", this.assignedplant)
        console.log("CateLogin", this.assignedcat)
      },

      (error) => {
        console.error("Post failed", error)
      }
    )
    setTimeout(() => {
      this.getBarchart();
      this.getChartData();
      this.getchangerequest();
    }, 2000);
  }




  /*For Issues*/



  // issueNewCount: number = 0;
  // issueOpenCount: number = 0;
  // issueInProgressCount: number = 0;
  // issueSeekClarification: number = 0;
  // issueOnHold: number = 0;
  // issueCancelled: number = 0;
  // issueResolved: number = 0;
  // issueClosed: number = 0;


  public issueDoughnutChartData: ChartData<any, any[], string> = {
    labels: [],
    datasets: [
      {
        data: [],
        label: 'Status Counts',
        backgroundColor: []
      }
    ]
  };

  public issueDoughnutChartLabels: string[] = ['New', 'Open', 'In Progress', 'Seek Clarification', 'On Hold', 'Cancelled', 'Resolved', 'Closed'];

  // public issuedoughnutChartType: ChartType = 

  // public issuechartHovered(e: any): void {
  //   // console.log(e);
  // }

  // public issuechartClicked(e: any): void {
  //   // console.log(e);
  // }

  // issuecountStatus() {
  //   this.issueNewCount = 10 /*this.filter.filter(item => item.status.trim() === 'Draft').length*/;
  //   this.issueOpenCount = 2/*this.filter.filter(item => item.status.trim() === 'Completed').length*/;
  //   this.issueInProgressCount = 3/*this.filter.filter(item => item.status.trim() !== 'Completed' && item.status.trim() !== 'Draft').length*/;
  //   this.issueSeekClarification = 4 /*this.filter.filter(item => item.status.trim() === 'Pending Approval').length*/;
  //   this.issueOnHold = 5/*this.filter.filter(item => item.status.trim() === 'Approved').length*/;
  //   this.issueCancelled = 6/*this.filter.filter(item => item.status.trim() === 'Rejected').length*/;
  //   this.issueResolved = 7/*this.filter.filter(item => item.status.trim() === 'Implement').length*/;
  //   this.issueClosed = 8;

  //   // this.issuedoughnutChartData = {
  //   //   labels: ['New', 'Open', 'In Progress', 'Seek Clarification', 'On Hold', 'cancelled', 'Resolved', 'Closed'],
  //   //   datasets: [
  //   //     {
  //   //       data: [
  //   //         this.issueNewCount,
  //   //         this.issueOpenCount,
  //   //         this.issueInProgressCount,
  //   //         this.issueSeekClarification,
  //   //         this.issueOnHold,
  //   //         this.issueCancelled,
  //   //         this.issueResolved,
  //   //         this.issueClosed
  //   //       ],
  //   //       label: 'Status Counts',
  //   //       //backgroundColor: ['#3B71CA', '#808080ff', '#14A44D', '#DC4C64', '#54B4D3', '#E4A11B', '#b5eb49', '#a9a1e8']
  //   //       backgroundColor: ['#3B71CA', '#FF9EAA', '#14A44D', '#E4A11B', '#808080ff', '#DC4C64', '#b5eb49', '#A7E6FF']
  //   //     }
  //   //   ]
  //   // };
  // };


  //plant wise Issue view Graph

  // issueplant: any[] = [];
  // issueplantwisebarchart: any[] = [];
  // issueplantData: any[] = []
  // issuestagesToCount: string[] = ['Open', 'In Progress', 'On Hold', 'Resolved', 'Closed']
  /* stagesToCount: string[] = ['Approval', 'Closure', 'Implementation', 'Initiated', 'Release'];*/


  // getissueChartData() {
  //   const apiUrls = this.apiurl + '/ViewChangeRequest/ViewChangerequest';
  //   const httpOptions = {
  //     headers: new HttpHeaders({
  //       'Content-Type': 'application/json'
  //     }),
  //   };


  //   this.http.get(apiUrls).subscribe(
  //     (response: any) => {
  //       this.multi = [];

  //       const uniquePlants = [...new Set(response.map((item: { plantId: any; }) => item.plantId))];

  //       uniquePlants.forEach(plantId => {
  //         if (this.issuperadmin) {
  //           this.changeanalystplant = response
  //         }
  //         else if (this.ischangeanalyst) {
  //           this.changeanalystplant = response.filter((item: { crownerid: any; }) => item.crownerid === parseInt(this.supportid));
  //         }
  //         else {
  //           this.changeanalystplant = response.filter((item: any) => this.assignedcat.includes(item.itcategoryId) && this.assignedplant.includes(item.plantcode));
  //         }

  //         this.plantwisebarchart = this.changeanalystplant.filter((item: { plantId: any; }) => item.plantId === plantId);
  //         this.plantData = this.plantwisebarchart
  //         const stagesCount: { [key: string]: number } = {};
  //         this.stagesToCount.forEach(stage => {
  //           stagesCount[stage] = this.plantData.filter((item: { stage: string; }) => item.stage.trim() === stage).length;
  //         });

  //         const plantSeries = {
  //           label: plantId,
  //           data: this.stagesToCount.map(stage => stagesCount[stage])
  //         };

  //         this.multi.push(plantSeries);
  //       });

  //       // Now that multi is constructed, update chartOptions
  //       this.updateIssueChartOptions();
  //       this.showChart = true;
  //     },
  //     (error: any) => {
  //       console.error('Error fetching chart data:', error);
  //     }
  //   );
  // }

  // filterissueplantwisebar() {
  //   this.filteredbarchartplant();
  //   if (this.asignedplantidfilter != '') {
  //     this.plantData = this.changeanalystplant.filter((item: any) => this.asignedplantidfilter.includes(item.plantcode));
  //   }

  //   if (this.fromDt != '') {
  //     if (this.endDt == '') {
  //       this.endDt = this.today
  //     }
  //     this.plantData = this.changeanalystplant.filter((item: any) => item.crdate > this.fromDt && item.crdate < this.endDt)
  //   }
  //   // this.plantData = this.plantwisebarchart
  //     this.updateIssueChartOptions();
  // }

  // updateIssueChartOptions() {
  //   this.chartOptions = {
  //     animationEnabled: true,
  //     exportEnabled: false,
  //     data: this.stagesToCount.map((stage, index) => ({
  //       dataPoints: this.multi.map(plantSeries => ({ y: plantSeries.data[index], label: plantSeries.label })),
  //       type: "stackedBar",
  //       name: stage,
  //       showInLegend: true,
  //       color: this.getRandomColor(index)

  //     })),

  //     axisX: {
  //       title: "Plant ID",
  //       reversed: true

  //     },

  //     axisY: {
  //       title: "Total Changes",
  //       gridThickness: 0,
  //       includeZero: true
  //     },
  //     toolTip: {
  //       shared: true
  //     },
  //     legend: {
  //       dockInsidePlotArea: false,
  //       horizontalAlign: "center",
  //       verticalAlign: "top"
  //     }

  //   };

  // }
  reset() {
    this.selectedPlantIds = []
    this.fromDt = ''
    this.endDt = ''
  }
  // issuegetRandomColor(index: number) {
  //   const colors = ['#FF9EAA', '#14A44D', '#808080ff', '#b5eb49', '#A7E6FF'];
  //   return colors[index % colors.length];
  // }



  // Issues






}


