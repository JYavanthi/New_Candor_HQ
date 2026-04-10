import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { ChangeDetectorRef, Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { environment } from '@environments/environment';
import { PasscrdataService } from 'app/change-request/passcrdata.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
// import { ChartData, ChartDataset, ChartType } from 'chart.js';
import { ChartData, ChartDataset, ChartType, ChartOptions } from 'chart.js';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-new-dashboard',
  templateUrl: './new-dashboard.component.html',
  styleUrl: './new-dashboard.component.css'
})
export class NewDashboardComponent {

  ngOnInit() {
    console.log('Line Chart Data:', this.planLineChartData);
    this.getissuelist();
  }
  // Bar Chart
  public barChartLabels: string[] = ['Completed', 'In-Complete'];


  public barChartOptions = {
    responsive: true
  };


  public chartHovered(e: any): void {
    // console.log(e);
  }

  public chartClicked(e: any): void {
    // console.log(e);
  }

  public barChartData: ChartData<'bar'> = {
    labels: ['Completed', 'In-Complete'],
    datasets: [
      {
        label: 'Requests',
        data: [8, 12],
        backgroundColor: ['#4e73df', '#f6ad55']
      }
    ]
  };

  // Doughnut Chart

  public doughnutChartType: ChartType = 'doughnut';

  public doughnutChartData: ChartData<'doughnut'> = {
    labels: ['Open', 'Closed', 'Pending'],
    datasets: [
      {
        data: [62.5, 25, 12.5],
        backgroundColor: [
          '#4e73df',
          '#9b59b6',
          '#f6c23e'
        ]
      }
    ]
  };
  public issueDoughnutOptions: ChartOptions<'doughnut'> = {
    responsive: true,
    plugins: {
      legend: {
        position: 'top',
        labels: {
          usePointStyle: true,
          padding: 15
        }
      }
    },
    cutout: '0%' // 👈 makes it PIE like your image
  };



  changerequest: any[] = [];
  newCount: number = 0;
  completedCount: number = 0;
  pendingCount: number = 0;
  pendingApproval: number = 0;
  Approved: number = 0;
  Rejected: number = 0;
  Implemention: number = 0;
  pendingIssueCount: any;
  pending: number = 0;
  release: number = 0;
  Closure: number = 0;
  filter: any[] = [];
  getbarchart: any[] = [];
  openIssueCount: any;
  completedIssueCount: any;
  isSuportEngineer: any;
  today: any;
  isAdmin: any;
  user: any;
  supportid: any;

  constructor(private http: HttpClient, private routeservice: PasscrdataService,
    private cdr: ChangeDetectorRef, private route: ActivatedRoute, public httpSer: HttpServiceService,
    private userInfo: UserInfoSerService) {
    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
    this.user = this.userInfo.getUser()
    this.isSuperAdmin = this.user.supportTeamAssignList.filter((m: any) => m.isSuperAdmin).length > 0
    this.isSuportEngineer = this.user.supportTeamAssignList.filter((m: any) => m.supportId == 4 && m.isSupportEngineer).length > 0
    this.isAdmin = this.user.supportTeamAssignList.filter((m: any) => m.supportId == 4 && m.isAdmin).length > 0
    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);

  }

  ischangeanalyst: any;
  assignedcat: any;
  mapplant: any;
  mapcategory: any;
  supportteamassign: any[] = [];
  isapprover: any;
  issupportegineer: any;
  issuperadmin: any;
  assignedplant: any;


