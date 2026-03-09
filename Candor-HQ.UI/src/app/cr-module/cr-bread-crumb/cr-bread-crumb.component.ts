import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Input, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';import { environment } from '@environments/environment';

@Component({
  selector: 'app-cr-bread-crumb',
  templateUrl: './cr-bread-crumb.component.html',
  styleUrl: './cr-bread-crumb.component.css'
})
export class CrBreadCrumbComponent {

  statusis:any = '';
  getitcrid: any = '';
  crstage: any = '';
  isApproved: any = '';
  isImplemented: any = '';
  isReleased: any = '';
  isSubmitted: any = '';
  contentcomponent: any = '';
  @Input() crid: any
  constructor(private http: HttpClient,private route:ActivatedRoute, private router:Router) {
    
  }

  onClick() {
    this.contentcomponent.scrollToexecuteComponent();
  }

  approverhistory() {
    this.contentcomponent.scrollToapproverComponent();
  }

  ngOnInit(): void {
    this.draftstatus();
    this.submitstatus();
    this.rejectedstatus();
    this.approvestatus();
    this.executestatus();
    this.releasestatus();
    this.completedstatus();
    this.hidepending();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['crid']) {
      if(!this.crid){
        return
      }
      this.statusis = this.crid?.status.trim();
      this.crstage = this.crid?.stage.trim();
      this.isApproved = this.crid?.isApproved;
      this.isImplemented = this.crid?.isImplemented;
      this.isReleased = this.crid?.isReleased;
      this.isSubmitted = this.crid?.isSubmitted;
    this.draftstatus();
    this.submitstatus();
    this.rejectedstatus();
    this.approvestatus();
    this.executestatus();
    this.releasestatus();
    this.completedstatus();
    this.hidepending();
    }
  }
   
  private apiurl = environment.apiurls

  /*statusbar*/
  draftgreen: boolean = false;

  draftstatus() {

    if (this.statusis == 'Draft' || this.statusis !== 'Draft') {
      this.draftgreen = true
    }

  }

  submitactive: boolean = false;
  submitinactive: boolean = false;

  submitstatus() {
    if (this.statusis == 'Draft' && this.isSubmitted == false) {
      this.submitactive = false
      this.submitinactive = true
    }
    else if (this.isSubmitted == true) {
      this.submitactive = true
      this.submitinactive = false
    }
  }

  pendingapprove: boolean = true;
  hidepending(){
    if (this.isApproved == true || this.statusis == 'Rejected' ){
      this.pendingapprove = false
    }
  }

  rejectedcr: boolean = false;

  rejectedstatus() {
    if (this.statusis == 'Rejected') {
      this.rejectedcr = true
    }
    else {
      this.rejectedcr = false
    }
  }

  approveactive: boolean = false;
  approveinactive: boolean = false;

  approvestatus() {
    if (this.isSubmitted == true && this.isApproved == false) {
      this.approveactive = false
      this.approveinactive = true
    }
    else if (this.isApproved == true) {
      this.approveactive = true
      this.approveinactive = false
    }

  }

  executeactive: boolean = false;
  executeinactive: boolean = false;

  executestatus() {
    if (this.isApproved == true && this.isImplemented == false) {
      this.executeactive = false
      this.executeinactive = true
    }
    else if (this.isImplemented == true) {
      this.executeactive = true
      this.executeinactive = false
    }

  }

  releaseactive: boolean = false;
  releaseinactive: boolean = false;

  releasestatus() {
    if (this.isImplemented == true && this.isReleased == false) {
      this.releaseactive = false
      this.releaseinactive = true
    }
    else if (this.isReleased == true) {
      this.releaseactive = true
      this.releaseinactive = false
    }
  }

  completactive: boolean = false;
  completinactive: boolean = false;

  completedstatus() {
    if (this.isReleased == true && this.statusis !== 'Completed') {
      this.completactive = false
      this.completinactive = true
    }
    else if (this.statusis == 'Completed') {
      this.completactive = true
      this.completinactive = false
    }
  }





  itcrid: any='';
  viewchangerequest: any[] = [];

  getidupdate() {
    this.itcrid = this.route.snapshot.paramMap.get('id');
  }

  getviewcrdata() {
    const apiUrls = this.apiurl + '/ViewChangeRequest/ViewChangerequest'
    const requestBody = {
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        console.log(response);
        this.viewchangerequest = response;
        console.log(this.viewchangerequest)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

changerequest: any[] = [];
getChangerequest(itcrid: any) {
 const apiUrls = this.apiurl + '/ViewChangeRequest/ViewChangerequest';
 const httpOptions = {
   headers: new HttpHeaders({
     'content-Type': 'application/json'
   })
 };
  
  // Include itcrid in the request URL as a query parameter
 const urlWithParams = `${apiUrls}?itcrid=${itcrid}`;
  
 this.http.get(urlWithParams).subscribe(
   (response: any) => {
     console.log(response);
     this.changerequest = response;
     console.log(this.changerequest)
   },
   (error) => {
     console.error("Get request failed", error)
   }
 );
}

//status bar

  /* onClick() {
      this.contentcomponent.scrollToexecuteComponent();
    }*/

  /*approverhistory() {
    this.contentcomponent.scrollToapproverComponent();
  }*/



// Navigative page
goToTab(tabId: string) {
        
this.router.navigate([`/executive/7/edit`], { fragment: tabId });
setTimeout(() => {
  const tabButton = document.getElementById(tabId + '-tab');
  if (tabButton) {
    tabButton.click();
  }
});
  setTimeout(() => {
    this.onClick()
  }, 500);
}
goToapprover(tabId: string) {
        
        this.router.navigate([`/executive/7/edit`], { fragment: tabId });
        setTimeout(() => {
          const tabButton = document.getElementById(tabId + '-tab');
          if (tabButton) {
            tabButton.click();
          }
        });
  setTimeout(() => {
    this.approverhistory()
  }, 500);
}
}
