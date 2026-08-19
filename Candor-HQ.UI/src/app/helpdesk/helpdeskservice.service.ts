import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HelpdeskserviceService {
  //IssueResolutionService
  private UpdateIssueResolutionSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  public UpdateIssueResolutiondata$: Observable<any> = this.UpdateIssueResolutionSubject.asObservable();

  getUpdateIssueResolutionData(data: any): void {
    this.UpdateIssueResolutionSubject.next(data);
  }


  //NewIssueDraftUpdate
  private UpdateNewIssueSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  public UpdateNewIssuedata$: Observable<any> = this.UpdateNewIssueSubject.asObservable();

  getUpdateNewIssueData(data: any): void {
    this.UpdateNewIssueSubject.next(data);
  }
}
