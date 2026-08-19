import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from '@environments/environment';
import { UserInfoSerService } from 'app/services/user-info-ser.service';

@Component({
  selector: 'app-asset-sidebar',
  templateUrl: './asset-sidebar.component.html',
  styleUrl: './asset-sidebar.component.css'
})
export class AssetSidebarComponent {

  ShowAdminSupData: boolean = false;
  private apiurl = environment.apiurls
  private loginurls = environment.loginurl

  showCRSubItems: boolean = false;
  showHDSubItems: boolean = false;
  showMSSubItems: boolean = false;
  arrowIconCR: string = 'bx bxs-chevron-down';
  arrowIconHD: string = 'bx bxs-chevron-down';
  arrowIconMS: string = 'bx bxs-chevron-down';
  arrowCircle: string = 'bx bxs-right-arrow-circle';

  CRmenuItems = [
    { name: 'View Change Request', link: '/change-request' },
    { name: 'New Change Request', link: '/new-change' },
    { name: 'Report', link: '/change_request_report' }
  ];

  HDmenuItems = [
    { name: 'Issue', link: '/report_issue' },
    { name: 'Service', link: '/services/servicemaster' },
    { name: 'Assets', link: '/assets/assetmaster' },
    { name: 'Knowledge Base', link: '/reports' }
  ];

  MastermenuItems = [
    // { name: 'Support TeamView', link: '/support_view' },
    { name: 'User Configuration', link: '/support_view' },
    { name: 'Category', link: '/ChageRequest-Masters' },
    { name: 'Category Type', link: '/categorytype' },
    { name: 'Classification', link: '/classification' },
    { name: 'Nature Of Change', link: '/natureofchange' },
    { name: 'System Landscape', link: '/systemlandscape' },
    { name: 'Reference', link: '/Refrencemaster' },
    { name: 'Reference Type', link: '/Refrencetype' },
    { name: 'Priority', link: '/Priority' },
    { name: 'Check List', link: '/viewcheklist' },
    { name: 'SLA Master', link: '/slamaster' },
    { name: 'Check List', link: '/viewcheklist' },
    { name: 'Software Master', link: '/softwareMaster' },
    { name: 'Software Version Master', link: '/softwareVersionMaster' }
  ];
  user;

  toggleSubItems(menuType: string) {
    if (menuType === 'CR') {
      this.showCRSubItems = !this.showCRSubItems;
      this.arrowIconCR = this.showCRSubItems ? 'bx bxs-chevron-up' : 'bx bxs-chevron-down';
    } else if (menuType === 'HD') {
      this.showHDSubItems = !this.showHDSubItems;
      this.arrowIconHD = this.showHDSubItems ? 'bx bxs-chevron-up' : 'bx bxs-chevron-down';
    }
    else if (menuType === 'MS') {
      this.showMSSubItems = !this.showMSSubItems;
      this.arrowIconMS = this.showMSSubItems ? 'bx bxs-chevron-up' : 'bx bxs-chevron-down';
    }
  }
  supportid: any;
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute,
    private userInfo: UserInfoSerService) {
    // this.routeservice.getsupportteam();
    // this.supportid = this.routeservice.supporterID;

    this.user = this.userInfo.getUser();
    this.supportid = this.user?.supportTeamData?.empId;

  }

  ngOnInit(): void {
    this.getsupportteams();
  }
  idofemployee: any;
  urls: string = '';
  async logout() {
    this.idofemployee = '';
    localStorage.removeItem('token');
    localStorage.setItem('isLoggedin', 'false');
    this.urls = this.loginurls + '#' + '/login'
    window.location.href = this.urls
  }

  isSidebarClosed: boolean = true;

  toggleSidebar(): void {
    this.isSidebarClosed = !this.isSidebarClosed;
    this.arrowCircle = this.isSidebarClosed ? 'bx bxs-right-arrow-circle' : 'bx bxs-left-arrow-circle';
    this.showCRSubItems = false;
    this.showHDSubItems = false;
    this.showMSSubItems = false;
    this.arrowIconCR = 'bx bxs-chevron-down';
    this.arrowIconHD = 'bx bxs-chevron-down';
    this.arrowIconMS = 'bx bxs-chevron-down';
  }

  isDarkTheme: boolean = false;

  toggleTheme() {
    this.isDarkTheme = !this.isDarkTheme;

    if (this.isDarkTheme) {
      document.body.style.background = 'linear-gradient(90deg, rgba(2, 0, 36, 1) 0%, rgba(9, 9, 121, 1) 35%, rgba(0, 212, 255, 1) 100%)';
      document.body.style.color = '#000000';
      // Set text color for dark theme
    } else {
      document.body.style.background = '#d6dddd';
      document.body.style.color = '#000000';
    }
  }

  //login
  supportteams: any[] = [];
  getsupportid: any;

  async getsupportteams() {
    const apiUrls = this.apiurl + '/SupportTeam'
    try {
      const response: any = await this.http.get(apiUrls).toPromise();

      if (response) {
        this.supportteams = response.filter((row: any) => row.empId === parseInt(this.supportid));
        this.getsupportid = this.supportteams[0].supportTeamId;
        this.getsupportteamassign();
      }
    } catch (error) {
    }
  }

  supportteamassign: any[] = [];
  ischangeanalyst: any;
  isapprover: any;
  issupportegineer: any;
  isadmin: any;
  issuperadmin: any;

  getsupportteamassign() {
    const apiUrls = this.apiurl + '/SupportteamAssigned'

    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.supportteamassign = response.filter((row: any) => row.supportTeamId === this.getsupportid);
        this.isapprover = this.supportteamassign[0]?.isApprover
        this.issupportegineer = this.supportteamassign[0]?.isSupportEngineer
        this.ischangeanalyst = this.supportteamassign[0]?.isChangeAnalyst
        this.isadmin = this.supportteamassign[0]?.isAdmin
        this.issuperadmin = this.supportteamassign[0]?.isSuperAdmin
      },

      (error) => {
      }
    )
  }


}