getStatus(m: any): string {
  return (m.status || m.issueStatus || m.currentStatus || '')
    .toLowerCase()
    .replace(/\s+/g, '') // 🔥 removes spaces
    .trim();
}

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

  startDate: any = '';
  endDate: any = '';

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

  getbarchartfilter: any[] = [];
  crData: any[] = [];

  chartdata: any;

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

  updateBarChartLabels(month: number[]) {

    this.barChartLabels = month.map(month => this.getMonthName(month));
  }

  getMonthName(month: number): string {
    const monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    return monthNames[month - 1];
  }

  completed: any[] = [];
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
      if (obj.completedIdnum !== 0) {
        if (!completedData[key]) {
          completedData[key] = {
            crmonth: obj.crmonth,
            total: 0
          };
        }
        completedData[key].total += obj.completedIdnum;
      }

      // For nonCompletedIdnum
      if (obj.nonCompletedIdnum !== 0) {
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

  private apiurl = environment.apiurls;
  isSuperAdmin: any;
  completedProjectCount: any

  getProjectManagementList() {
    this.httpSer.httpGet('/projectManagement/getProject').subscribe((response: any) => {
      this.projectManagementList = response.data
      this.inProgressProjectCount = this.projectManagementList.filter((m: any) => {
        return m.projectStatus != 'Approved'
      })?.length

      this.completedProjectCount = this.projectManagementList.filter((m: any) => {
        return m.projectStatus == 'Approved'
      })?.length
    })
  }



  inProgressProjectCount: any
  projectManagementList = []

getissuelist() {
  const apiUrls = this.apiurl + '/IssueList/Getissuelist';

  return this.http.get(apiUrls).toPromise()
    .then((response: any) => {

      // ✅ KEEP ORIGINAL DATA (IMPORTANT)
      this.issueList = response;

      console.log('API DATA 👉', response);
      console.log('FULL OBJECT 👉', this.issueList[0]);
      console.log('STATUS LIST 👉', this.issueList.map(m => this.getStatus(m)));

      // ✅ CREATE FILTERED COPY (DO NOT OVERRIDE issueList)
      let filteredList = [...this.issueList];

      // 🔹 Role-based filtering
      filteredList = filteredList.filter((m: any) => {

        if (this.isSuperAdmin) {
          return true;
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
            (isAssignedToCategoryType(4, 'isSupportEngineer') &&
              isAssignedToCategory(4, 'isSupportEngineer'))
          );
        }

        return false;
      });

      // 🔹 Non-admin filter
      if (!this.isSuperAdmin && !this.isAdmin) {
        filteredList = filteredList.filter((m: any) => {
          return m.issuerisedforid === parseInt(this.user?.empData?.employeeNo);
        });
      }

      // ✅ USE FILTERED DATA FOR COUNTS
      this.newIssueList = filteredList;

      this.completedIssueCount =
        filteredList.filter(m => this.getStatus(m) === 'closed').length;

      this.openIssueCount =
        filteredList.filter(m => this.getStatus(m) === 'open').length;

      this.pendingIssueCount =
        filteredList.filter(m => {
          const s = this.getStatus(m);
          return s !== 'closed' && s !== 'open';
        }).length;

      // ✅ USE FULL DATA FOR CHARTS (IMPORTANT)
      this.getIssueChart();
      this.getDoughnutChartData();
      this.getPlantWiseIssueCahrt();

      // ✅ FORCE UI UPDATE
      this.cdr.detectChanges();
    })
    .catch((error: any) => {
      throw error;
    });
}


  // getIssuesByMonth() {
  //   interface Issue {
  //     createdDt: string;
  //     isClosed: boolean;
  //   }

  //   interface MonthCounts {
  //     closed: { [key: string]: number };
  //     notClosed: { [key: string]: number };
  //   }

  //   let monthCounts: MonthCounts = {
  //     closed: {},
  //     notClosed: {}
  //   };

  //   this.issueList.forEach((issue: any) => {
  //     const createdDate = new Date(issue.createdDt);
  //     const month = createdDate.toLocaleString('default', { month: 'long' });

  //     if (issue.status?.trim() == 'Closed') {
  //       monthCounts.closed[month] = (monthCounts.closed[month] || 0) + 1;
  //     } else {
  //       monthCounts.notClosed[month] = (monthCounts.notClosed[month] || 0) + 1;
  //     }
  //   });

  //   const result = {
  //     issueMonth: [] as string[],
  //     totalClosed: [] as number[],
  //     totalNotClosed: [] as number[]
  //   };

  //   const allMonths = new Set<string>([
  //     ...Object.keys(monthCounts.closed),
  //     ...Object.keys(monthCounts.notClosed)
  //   ]);

  //   allMonths.forEach((month) => {
  //     const closedCount = monthCounts.closed[month] || 0;
  //     const notClosedCount = monthCounts.notClosed[month] || 0;

  //     if (closedCount > 0 || notClosedCount > 0) {
  //       result.issueMonth.push(month);
  //       result.totalClosed.push(closedCount);
  //       result.totalNotClosed.push(notClosedCount);
  //     }
  //   });

  //   return result;

  // };

  getIssuesByMonth() {

    let monthCounts = {
      closed: {},
      notClosed: {}
    };

    this.issueList.forEach((issue: any) => {

      const createdDate = new Date(issue.issueDate); // ✅ FIXED FIELD
      const month = createdDate.toLocaleString('default', { month: 'long' });

      const status = this.getStatus(issue); // ✅ USE HELPER

      if (status === 'closed') {
        monthCounts.closed[month] = (monthCounts.closed[month] || 0) + 1;
      } else {
        monthCounts.notClosed[month] = (monthCounts.notClosed[month] || 0) + 1;
      }
    });

    const result = {
      issueMonth: [],
      totalClosed: [],
      totalNotClosed: []
    };

    const allMonths = new Set([
      ...Object.keys(monthCounts.closed),
      ...Object.keys(monthCounts.notClosed)
    ]);

    allMonths.forEach((month) => {
      result.issueMonth.push(month);
      result.totalClosed.push(monthCounts.closed[month] || 0);
      result.totalNotClosed.push(monthCounts.notClosed[month] || 0);
    });

    return result;
  }

  issueBarChartLabels: any;

  getIssueChart() {
    let monthWiseData = this.getIssuesByMonth()
    this.issueBarChartLabels = monthWiseData.issueMonth;
    this.issueBarChartData[0].data = monthWiseData.totalClosed
    this.issueBarChartData[1].data = monthWiseData.totalNotClosed
    this.prepareIssueBarChart();
  }

  newIssueList: any;

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


  public barChartLegend = true;


  // Doughnut Chart
  public doughnutChartLabels: string[] = ['Open', 'Closed', 'Pending'];



  // CanvasJS Chart
  chartOptions = {
    animationEnabled: true,
    data: [{
      type: "pie",
      startAngle: 240,
      indexLabel: "{label} {y}%",
      dataPoints: [
        { y: 35, label: "Plant 1" },
        { y: 25, label: "Plant 2" },
        { y: 20, label: "Plant 3" },
        { y: 20, label: "Plant 4" }
      ]
    }]
  };

  issueBarChart: any;

  // prepareIssueBarChart() {

  //   this.issueBarChart = {
  //     labels: ['Completed', 'In-Complete'],
  //     datasets: [
  //       {
  //         label: 'Completed',
  //         data: this.issueBarChartData[0].data,
  //         backgroundColor: '#3BB273'
  //       },
  //       {
  //         label: 'Non-Completed',
  //         data: this.issueBarChartData[1].data,
  //         backgroundColor: '#F4C542'
  //       }
  //     ]
  //   };

  // }

  //   prepareIssueBarChart() {
  //   this.issueBarChart = {
  //     labels: ['Completed', 'In-Complete'],
  //     datasets: [
  //       {
  //         label: 'Issues',
  //         data: [
  //           this.issueBarChartData[0].data[0] || 8,
  //           this.issueBarChartData[1].data[0] || 12
  //         ],
  //         backgroundColor: [
  //           '#5CBF8F',  // green
  //           '#F2C94C'   // yellow
  //         ],
  //         borderRadius: 10,
  //         barThickness: 40
  //       }
  //     ]
  //   };
  // }

  prepareIssueBarChart() {

    const completedArray = this.issueBarChartData[0].data as number[];
    const notCompletedArray = this.issueBarChartData[1].data as number[];

    const completedTotal = completedArray.length
      ? completedArray.reduce((a, b) => a + b, 0)
      : 0;

    const notCompletedTotal = notCompletedArray.length
      ? notCompletedArray.reduce((a, b) => a + b, 0)
      : 0;

    this.issueBarChart = {
      labels: ['Completed', 'In-Complete'],
      datasets: [
        {
          label: 'Issues',
          data: [completedTotal, notCompletedTotal],
          backgroundColor: ['#5CBF8F', '#F2C94C'],
          borderRadius: 10,
          barThickness: 50
        }
      ]
    };
  }
  issueOptions: any = {};


  issueBarChartData: ChartDataset[] = [
    { data: [], label: 'Completed' },
    { data: [], label: 'Non-Completed' }
  ];
  serviceNew!: number | null;
  servicePending!: number | null;
  serviceCompleted!: number | null;

  getService() {
    this.httpSer.httpGet('/serviceMaster/getService').subscribe((res: any) => {
      this.serviceNew = res?.data?.filter((m: any) => m.status?.trim() === "Pending Approval"
        || m.status?.trim() === "Draft"
        || m.status?.trim() === "Approval not required" || m.status?.trim() === "Pending HOD Approval")?.length;
      this.servicePending = res?.data?.filter((m: any) => m.status?.trim() === "In Progress"
        || m.status?.trim() === "Open")?.length;
      this.serviceCompleted = res?.data?.filter((m: any) => m.status?.trim() === "Resolved")?.length;
    })
  }

  getAsset() {
    this.httpSer.httpGet('/AssetRequest/GetAssets').subscribe((res: any) => {
      this.assetNew = res?.data?.filter((m: any) => m.status?.trim() === "Pending Approval"
        || m.status?.trim() === "Draft"
        || m.status?.trim() === "Approval not required" || m.status?.trim() === "Pending HOD Approval")?.length;
      this.assetPending = res?.data?.filter((m: any) => m.status?.trim() === "In Progress"
        || m.status?.trim() === "Open")?.length;
      this.assetCompleted = res?.data?.filter((m: any) => m.status?.trim() === "Resolved")?.length;
    })
  }


  getSpare() {
    this.httpSer.httpGet('/ITSpareRequest/GetSparevalue').subscribe((res: any) => {
      this.spareNew = res?.data?.filter((m: any) => m.status?.trim() === "Pending Approval")?.length;
      this.sparePending = res?.data?.filter((m: any) => m.status?.trim() === "In Progress")?.length;
      this.spareCompleted = res?.data?.filter((m: any) => m.status?.trim() === "Resolved")?.length;
    })
  }

  assetNew!: number | null;
  assetPending!: number | null;
  assetCompleted!: number | null;
  spareNew!: number | null;
  sparePending!: number | null;
  spareCompleted!: number | null;

  issueList: any;



  // getDoughnutChartData() {

  //   this.issueDoughnutChartData = {
  //     labels: ['Draft', 'In Progress', 'Open', 'Seek Clarification', 'Submit Clarification', 'Resolved',
  //       'On Hold', 'Closed', 'Not Resolved', 'Cancelled'],

  //     datasets: [
  //       {
  //         data: [
  //           this.issueList.filter((m: any) => m.status.trim() == 'Draft').length,
  //           this.issueList.filter((m: any) => m.status.trim() == 'In Progress').length,
  //           this.issueList.filter((m: any) => m.status.trim() == 'Open').length,
  //           this.issueList.filter((m: any) => m.status.trim() == 'Seek Clarification').length,
  //           this.issueList.filter((m: any) => m.status.trim() == 'Submit Clarification').length,
  //           this.issueList.filter((m: any) => m.status.trim() == 'Resolved').length,
  //           this.issueList.filter((m: any) => m.status.trim() == 'On Hold').length,
  //           this.issueList.filter((m: any) => m.status.trim() == 'Not Resolved').length,
  //           this.issueList.filter((m: any) => m.status.trim() == 'Cancelled').length
  //         ],

  //         backgroundColor: [
  //           '#3B71CA', '#808080', '#14A44D', '#DC4C64', '#54B4D3',
  //           '#E4A11B', '#b5eb49', '#a9a1e8', '#FF5733', '#C70039'
  //         ]
  //       }
  //     ]
  //   };

  // }

getDoughnutChartData() {

  const item1 =
    this.issueList.filter(m =>
      ['draft', 'inprogress', 'open'].includes(this.getStatus(m))
    ).length;

  const item2 =
    this.issueList.filter(m =>
      ['seekclarification', 'submitclarification', 'onhold'].includes(this.getStatus(m))
    ).length;

  const item3 =
    this.issueList.filter(m =>
      ['resolved', 'closed', 'notresolved', 'cancelled'].includes(this.getStatus(m))
    ).length;

  console.log('Doughnut Counts 👉', item1, item2, item3); // ✅ debug

  this.issueDoughnutChartData = {
    labels: ['Item 1', 'Item 2', 'Item 3'],
    datasets: [
      {
        data: [item1, item2, item3],
        backgroundColor: ['#4e73df', '#a29bfe', '#f6c23e'],
        borderWidth: 0
      }
    ]
  };
}

  multi: any[] = [];

  issueStageToCOunt: string[] = ['Draft', 'In Progress', 'Open', 'Seek Clarification', 'Submit Clarification', 'Resolved',
    'On Hold', 'Closed', 'Not Resolved', 'Cancelled']

  getPlantWiseIssueCahrt() {
    this.multi = [];

    const uniquePlants = [...new Set(this.issueList.map((item: any) => item.plantId))];

    uniquePlants.forEach(plantId => {

      const stagesCount: { [key: string]: number } = {};

      this.issueStageToCOunt.forEach(stage => {
        stagesCount[stage] =
          this.issueList.filter((item: any) =>
            item.status?.trim() === stage &&
            item.plantId == plantId
          ).length;
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

        dataPoints: this.multi.map(plantSeries => ({
          y: plantSeries.data[index],
          label: plantSeries.label
        })),

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
        title: "Total Issues",
        includeZero: true
      },

      toolTip: {
        shared: true
      },

      legend: {
        horizontalAlign: "center",
        verticalAlign: "top"
      }
    };
  }

  getRandomColor(index: number) {
    const colors = ['#3B71CA', '#808080ff', '#54B4D3', '#009596', '#b5eb49', '#a9a1e8', '#FF5733', '#C70039', '#900C3F', '#581845'];
    return colors[index % colors.length];
  }



  // Line Chart Options
  // public lineChartOptions = {
  //   responsive: true,
  //   plugins: {
  //     legend: {
  //       display: true,
  //       position: 'top'
  //     }
  //   },
  //   elements: {
  //     line: {
  //       tension: 0.4 // smooth curve like image
  //     }
  //   }
  // };


  public lineChartOptions: ChartOptions<'line'> = {
    responsive: true,
    plugins: {
      legend: {
        display: true,
        position: 'top' // ✅ now correctly typed
      }
    },
    elements: {
      line: {
        tension: 0.4
      }
    }
  };
  // Line Chart Data (same like image)
  public planLineChartData: ChartData<'line'> = {
    labels: ['Item 1', 'Item 2', 'Item 3', 'Item 4', 'Item 5'],
    datasets: [
      {
        label: 'Plan A',
        data: [18, 25, 23, 35, 36],
        borderColor: '#4e73df',
        backgroundColor: '#4e73df',
        fill: false,
        pointRadius: 4
      },
      {
        label: 'Plan B',
        data: [10, 20, 30, 33, 23],
        borderColor: '#9b59b6',
        backgroundColor: '#9b59b6',
        fill: false,
        pointRadius: 4
      },
      {
        label: 'Plan C',
        data: [15, 30, 24, 32, 41],
        borderColor: '#e056fd',
        backgroundColor: '#e056fd',
        fill: false,
        pointRadius: 4
      }
    ]
  };


  setPlanChartData(apiData: any[]) {
    this.planLineChartData.labels = apiData.map(x => x.month);

    this.planLineChartData.datasets = [
      {
        label: 'Plan A',
        data: apiData.map(x => x.planA),
        borderColor: '#4e73df',
        fill: false
      },
      {
        label: 'Plan B',
        data: apiData.map(x => x.planB),
        borderColor: '#9b59b6',
        fill: false
      },
      {
        label: 'Plan C',
        data: apiData.map(x => x.planC),
        borderColor: '#e056fd',
        fill: false
      }
    ];
  }

}
